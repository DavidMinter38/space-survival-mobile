using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    GameObject leftObstacle;

    [SerializeField]
    GameObject rightObstacle;

    float startingSpeed = -2f;
    float currentSpeed = -2f;
    float speedIncrease = -0.1f;
    float maxLeft = -9;
    float maxRight = 9;
    int lowerBoundary = -8;
    int upperSpawnPoint = 7;

    float minGap = 24f;
    float gapChange = 0.25f;

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
            currentSpeed += speedIncrease;
            //Move the walls closer together, unless they are already close enough.
            if((rightObstacle.transform.position.x - leftObstacle.transform.position.x) >= minGap)
            {
                leftObstacle.transform.position = new Vector2(leftObstacle.transform.position.x + gapChange, transform.position.y);
                rightObstacle.transform.position = new Vector2(rightObstacle.transform.position.x - gapChange, transform.position.y);
            }
        }
    }
}
