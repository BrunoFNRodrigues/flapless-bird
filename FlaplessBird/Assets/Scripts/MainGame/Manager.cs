using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI cointText;
    public TextMeshProUGUI finalScoreText;
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
    public AudioSource soundPlayerEnd;
    public AudioSource soundPlayerCoin;

    public GameObject deadCanvas;

    public bool stopSign = false;
    

    private void Start(){
        //cointText.text = coinCount.ToString();
    }

    private void Update()
    {
        if (!stopSign) {
            float downwardMovement = 0.7f;
            fallingDepth += downwardMovement * Time.deltaTime;
            scoreText.text = fallingDepth.ToString("F2");
        }

    }

    public void AddCoin(){
        coinCount ++;
        cointText.text = coinCount.ToString();
        soundPlayerCoin.Play();
    }

    public void StopGame(){
        
        soundPlayerEnd.Play();
        stopSign = true;
        deadCanvas.SetActive(true);
        finalScoreText.text = scoreText.text;
        CheckHighScore();
        UpdateHighScoreText();
    }

    public void RestartScene(){
        stopSign = false;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene("Menu");
    }

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    void CheckHighScore()
    {
        if(fallingDepth > PlayerPrefs.GetFloat("HighScore", 0.00f))
        {
            PlayerPrefs.SetFloat("HighScore", fallingDepth);
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = PlayerPrefs.GetFloat("HighScore", 0.00f).ToString("F2");
    }
}
