using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public GameObject player;
    public Vector2 minCamPos, maxCamPos;
    public float smoothTime;

    private Vector2 velocity;

    void FixedUpdate()
    {
        //La cámara sigue al jugador
        if (player != null)
        {
            float PosX = Mathf.SmoothDamp(transform.position.x, 
            player.transform.position.x, ref velocity.x, smoothTime);
            float PosY = Mathf.SmoothDamp(transform.position.y, 
            player.transform.position.y, ref velocity.y, smoothTime);

            transform.position = new Vector3(
                Mathf.Clamp(PosX, minCamPos.x, maxCamPos.x),
                Mathf.Clamp(PosY, minCamPos.y, maxCamPos.y),
                transform.position.z);
        }
    }
}
