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

    // Fixed positions
    public Transform column1;
    public Transform column2;
    public Transform column3;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inputStartPosition = Input.mousePosition;
            isInputActive = true;
        }
        else if (Input.GetMouseButtonUp(0) && isInputActive)
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
}
