using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Platform : MonoBehaviour
{
    public float fallDelay;
    public float respawnDelay;
    
    private Rigidbody2D Rigid;
    private PolygonCollider2D Pol;
    private Vector3 KickOff;

    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Pol = GetComponent<PolygonCollider2D>();
        KickOff = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);
        }
    }

    void Fall()
    {
        Rigid.isKinematic = false;
        Pol.isTrigger = true;
    }

    void Respawn()
    {
        Rigid.isKinematic = true;
        Pol.isTrigger = false;
        Rigid.velocity = Vector3.zero;
        transform.position = KickOff;
    }
}
