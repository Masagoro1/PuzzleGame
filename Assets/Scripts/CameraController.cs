using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraController : MonoBehaviour
{
    enum direction
    {
        North = 0,
        East,
        South,
        West,
        Down
    }
    Transform player;
    Transform[] points;
    direction currDir = direction.North;
    direction currRot;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //points[0] = GameObject.FindWithTag("Point0").transform;
        //points[1] = GameObject.FindWithTag("Point1").transform;
        //points[2] = GameObject.FindWithTag("Point2").transform;
        //points[3] = GameObject.FindWithTag("Point3").transform;
        //points[4] = GameObject.FindWithTag("Point4").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Handles right arrow
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(currDir < direction.Down)
            {
                if(currDir == direction.West)
                {
                    currDir = direction.North;
                }
                else
                {
                    currDir = (direction)((int)currDir + 1);
                }
                Debug.Log(currDir);
            }
            else
            {
                switch (currRot)
                {
                    case (direction.North):
                        currDir = direction.West;
                        break;
                    case (direction.East):
                        currDir = direction.North;
                        break;
                    case (direction.South):
                        currDir = direction.East;
                        break;
                    case (direction.West):
                        currDir = direction.South;
                        break;
                }
            }
        }
        //handles left arrow
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currDir < direction.Down)
            {
                if (currDir == direction.North)
                {
                    currDir = direction.East;
                }
                else
                {
                    currDir = (direction)((int)currDir - 1);
                }
                Debug.Log(currDir);
            }
            else
            {
                switch (currRot)
                {
                    case (direction.North):
                        currDir = direction.West;
                        break;
                    case (direction.East):
                        currDir = direction.North;
                        break;
                    case (direction.South):
                        currDir = direction.East;
                        break;
                    case (direction.West):
                        currDir = direction.South;
                        break;
                }
            }
        }
        //handles up arrow
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (currDir)
            {
                case (direction.North):
                    break;
                case (direction.East):
                    break;
                case (direction.South):
                    break;
                case (direction.West):
                    break;
                case (direction.Down):
                    break;
            }
        }
    }
}
