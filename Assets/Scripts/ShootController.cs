using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float speed = 30f;
    public GameObject parent;
    private Rigidbody2D rb;
    private CharacterController character;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    private void Start() {
        character = parent.GetComponent<CharacterController>();
        if(!character.facingRight)
            Flip();
    }

    private void FixedUpdate()
    {
        var directionSpeed = character.facingRight ? speed : -speed;
        rb.velocity = new Vector2(directionSpeed, rb.velocity.y);
    }

    protected void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Discart ownself collision
        if (other.gameObject != parent)
        {
            // impact enemy but discard other enemies shoot
            // Hero impact
            if (other.gameObject.tag == "Enemy" && parent.tag != "Enemy")
            {
                var powerController = parent.GetComponent<HeroPowerController>();
                var health = other.gameObject.GetComponent<HealthController>();
                health.removeLife(3);
                powerController.EnhanceAttackWithPower(other.gameObject, parent);
            }

            // Enemy impact
            if (other.gameObject.tag == "Hero")
            {
                //Hero lose health
                var health = other.gameObject.GetComponent<HealthController>();
                health.removeLife(3);
            }

            if (parent.tag == "Hero")
                Destroy(gameObject);
            if (parent.tag == "Enemy" && other.gameObject.tag != "Enemy")
                Destroy(gameObject);
        }
    }
}
