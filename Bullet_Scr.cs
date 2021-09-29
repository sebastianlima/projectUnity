using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Scr : MonoBehaviour
{
    public float Speed;

    void Start()
    {
        //Destroy bullet after 2sec
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        //Bullet move on Axis Y
        transform.position += new Vector3(0, Speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ninja")
        {
            collision.gameObject.GetComponentInParent<NinjaEnemy>().Health--;
        }
        if (collision.gameObject.name == "Ninja1")
        {
            collision.gameObject.GetComponentInParent<NinjaEnemy1>().Health--;
        }
        Destroy(gameObject);
    }
}
