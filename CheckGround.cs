using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool Grounded;

    private PlayerMovement player;

    void Start()
    {
        player = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") Grounded = true;
        if (collision.gameObject.tag == "Platform")
        {
            player.transform.parent = collision.transform;
            Grounded = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") Grounded = false;
        if (collision.gameObject.tag == "Platform")
        {
            player.transform.parent = null;
            Grounded = false; 
        } 
    }
}
