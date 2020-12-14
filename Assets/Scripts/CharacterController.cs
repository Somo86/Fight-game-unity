using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool isHero = false;
    public bool facingRight = true;
    public float speed = 10f;
    public float jumpForce = 100f;
    public GameObject shootWeapon;
    protected bool isDead = false;
    protected bool isAttacking = false;
    protected AudioSource audio;
    private AudioClip clipDead;
    private AudioClip clipShoot;

    protected enum Position
    {
        Right,
        Left
    }
    protected Animator animator;
    protected Rigidbody2D rb;
    protected void Awake()
    {
        animator = transform.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();
        audio = transform.GetComponent<AudioSource>();
        clipDead = Resources.Load<AudioClip>("Sounds/dead");
        clipShoot = Resources.Load<AudioClip>("Sounds/shoot");
    }

    protected void Start()
    {
        if (!facingRight)
            Flip();
    }

    protected void move(float horizontal)
    {
        animator.SetFloat("run", Mathf.Abs(horizontal));

        if (horizontal < 0 && facingRight)
        {
            facingRight = false;
            Flip();
        }
        else if (horizontal > 0 && !facingRight)
        {
            facingRight = true;
            Flip();
        }

        Vector3 horizontalVector = new Vector3(horizontal, 0.0f, 0.0f);
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    protected void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    protected void Attack()
    {
        isAttacking = true;
        animator.SetTrigger("attack");
    }

    protected void StopAttack()
    {
        isAttacking = false;
    }

    protected void Shoot()
    {
        audio.PlayOneShot(clipShoot);
        animator.SetTrigger("shoot");
        var handPosition = gameObject.transform.Find("Rogue_pelvis_01");
        var weapon = Instantiate(shootWeapon);
        weapon.GetComponent<ShootController>().parent = gameObject; // retrieve shooter to controller
        weapon.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.6f, gameObject.transform.position.z);
    }

    protected void Jump()
    {
        animator.SetTrigger("jump");
        rb.AddForce(new Vector2(0f, 10f * jumpForce));
    }

    protected Position RelativePosition(GameObject target)
    {
        var TargetPositionX = target.transform.position.x;
        var CurrentPositionX = transform.position.x;
        return TargetPositionX <= CurrentPositionX ? Position.Left : Position.Right;
    }

    protected void OnDeath()
    {
        RemovePhysics();
        animator.SetTrigger("death");
        audio.PlayOneShot(clipDead);
        isDead = true;
    }

    private void RemovePhysics()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
    }

}
