using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeftRightMovement : MonoBehaviour
{
    public float speed = 2.0f;  // Speed of movement
    public float moveDistance = 5.0f;  // How far to move left and right
    private Vector3 startingPosition;  // Starting position of the object
    private bool movingRight = true;  // Whether the object is moving right
    private bool isWaiting = false;  // Whether the object is waiting

    void Start()
    {
        startingPosition = transform.position;  // Store the starting position
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        while (true)
        {
            if (isWaiting)
            {
                yield return new WaitForSeconds(2.0f);  // Wait for 2 seconds
                isWaiting = false;  // Reset waiting flag
            }

            // Move the object
            if (movingRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x >= startingPosition.x + moveDistance)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (transform.position.x <= startingPosition.x)
                {
                    isWaiting = true;  // Set the waiting flag
                    movingRight = true;
                }
            }

            yield return null;  // Wait until next frame
        }
    }
}

