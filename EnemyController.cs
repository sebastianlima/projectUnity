using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed;
    public float MaxSpeed;
    public float Friction;
    public float offSetY;

    private Rigidbody2D Rigid;
    private Animator Anim;
    private float Horizontal;
    
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector3 FixedVelocity = Rigid.velocity;
        FixedVelocity.x *= Friction;
        
        Rigid.velocity = FixedVelocity;
        
        Rigid.AddForce(Vector2.right * Speed);

        float limitedSpeed = Mathf.Clamp(Rigid.velocity.x, -MaxSpeed, MaxSpeed);
        Rigid.velocity = new Vector3(limitedSpeed, Rigid.velocity.y);

        if (Rigid.velocity.x > -0.01f && Rigid.velocity.x < 0.01f)
        {
            Speed = -Speed;
            Rigid.velocity = new Vector3(Speed, Rigid.velocity.y);
        }

        if (Speed < 0.0f) 
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (Speed > 0.0f) 
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (transform.position.y + offSetY < collision.transform.position.y)
            {
                collision.SendMessage("EnemyJump");
                Destroy(gameObject);
            }
            else
            {
                collision.SendMessage("EnemyAttack", transform.position.x);
            }
        }
    }
}
