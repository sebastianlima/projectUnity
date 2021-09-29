using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaEnemy1 : MonoBehaviour
{
    public float speedRotate;
    public float speedDown;
    public GameObject Ninja1;
    public int Health;

    void Start()
    {
        
    }

    void Update()
    {
        Ninja1.transform.Rotate(0, 0, speedRotate * Time.deltaTime);
        transform.position += new Vector3(0, speedDown * Time.deltaTime);

        if(Health <= 0)
        {
            GameObject.Find("DovePlayer").GetComponent<DovePlayer>().Pts++;
            Destroy(gameObject);
        }
    }
}
