using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    public float TimeToFlip = 2f;
    public float ShootFrequence = 4f;
    public bool ableToAttack = true;
    [System.NonSerialized]
    public bool isPoisoned = false;

    public Action<GameObject> OnKill;

    private GameObject Hero;
    private float dist;
    private Position currentPosition;
    private float DistanceFromHero;
    private bool isSooting = false;

    private void Awake()
    {
        Hero = GameObject.FindGameObjectsWithTag("Hero")[0];
        dist = Vector3.Distance(Hero.transform.position, transform.position);
        base.Awake();
    }

    private void Start()
    {
        if (facingRight)
            currentPosition = Position.Right;
        else
            currentPosition = Position.Left;

        Face();
        base.Start();
    }

    private void Update() {
        DistanceFromHero = Vector3.Distance(Hero.transform.position, transform.position);
    }

    private void FixedUpdate()
    {
        if(!isDead)
        {
            Face();
            // Move
            if(DistanceFromHero > 8f && DistanceFromHero < 15f)
                MoveToHero();
            else
                move(0);

            // Shoot
            if(DistanceFromHero > 0 && DistanceFromHero < 8.5f && !isSooting && ableToAttack)
            {
                StartCoroutine("ShootOverTime");
                isSooting = true;
            }

            // Attack
            Collider2D[] hitColliders = AttackOverlap();
            if(hitColliders.Length > 0 && ableToAttack)
                Attack();
        }   
    }

    private IEnumerator ShootOverTime()
    {
        Shoot();
        yield return new WaitForSeconds(ShootFrequence);
        isSooting = false;
    }

    // When Hero overlaps front attack is permitted
    private Collider2D[] AttackOverlap()
    {
        var AttackDetector = gameObject.transform.Find("Rogue_pelvis_01").transform.Find("AttackDetector");
        var CharacterHeroLayer = 1 << LayerMask.NameToLayer("CharacterHero");
        return Physics2D.OverlapCircleAll(AttackDetector.transform.position, 1f, CharacterHeroLayer);
    }

    private void Face()
    {
        var position = RelativePosition(Hero);
        if (position != currentPosition)
            Invoke(nameof(FaceHero), TimeToFlip);

        if (position == Position.Right)
            currentPosition = Position.Right;
        else
            currentPosition = Position.Left;
    }

    private void FaceHero()
    {
        if (currentPosition == Position.Right)
        {
            facingRight = true;
            FlipRight();
        }
        else
        {
            facingRight = false;
            FlipLeft();
        }
    }

    private void MoveToHero()
    {
        if(currentPosition == Position.Right)
            move(0.5f);
        else
            move(-0.5f);
    }

    protected void FlipRight()
    {
        Vector3 theScale = transform.localScale;
        if(theScale.x < 0) {
            Flip();
        }
    }

    protected void FlipLeft()
    {
        Vector3 theScale = transform.localScale;
        if(theScale.x > 0) {
            Flip();
        }
    }

    public void OnDeath(GameObject self)
    {
        base.OnDeath();
        CancelInvoke(nameof(FaceHero)); // cancel pending face;
        OnKill(self);
    }

    private bool isFace2Face(GameObject hero)
    {
        var heroController = hero.GetComponent<HeroController>();
        var positionFromHero = RelativePosition(hero);
        return positionFromHero == Position.Right && facingRight ||
        positionFromHero == Position.Left && !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Hero" && isAttacking)
        {   
            if(isFace2Face(other.gameObject))
            {
                // Combat attack // *****************************
                var heroHealth = other.gameObject.GetComponent<HealthController>();
                heroHealth.removeLife(15);
            }

            isAttacking = false;
            CancelInvoke(nameof(StopAttack));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var ElementsLayer = LayerMask.NameToLayer("ElementPower");
        if (collision.gameObject.layer == ElementsLayer)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
