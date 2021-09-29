using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float Speed; //-1.0f
    public GameObject ObjDown;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y <= -10)
        {
            transform.position = ObjDown.transform.position + new Vector3 (0, 10, 0);
        }
        
        transform.position += new Vector3(0, Speed * Time.deltaTime, 0);
    }
}
