using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaEnemy : MonoBehaviour
{
    public float speedRotate;
    public float speedDown;
    public GameObject Ninja;
    public int Health;
    public int RandomScale;

    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            RandomScale = 1;
        }
        else
        {
            RandomScale = -1;
        }

        transform.localScale = new Vector3(RandomScale, 1, 1);
    }

    void Update()
    {
        Ninja.transform.Rotate(0, 0, speedRotate * Time.deltaTime);
        transform.position += new Vector3(0, speedDown * Time.deltaTime);

        if(Health <= 0)
        {
            GameObject.Find("DovePlayer").GetComponent<DovePlayer>().Pts++;
            Destroy(gameObject);
        }
    }
}
