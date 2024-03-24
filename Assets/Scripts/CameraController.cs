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
    Transform[] camPos;
    direction currDir = direction.North;
    [SerializeField]
    direction currRot;
    Vector3 dest;
    [SerializeField]
    float w = 0;
    [SerializeField]
    float wTarg = 0, wStart;
    [SerializeField]
    float u = 0;
    [SerializeField]
    float t = 3/2 * Mathf.PI;
    [SerializeField]
    float tTarg = 3 / 2 * Mathf.PI;
    [SerializeField]
    float camDist;
    [SerializeField]
    float tStart;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(u < 1)
        {
            u += 1 * Time.deltaTime;
        }
        else
        {
            if(u > 1)
            {
                u = 1;
            }
        }
        if (w == wTarg)
        {
            wStart = w;
        }
        if (t == tTarg)
        {
            tStart = t;
        }
        if (t == tTarg && w == wTarg)
        {
            //Handles Left arrow
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (currDir < direction.Down)
                {
                    if (currDir == direction.West)
                    {
                        currDir = direction.North;
                    }
                    else
                    {
                        currDir = (direction)((int)currDir + 1);
                    }
                }
                else
                {
                    switch (currRot)
                    {
                        case (direction.North):
                            currDir = direction.East;
                            break;
                        case (direction.East):
                            currDir = direction.South;
                            break;
                        case (direction.South):
                            currDir = direction.West;
                            break;
                        case (direction.West):
                            currDir = direction.North;
                            break;
                    }
                }
                lerpPos();
                Debug.Log(currDir);
            }
            //handles Right arrow
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (currDir < direction.Down)
                {
                    if (currDir == direction.North)
                    {
                        currDir = direction.West;
                    }
                    else
                    {
                        currDir = (direction)((int)currDir - 1);
                    }

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
                lerpPos();
                Debug.Log(currDir);
            }
            //handles up arrow
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (currDir)
            {
                case (direction.North):
                    currDir = direction.Down;
                    currRot = direction.North;
                    break;
                case (direction.East):
                    currDir = direction.Down;
                    currRot = direction.East;
                    break;
                case (direction.South):
                    currDir = direction.Down;
                    currRot = direction.South;
                    break;
                case (direction.West):
                    currDir = direction.Down;
                    currRot = direction.West;
                    break;
                case (direction.Down):
                    switch (currRot)
                    {
                        case (direction.North):
                            currDir = direction.South;
                            break;
                        case (direction.East):
                            currDir = direction.West;
                            break;
                        case (direction.South):

                            currDir = direction.North;
                            break;
                        case (direction.West):

                            currDir = direction.East;
                            break;
                    }
                    break;
            }
            lerpPos();
            Debug.Log(currDir);
        }
        //down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currDir == direction.Down)
            {
                switch (currRot)
                {
                    case (direction.North):
                        currDir = direction.North;
                        break;
                    case (direction.East):
                        currDir = direction.East;
                        break;
                    case (direction.South):
                        currDir = direction.South;
                        break;
                    case (direction.West):
                        currDir = direction.West;
                        break;
                }
            }

            lerpPos();
            Debug.Log(currDir);
        }
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(new Vector3(Mathf.Cos(t), 0, Mathf.Sin(t)));
            Debug.Log(tStart);
            Debug.Log(tTarg);
            Debug.Log(t);
        }
        
        t = Mathf.Lerp(tStart, tTarg, u);
        w = Mathf.Lerp(wStart, wTarg, u);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(new Vector3(Mathf.Cos(t), 0, Mathf.Sin(t)));
        }
        if(wStart == 0.5f * Mathf.PI || wTarg == 0.5f * Mathf.PI)
        {
            if((currDir == direction.North || currDir == direction.South) || ((currRot == direction.North || currRot == direction.South) && (currDir == direction.Down)))
            {
                transform.position = player.position + new Vector3(0, camDist * Mathf.Sin(w) + 1, camDist * Mathf.Cos(w));
            }
            else
            {
                transform.position = player.position + new Vector3(camDist * Mathf.Cos(w), camDist * Mathf.Sin(w) + 1, 0);
            }
        }
        else
        {

            transform.position = player.position + new Vector3(camDist * Mathf.Cos(t), 1, camDist * Mathf.Sin(t));
        }
        if(transform.position == player.position + new Vector3(0, camDist + 1, 0))
        {
            switch (currRot)
            {
                case (direction.North):
                    transform.rotation = Quaternion.Euler(90, 0, 0);
                    break;
                case (direction.East):
                    transform.rotation = Quaternion.Euler(90, 90, 0);
                    break;
                case (direction.South):
                    transform.rotation = Quaternion.Euler(90, 180, 0);
                    break;
                case (direction.West):
                    transform.rotation = Quaternion.Euler(90, 270, 0);
                    break;
            }
            
        }
        else
        {
            transform.LookAt(new Vector3(player.position.x, player.position.y + 1, player.position.z));
        }


        
    }
    
    void lerpPos()
    {
        
        if (wStart == 0.5f * Mathf.PI)
        {
            switch (currDir)
            {
                case (direction.North):
                    wTarg = Mathf.PI;
                    tTarg = 1.5f * Mathf.PI;
                    break;
                case (direction.East):
                    wTarg = Mathf.PI;
                    tTarg = Mathf.PI;
                    break;
                case (direction.South):
                    wTarg = 0;
                    tTarg = 0.5f * Mathf.PI;
                    break;
                case (direction.West):
                    wTarg = 0;
                    tTarg = 2f * Mathf.PI;
                    break;
            }
        }
        else
        {
            w = 0;
            wStart = 0;
            wTarg = 0;
            switch (currDir)
            {
                case (direction.North):
                    if (t == 0)
                    {

                        tStart = 2f * Mathf.PI;
                        t = 2f * Mathf.PI;
                    }
                    tTarg = 1.5f * Mathf.PI;
                    break;
                case (direction.East):
                    tTarg = Mathf.PI;
                    break;
                case (direction.South):
                    if (t == 2f * Mathf.PI)
                    {

                        tStart = 0;
                        t = 2f * Mathf.PI;
                    }
                    tTarg = 0.5f * Mathf.PI;
                    break;
                case (direction.West):
                    if (t < 2)
                    {
                        tTarg = 0;
                    }
                    else
                    {

                        tTarg = 2f * Mathf.PI;
                    }
                    break;
                case (direction.Down):
                    wTarg = 0.5f * Mathf.PI;
                    if (currRot == direction.North || currRot == direction.East)
                    {
                        wStart = Mathf.PI;
                    }
                    else
                    {
                        wStart = 0f;
                    }
                    break;
            }
        }
        player.GetComponent<playerController>().pubDir = (int)currDir;
        player.GetComponent<playerController>().pubRot = (int)currRot;
        u = 0;
    }
}


