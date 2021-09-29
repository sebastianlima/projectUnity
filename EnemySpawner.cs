using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float Timer, WaitTime;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Timer <= 0)
        {
            Instantiate(Enemy, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            Timer = WaitTime;
        }
        
        Timer -= Time.deltaTime;
    }
}
