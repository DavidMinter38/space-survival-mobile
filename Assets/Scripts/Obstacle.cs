using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float startingSpeed = -2f;
    float currentSpeed = -2f;
    float maxLeft = -9;
    float maxRight = 9;
    int lowerBoundary = -8;
    int upperSpawnPoint = 7;

    void Start()
    {
        currentSpeed = startingSpeed;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + currentSpeed * Time.deltaTime);

        if(transform.position.y < lowerBoundary)
        {
            transform.position = new Vector2(Random.Range(maxLeft, maxRight), upperSpawnPoint);
            currentSpeed -= 0.1f;
            //TODO make the walls move in slightly closer, unless they are already close enough.
        }
    }
}
