using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float cameraSpeed;
    public bool stop = false;
    public GameObject manager;
    // public StoreMgmt storeMgmt;

    void Start(){
        manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(!manager.GetComponent<Manager>().stopSign){
            // if(storeMgmt.getUmbrella() == 1){
            //     transform.position += new Vector3(0, cameraSpeed * Time.deltaTime * 0.5f, 0);
            // }
            // else{
            //     transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);
            //
            transform.position += new Vector3(0, cameraSpeed * Time.deltaTime, 0);
        }
            
    }
}
