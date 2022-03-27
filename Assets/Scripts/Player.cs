using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int speed = 300;

    Rigidbody2D playerRigidBody;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerRigidBody.AddForce(new Vector2(Input.acceleration.x * speed * Time.deltaTime, Input.acceleration.y * speed * Time.deltaTime));
    }
}
