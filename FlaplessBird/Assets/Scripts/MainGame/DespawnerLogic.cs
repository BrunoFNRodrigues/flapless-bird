using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnerLogic : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Obstacle" || other.tag == "Coin")
            Destroy(other.gameObject);
    }

}
