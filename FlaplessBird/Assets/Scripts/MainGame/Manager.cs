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

}
