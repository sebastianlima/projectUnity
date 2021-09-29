using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DovePlayer : MonoBehaviour
{
    public Vector3 Movement;
    public float Speed;
    public GameObject Bullet;
    public int Pts;
    public Text Score;

    private float LastShoot;

    void Start()
    {
        
    }

    void Update()
    {
        //Ship controller Mouse
        //Movement = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"), 0);
        //Ship controller Keyboard
        Movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        //k speed
        Movement = Movement.normalized;
        transform.position += Movement * Speed * Time.deltaTime;

        if (Input.GetButton("Fire1") && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }

        Score.text = Pts.ToString("");
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ninja")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
