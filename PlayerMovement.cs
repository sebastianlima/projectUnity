using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float MaxSpeed;
    public float JumpForce;
    public float Friction;
    public float AttackDelay;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public bool BetterJump;
    public bool Grounded = false;

    private Rigidbody2D Rigid;
    private Animator Anim;
    private SpriteRenderer Sprite;
    private float Horizontal;
    private bool Jumping;
    private bool DoubleJump;
    private bool Movement = true;

    void Start()
    {
        //Access to Unity functions
        Rigid = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        //Set Animations
        Anim.SetBool("Walking", Horizontal != 0.0f && Grounded);
        Anim.SetBool("Ground", Grounded);

        //[Jump] Keyboard.Space / A.XBOX
        Grounded = CheckGround.Grounded;
        if(Input.GetButtonDown("Jump"))
        {
            if (Grounded)
            {
                Jumping = true;
            }
            else if (DoubleJump)
            {
                Jumping = true;
                DoubleJump = false;
            }
        }

        //if (Grounded) DoubleJump = true;
    }

    void FixedUpdate()
    {
        //Artificial friction
        Vector3 FixedVelocity = Rigid.velocity;
        FixedVelocity.x *= Friction;
        
        if (Grounded)
        {
            Rigid.velocity = FixedVelocity;
        }

        //[Run] Keyboard.A-D || Arrows

        //Get Horizontal value
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (!Movement) Horizontal = 0;

         //Actually push our player
        Rigid.AddForce(Vector2.right * Speed * Horizontal);

        //Set MaxSpeed
        float limitedSpeed = Mathf.Clamp(Rigid.velocity.x, -MaxSpeed, MaxSpeed);
        Rigid.velocity = new Vector3(limitedSpeed, Rigid.velocity.y);

        //John looks in the direction he is heading
        if (Horizontal < 0.0f) 
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        if (Horizontal > 0.0f) 
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (Jumping)
        {
            //Erase any remaining momentum
            Rigid.velocity = new Vector2 (Rigid.velocity.x, 0f);
            //Push up
            Rigid.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Jumping = false;
            //Jump audio
            //Camera.main.GetComponent<AudioSource>().PlayOneShot();
        }

        if (BetterJump)
        {
            if (Rigid.velocity.y < 0)
            {
                Rigid.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            
            if (Rigid.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                Rigid.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }

    //Respawn after drop
    void OnBecameInvisible()
    {
        Rigid.velocity = new Vector2 (0.0f, 0.0f);
        transform.position = new Vector3(-36.0f, 2.0f, 0.0f);
    }

    //Enemy interaction
    public void EnemyJump()
    {
        Jumping = true;
    }

    public void EnemyAttack(float enemyPosX)
    {
        Jumping = true;

        float Side = Mathf.Sign(enemyPosX - transform.position.x);
        Rigid.AddForce(Vector2.left * Side * JumpForce / 2, ForceMode2D.Impulse);

        Movement = false;
        Invoke("EnableMovement", AttackDelay);

        Sprite.color = Color.red;
    }

    void EnableMovement()
    {
        Movement = true;

        Sprite.color = Color.white;
    }
}