using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Manager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI cointText;
    private Rigidbody2D rb;

    private float fallingDepth = 0f;
    public int coinCount;

    public GameObject treeSpawner;
    public GameObject birdSpawner1;
    public GameObject birdSpawner2;
    public GameObject coinSpawner1;
    public GameObject coinSpawner2;
    public GameObject coinSpawner3;
    public GameObject camera;
    public GameObject background;

    public bool stopSign = false;

    private void Start(){
        cointText.text = coinCount.ToString();
    }

    private void Update()
    {
        float downwardMovement = 0.7f;
        fallingDepth += downwardMovement * Time.deltaTime;
        scoreText.text = fallingDepth.ToString("F2");
    }

    public void AddCoin(){
        coinCount ++;
        cointText.text = coinCount.ToString();
    }

    public void StopGame(){
        stopSign = true;
        treeSpawner.GetComponent<SpawnerManager>().stop = true;
        birdSpawner1.GetComponent<SpawnerManager>().stop = true;
        birdSpawner2.GetComponent<SpawnerManager>().stop = true;
        coinSpawner1.GetComponent<SpawnerManager>().stop = true;
        coinSpawner2.GetComponent<SpawnerManager>().stop = true;
        coinSpawner3.GetComponent<SpawnerManager>().stop = true;

        camera.GetComponent<CameraMovement>().stop = true;
        background.GetComponent<BackgroundLoop>().stop = true;
    }

}
