using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;
    public bool stop = false;
    public GameObject manager;

    void Start(){
        manager = GameObject.Find("GameManager");
    }

    void Update(){
        if(!manager.GetComponent<Manager>().stopSign)
            backgroundRenderer.material.mainTextureOffset += new Vector2(0f, -backgroundSpeed * Time.deltaTime);
    }
}
