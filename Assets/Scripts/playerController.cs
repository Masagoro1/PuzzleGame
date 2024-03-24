using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;


public class playerController : MonoBehaviour
{
    public Vector3 startMarker = new Vector3(0,1,0);
    public Vector3 endMarker = new Vector3(0, 1, 0);
    LayerMask terrain;
    public float speed = 0.25f;
    private float startTime;
    private float journeyLength;
    private bool canMove = true;
    float fracJourney = 0;
    public bool foundWall;
    // Arya code
    private int buttonsPressed = 1;

    enum direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,
        Down = 4
    }
    // Variable to store the current direction
    direction currentDirection;
    direction currentRotation;
    public int pubDir;
    public int pubRot;
    // z-axis is forward and back cardinality
    // North means camera is looking north



    // Start is called before the first frame update
    void Start()
    {
        terrain = LayerMask.GetMask("Terrain");
        journeyLength = Vector3.Distance(startMarker, endMarker);
        currentDirection = direction.North;
        transform.position = startMarker;
    }

    // Update is called once per frame
    void Update()
    {
        foundWall = false;
        currentRotation = (direction)pubRot;
        currentDirection = (direction)pubDir;
        float distCovered = (Time.time - startTime) * speed;
        //float fracJourney = distCovered / journeyLength;
        
        startMarker = gameObject.transform.position;
        if (fracJourney < 1)
        {
            fracJourney += Time.deltaTime * speed;
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
                    if (Input.GetKeyDown("a"))
                    {
                        endMarker = gameObject.transform.position += Vector3.left;
                        // player moves -x

                        // check for collision
                        checkDest();

                    }
                    else if (Input.GetKeyDown("d"))
                    {
                        // player moves +x
                        endMarker = gameObject.transform.position += Vector3.right;

                        // check for collision
                        checkDest();
                    }
                    break;
                case direction.East:
                    currentDirection = direction.East;
                    if (Input.GetKeyDown("a"))
                    {
                        // player moves +z
                        endMarker = gameObject.transform.position += Vector3.forward;
                        // check for collision
                        checkDest();


                    }
                    else if (Input.GetKeyDown("d"))
                    {
                        // player moves -z
                        endMarker = gameObject.transform.position += Vector3.back;

                        // check for collision
                        checkDest();
                    }
                    break;
                case direction.South:
                    currentDirection = direction.South;
                    if (Input.GetKeyDown("a"))
                    {
                        // player moves +x
                        endMarker = gameObject.transform.position += Vector3.right;
                        // check for collision
                        checkDest();

                    }
                    else if (Input.GetKeyDown("d"))
                    {
                        // player moves -x
                        endMarker = gameObject.transform.position += Vector3.left;
                        // check for collision
                        checkDest();

                    }
                    break;
                case direction.West:
                    currentDirection = direction.West;
                    if (Input.GetKeyDown("a"))
                    {
                        // player moves -z
                        endMarker = gameObject.transform.position += Vector3.back;
                        // check for collision
                        checkDest();

                    }
                    else if (Input.GetKeyDown("d"))
                    {
                        // player moves +z
                        endMarker = gameObject.transform.position += Vector3.forward;
                        // check for collision
                        checkDest();
                    }
                    break;
                case direction.Down:
                    if (currentRotation == direction.North)
                    {
                        if (Input.GetKeyDown("w"))
                        {
                            endMarker = gameObject.transform.position += Vector3.forward;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("a"))
                        {
                            endMarker = gameObject.transform.position += Vector3.left;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("s"))
                        {
                            endMarker = gameObject.transform.position += Vector3.back;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("d"))
                        {
                            endMarker = gameObject.transform.position += Vector3.right;
                            // check for collision
                            checkDest();
                        }
                    }
                    else if (currentRotation == direction.East)
                    {
                        if (Input.GetKeyDown("w"))
                        {
                            endMarker = gameObject.transform.position += Vector3.right;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("a"))
                        {
                            endMarker = gameObject.transform.position += Vector3.forward;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("s"))
                        {
                            endMarker = gameObject.transform.position += Vector3.left;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("d"))
                        {
                            endMarker = gameObject.transform.position += Vector3.back;
                            // check for collision
                            checkDest();
                        }
                    }
                    else if (currentRotation == direction.South)
                    {
                        if (Input.GetKeyDown("w"))
                        {
                            endMarker = gameObject.transform.position += Vector3.back;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("a"))
                        {
                            endMarker = gameObject.transform.position += Vector3.right;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("s"))
                        {
                            endMarker = gameObject.transform.position += Vector3.forward;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("d"))
                        {
                            endMarker = gameObject.transform.position += Vector3.left;
                            // check for collision
                            checkDest();
                        }
                    }
                    else if (currentRotation == direction.West)
                    {
                        if (Input.GetKeyDown("w"))
                        {
                            endMarker = gameObject.transform.position += Vector3.left;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("a"))
                        {
                            endMarker = gameObject.transform.position += Vector3.back;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("s"))
                        {
                            endMarker = gameObject.transform.position += Vector3.right;
                            // check for collision
                            checkDest();
                        }
                        else if (Input.GetKeyDown("d"))
                        {
                            endMarker = gameObject.transform.position += Vector3.forward;
                            // check for collision
                            checkDest();
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
        if(canMove)
        {
            canMove = false;
            yield return new WaitForSeconds(0.2f);
            canMove = true;
        }
        
    }
    void checkDest()
    {
        if (foundWall)
        {
            return;
        }
        //Debug.Log(Physics.CheckSphere(transform.position, 0.25f, 3));
        if (Physics.CheckSphere(endMarker, 0.25f, terrain))
        {
            Debug.Log("test");
            endMarker = startMarker;
            foundWall = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "endLevel")
        {
            SceneManager.LoadScene("level2", LoadSceneMode.Additive);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "buttonStart")
        {
            if (Input.GetKeyDown("f"))
            {
                GameObject door = GameObject.Find("door");
                Destroy(door);
            }
        }
        if (other.tag == "squareButton")
        {
            if (Input.GetKeyDown("f"))
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
