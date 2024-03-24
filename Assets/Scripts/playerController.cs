using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


public class playerController : MonoBehaviour
{
    public Vector3 startMarker = new Vector3(0,0,0);
    public Vector3 endMarker = new Vector3(0, 0, 0);
    public float speed = 0.05f;
    private float startTime;
    private float journeyLength;
    private bool canMove = true;
    float fracJourney = 0;

    // Arya code
    private int buttonsPressed = 1;

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
        
        journeyLength = Vector3.Distance(startMarker, endMarker);
        currentDirection = direction.North;
    }

    // Update is called once per frame
    void Update()
    {
        
        float distCovered = (Time.time - startTime) * speed;
        //float fracJourney = distCovered / journeyLength;
        startMarker = gameObject.transform.position;
        if (fracJourney < 1)
        {
            fracJourney += Time.deltaTime;
        }

        //check which camera is active
        //set currentDirection to correspond to active camera
        //Debug.Log(fracJourney);
        if (canMove)
        {
            switch (currentDirection)
            {
                case direction.North:
                    currentDirection = direction.North;
                    if (Input.GetKey("a"))
                    {
                        endMarker = gameObject.transform.position += Vector3.left;
                        // player moves -x
                        // check for collisions


                    }
                    else if (Input.GetKey("d"))
                    {
                        // player moves +x
                        endMarker = gameObject.transform.position += Vector3.right;
                        // check for collisions

                    }
                    break;
                case direction.East:
                    currentDirection = direction.East;
                    if (Input.GetKey("a"))
                    {
                        // player moves +z
                        endMarker = gameObject.transform.position += Vector3.forward;
                        // check for collisions


                    }
                    else if (Input.GetKey("d"))
                    {
                        // player moves -z
                        endMarker = gameObject.transform.position += Vector3.back;
                        // check for collision

                    }
                    break;
                case direction.South:
                    currentDirection = direction.South;
                    if (Input.GetKey("a"))
                    {
                        // player moves +x
                        endMarker = gameObject.transform.position += Vector3.right;
                        // check for collisions

                    }
                    else if (Input.GetKey("d"))
                    {
                        // player moves -x
                        endMarker = gameObject.transform.position += Vector3.left;
                        // check for collision

                    }
                    break;
                case direction.West:
                    currentDirection = direction.West;
                    if (Input.GetKey("a"))
                    {
                        // player moves -z
                        endMarker = gameObject.transform.position += Vector3.back;
                        // check for collision


                    }
                    else if (Input.GetKey("d"))
                    {
                        // player moves +z
                        endMarker = gameObject.transform.position += Vector3.forward;
                        // check for collision

                    }
                    break;
                case direction.Down:
                    if (currentDirection == direction.North)
                    {
                        if (Input.GetKey("w"))
                        {
                            endMarker = gameObject.transform.position += Vector3.forward;
                            // check for collision

                        }
                        else if (Input.GetKey("a"))
                        {
                            endMarker = gameObject.transform.position += Vector3.left;
                            // check for collision

                        }
                        else if (Input.GetKey("s"))
                        {
                            endMarker = gameObject.transform.position += Vector3.back;
                            // check for collision

                        }
                        else if (Input.GetKey("d"))
                        {
                            endMarker = gameObject.transform.position += Vector3.right;
                            // check for collision

                        }
                    }
                    else if (currentDirection == direction.East)
                    {
                        if (Input.GetKey("w"))
                        {
                            endMarker = gameObject.transform.position += Vector3.right;
                            // check for collision

                        }
                        else if (Input.GetKey("a"))
                        {
                            endMarker = gameObject.transform.position += Vector3.forward;
                            // check for collision

                        }
                        else if (Input.GetKey("s"))
                        {
                            endMarker = gameObject.transform.position += Vector3.left;
                            // check for collision

                        }
                        else if (Input.GetKey("d"))
                        {
                            endMarker = gameObject.transform.position += Vector3.back;
                            // check for collision

                        }
                    }
                    else if (currentDirection == direction.South)
                    {
                        if (Input.GetKey("w"))
                        {
                            endMarker = gameObject.transform.position += Vector3.back;
                            // check for collision

                        }
                        else if (Input.GetKey("a"))
                        {
                            endMarker = gameObject.transform.position += Vector3.right;
                            // check for collision

                        }
                        else if (Input.GetKey("s"))
                        {
                            endMarker = gameObject.transform.position += Vector3.forward;
                            // check for collision

                        }
                        else if (Input.GetKey("d"))
                        {
                            endMarker = gameObject.transform.position += Vector3.left;
                            // check for collision

                        }
                    }
                    else if (currentDirection == direction.West)
                    {
                        if (Input.GetKey("w"))
                        {
                            endMarker = gameObject.transform.position += Vector3.left;
                            // check for collision

                        }
                        else if (Input.GetKey("a"))
                        {
                            endMarker = gameObject.transform.position += Vector3.back;
                            // check for collision
                        }
                        else if (Input.GetKey("s"))
                        {
                            endMarker = gameObject.transform.position += Vector3.right;
                            // check for collision
                        }
                        else if (Input.GetKey("d"))
                        {
                            endMarker = gameObject.transform.position += Vector3.forward;
                            // check for collision
                        }
                    }

                    break;
            }
            if(startMarker != endMarker)
            {
                fracJourney = 0;
                StartCoroutine(moveCD());
            }
        }
        
        transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        
        

    }
    IEnumerator moveCD()
    {
        
        canMove = false;
        Debug.Log(canMove);
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "exitLevel")
        {
            SceneManager.LoadScene("level2", LoadSceneMode.Additive);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "buttonStart")
        {
            if (Input.GetKey("f"))
            {
                GameObject door = GameObject.Find("door");
                Destroy(door);
            }
        }
        if (other.tag == "squareButton")
        {
            if (Input.GetKey("f"))
            {
                if (buttonsPressed == 1)
                {
                    buttonsPressed++;
                }
            }
        }
        if (other.tag == "circleButton")
        {
            if (buttonsPressed == 2)
            {
                buttonsPressed++;
            }
        }
        if (other.tag == "rectButton")
        {
            if (buttonsPressed == 4)
            {
                SceneManager.LoadScene("level3", LoadSceneMode.Additive);
            }
        }
        if (other.tag == "ovalButton")
        {
            if (buttonsPressed == 3)
            {
                buttonsPressed++;
            }
        }
    }
}
