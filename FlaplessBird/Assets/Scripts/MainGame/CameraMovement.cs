using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    public bool stop = false;
    public GameObject manager;

    void Start(){
        manager = GameObject.Find("GameManager");
    }


    // Update is called once per frame
    void Update()
    {
        if(!manager.GetComponent<Manager>().stopSign)
            transform.position += new Vector3(0, -cameraSpeed * Time.deltaTime, 0);
    }
}
