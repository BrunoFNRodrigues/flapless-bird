using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Variables to track touch/mouse input
    private Vector2 inputStartPosition;
    private bool isInputActive = false;

    public int playerState = 2;

    // Movement speed
    public float moveSpeed = 5f;

    public MoneyMgmt moneyMgmt;
    public StoreMgmt storeMgmt;

    // Fixed positions
    public Transform column1;
    public Transform column2;
    public Transform column3;

    public GameObject manager;

    void Start(){
        manager = GameObject.Find("GameManager");
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !manager.GetComponent<Manager>().stopSign)
        {
            inputStartPosition = Input.mousePosition;
            isInputActive = true;
        }
        else if (Input.GetMouseButtonUp(0) && isInputActive && !manager.GetComponent<Manager>().stopSign)
        {
            Vector2 inputEndPosition = Input.mousePosition;
            Vector2 inputDelta = inputEndPosition - inputStartPosition;
            float inputMagnitude = inputDelta.magnitude;

            if (inputMagnitude >= 50f)
            {
                float inputDirection = Mathf.Sign(inputDelta.x);

                if (inputDirection > 0f && playerState != 3) // Right swipe
                {
                    MoveRight();
                }
                else if (inputDirection < 0f && playerState != 1) // Left swipe
                {
                    MoveLeft();
                }
            }

            isInputActive = false;
        }
    }

    private void MoveRight()
    {   
        if(playerState == 1){
            transform.position = new Vector2(column2.position.x, column2.position.y);
        }
        else if(playerState == 2){
            transform.position = new Vector2(column3.position.x, column3.position.y);
        }
        playerState += 1;
    }

    private void MoveLeft()
    {
        if(playerState == 3){
            transform.position = new Vector2(column2.position.x, column2.position.y);
        }
        else if(playerState == 2){
            transform.position = new Vector2(column1.position.x, column1.position.y);
        }
        playerState -= 1;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Obstacle")
            if(storeMgmt.helmet == 1){
                storeMgmt.helmet = 0;
                Destroy(other.gameObject);
            }
            else
            {
                manager.GetComponent<Manager>().StopGame();
            }
        if(other.tag == "Coin"){
            manager.GetComponent<Manager>().AddCoin();
            Destroy(other.gameObject);
            if (storeMgmt.cape == 1){
                moneyMgmt.addMoney(2);
            }
            else
            {
                moneyMgmt.addMoney(1);
            }
        }
    }

}
