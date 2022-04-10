using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly int speed = 300;

    Rigidbody2D playerRigidBody;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerRigidBody.AddForce(new Vector2(Input.acceleration.x * speed * Time.deltaTime, Input.acceleration.y * speed * Time.deltaTime));
        playerRigidBody.SetRotation(Mathf.Atan2(-Input.acceleration.x, Input.acceleration.y) * Mathf.Rad2Deg);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
