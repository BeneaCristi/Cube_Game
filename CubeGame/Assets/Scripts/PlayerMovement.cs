using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float speed;
    public float sidespeed;


    void Start()
    {

    }


    void FixedUpdate()
    {
        rb.AddForce(0, 0, speed * Time.deltaTime);

        if(Input.GetKey("d"))
        {
            rb.AddForce(sidespeed * Time.deltaTime, 0, 0 , ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidespeed * Time.deltaTime, 0, 0 , ForceMode.VelocityChange);
        }
        if (rb.position.y < -5f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            speed = 0;
            sidespeed = 0;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
