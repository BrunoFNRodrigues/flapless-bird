using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public bool stop = false;

    // Update is called once per frame
    void Update()
    {
        if(!stop)
            transform.position += new Vector3(0, -cameraSpeed * Time.deltaTime, 0);
    }
}
