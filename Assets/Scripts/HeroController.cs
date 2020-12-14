using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : CharacterController
{
    public float ShootLapse = 0;
    public Action OnKill;

    private bool jump = false;
    private bool move = true;
    private bool grounded = false;
    private readonly List<KeyCode> actions = new List<KeyCode>();
    private float lastShoot;
    private Transform groundCheck;

    void Awake()
    {
        base.Awake();
        lastShoot = ShootLapse;
        groundCheck = transform.Find("GroundDetector");
    }

    void Update()
    {
        if(!isDead)
        {
            lastShoot += Time.deltaTime; // Count time since last shoot
            grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
                jump = true;

            UpdateKeyboardAction(KeyCode.LeftArrow);
            UpdateKeyboardAction(KeyCode.RightArrow);
            UpdateKeyboardAction(KeyCode.Q);
            UpdateKeyboardAction(KeyCode.W);
        }
    }

    void FixedUpdate() {
        if(!isDead)
        {
            var horizontal = Input.GetAxis("Horizontal");
            if(move)
                move(horizontal);
            else
                rb.velocity = new Vector2(0 , 0);

            if (actions.Contains(KeyCode.Q))
            {
                Attack();
            }
            if (actions.Contains(KeyCode.W)) 
            {
                if(lastShoot > 3) {
                    Shoot();
                    lastShoot = 0;
                }
            }
            
            if(jump)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        base.Jump();
        jump = false;
    }

    private void Attack()
    {
        move = false;
        Invoke(nameof(AllowMove), 1f);
        Invoke(nameof(StopAttack), 3f);
        base.Attack();
    }

    private void AllowMove()
    {
        move = true;
    }

    private void UpdateDownAction(KeyCode code)
    {
        if (!actions.Contains(code))
            actions.Add(code);
    }

    private void UpdateUpAction(KeyCode code)
    {
        if (actions.Contains(code))
            actions.Remove(code);
    }

    private void UpdateKeyboardAction(KeyCode code)
    {
        if (Input.GetKeyDown(code))
            UpdateDownAction(code);

        if (Input.GetKeyUp(code))
            UpdateUpAction(code);
    }

    private bool isFace2Face(GameObject enemy)
    {
        var EnemyController = enemy.GetComponent<EnemyController>();
        var positionFromEnemy = RelativePosition(enemy);
        return positionFromEnemy == Position.Right && !EnemyController.facingRight ||
        positionFromEnemy == Position.Left && EnemyController.facingRight;
    }

    public void OnDeath()
    {
        base.OnDeath();
        OnKill();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Attacked Enemy Instance
        if(other.gameObject.tag == "Enemy" && isAttacking)
        {   
            // Combat attack // *****************************
            var powerController = gameObject.GetComponent<HeroPowerController>();
            // face or back attack
            if(isFace2Face(other.gameObject)){
                // Apply power consequences to enemy if FRONT attack
                powerController.EnhanceAttackWithPower(other.gameObject, gameObject);
            } else {
                // Kill Enemy if BACK attack
                var enemy = other.gameObject.GetComponent<EnemyController>();
                enemy.OnDeath(other.gameObject);
            }

            isAttacking = false;
            CancelInvoke(nameof(StopAttack));
        }
    }
}
