using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerController : MonoBehaviour
{
    public Vector3 startMarker;
    public Vector3 endMarker;
    public float speed = 1.0f;
    private float startTime;
    private float journeyLength;

    int x, z;
    
    public enum direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,
        Down = 4
    }
    // Variable to store the current direction
    public direction currentDirection;

    // z-axis is forward and back cardinality
    // North means camera is looking north



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.deltaTime;
        journeyLength = Vector3.Distance(startMarker, endMarker);
        currentDirection = direction.North;
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.deltaTime - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        startMarker = gameObject.transform.position;
        
        //check which camera is active
        //set currentDirection to correspond to active camera

        switch (currentDirection)
        {
            case direction.North:
                currentDirection = direction.North;
                if (Input.GetKey("a"))
                {
                    endMarker = gameObject.transform.position += Vector3.left;
                    // player moves -x
                    // check for collisions
                    gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);

                }
                else if (Input.GetKey("d"))
                {
                    // player moves +x
                    endMarker = gameObject.transform.position += Vector3.right;
                    // check for collisions
                    gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                }
                break;
            case direction.East:
                currentDirection = direction.East;
                if (Input.GetKey("a"))
                {
                    // player moves +z
                    endMarker = gameObject.transform.position += Vector3.forward;
                    // check for collisions
                    gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);

                }
                else if (Input.GetKey("d"))
                {
                    // player moves -z
                    endMarker = gameObject.transform.position += Vector3.back;
                    // check for collision
                    gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                }
                break;
            case direction.South:
                currentDirection = direction.South;
                if (Input.GetKey("a"))
                {
                    // player moves +x
                    endMarker = gameObject.transform.position += Vector3.right;
                    // check for collisions
                    gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                }
                else if (Input.GetKey("d"))
                {
                    // player moves -x
                    endMarker = gameObject.transform.position += Vector3.left;
                    // check for collision
                    gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                }
                break;
            case direction.West:
                currentDirection = direction.West;
                if (Input.GetKey("a"))
                {
                    // player moves -z
                    endMarker = gameObject.transform.position += Vector3.back;
                    // check for collision
                    gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);

                }
                else if (Input.GetKey("d"))
                {
                    // player moves +z
                    endMarker = gameObject.transform.position += Vector3.forward;
                    // check for collision
                    gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                }
                break;
            case direction.Down:
                if (currentDirection == direction.North)
                {
                    if (Input.GetKey("w")) {
                        endMarker = gameObject.transform.position += Vector3.forward;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("a"))
                    {
                        endMarker = gameObject.transform.position += Vector3.left;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("s"))
                    {
                        endMarker = gameObject.transform.position += Vector3.back;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("d"))
                    {
                        endMarker = gameObject.transform.position += Vector3.right;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                }
                else if (currentDirection == direction.East)
                {
                    if (Input.GetKey("w"))
                    {
                        endMarker = gameObject.transform.position += Vector3.right;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("a"))
                    {
                        endMarker = gameObject.transform.position += Vector3.forward;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("s"))
                    {
                        endMarker = gameObject.transform.position += Vector3.left;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("d"))
                    {
                        endMarker = gameObject.transform.position += Vector3.back;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                }
                else if (currentDirection == direction.South)
                {
                    if (Input.GetKey("w"))
                    {
                        endMarker = gameObject.transform.position += Vector3.back;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("a"))
                    {
                        endMarker = gameObject.transform.position += Vector3.right;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("s"))
                    {
                        endMarker = gameObject.transform.position += Vector3.forward;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("d"))
                    {
                        endMarker = gameObject.transform.position += Vector3.left;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                }
                else if (currentDirection == direction.West)
                {
                    if (Input.GetKey("w"))
                    {
                        endMarker = gameObject.transform.position += Vector3.left;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("a"))
                    {
                        endMarker = gameObject.transform.position += Vector3.back;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("s"))
                    {
                        endMarker = gameObject.transform.position += Vector3.right;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                    else if (Input.GetKey("d"))
                    {
                        endMarker = gameObject.transform.position += Vector3.forward;
                        // check for collision
                        gameObject.transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
                    }
                }

                break;
        }


    }
}