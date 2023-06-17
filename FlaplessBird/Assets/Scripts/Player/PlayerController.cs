using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Variables to track mouse input
    private Vector2 inputStartPosition;
    private bool isInputActive = false;

    //Variables to track touch
    private Vector2 touchStartPosition;
    private bool isSwiping = false;

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
        Rainbow_color();

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

                if (inputDirection > 0f && playerState != 3) 
                {
                    MoveRight();
                }
                else if (inputDirection < 0f && playerState != 1) 
                {
                    MoveLeft();
                }
            }

            isInputActive = false;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPosition = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Ended:
                    Vector2 swipeDelta = touch.position - touchStartPosition;
                    float swipeMagnitude = swipeDelta.magnitude;

                    if (swipeMagnitude >= 50f)
                    {
                        // Check swipe direction
                        float swipeDirection = Mathf.Sign(swipeDelta.x);

                        if (swipeDirection > 0f && playerState != 3) // Right swipe
                        {
                            MoveRight();
                        }
                        else if (swipeDirection < 0f && playerState != 1) // Left swipe
                        {
                            MoveLeft();
                        }
                    }

                    isSwiping = false;
                    break;
            }
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
        if(other.tag == "Obstacle"){
            // get current time
            float currentTime = Time.time;
            Debug.Log(currentTime);

            if(storeMgmt.getWings() == 1 && currentTime < 20.0f){
                Destroy(other.gameObject);
                
            }
            else if (storeMgmt.getHelmet() == 1){
                storeMgmt.setHelmet(0);
                Destroy(other.gameObject);
            }
            else
            {
                manager.GetComponent<Manager>().StopGame();
                storeMgmt.Reset();
            }
        }
            
        if(other.tag == "Coin"){
            manager.GetComponent<Manager>().AddCoin();
            Destroy(other.gameObject);
            if (storeMgmt.getCape() == 1){
                moneyMgmt.addMoney(2);
            }
            else
            {
                moneyMgmt.addMoney(1);
            }
        }

        
    }

    void Rainbow_color(){
        // function that gradually changes the color of the player if the Wings is bought and Time.time < 20.0f
        if (storeMgmt.getWings() == 1 && Time.time < 20.0f){
            // change color of player
            // change color of player
            float t = Mathf.PingPong(Time.time, 1.0f) / 1.0f;
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.red, Color.blue, t);
        }
        else{
            GetComponent<SpriteRenderer>().color = Color.white;
        }


    }

}
