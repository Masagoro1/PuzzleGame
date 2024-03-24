using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalCam : MonoBehaviour
{
    [SerializeField]
    float t = 5;
    [SerializeField]
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + new Vector3(10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * Mathf.PI *0.02f * t;
        transform.position = player.position + new Vector3(10f*t * Mathf.Cos(t), -0.2f * t, 10f*t * Mathf.Sin(t));
        transform.LookAt(player.position);
        if(t > 33)
        {
            Application.Quit();
        }
    }
}
