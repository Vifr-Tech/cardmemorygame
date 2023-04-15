using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickSquare : MonoBehaviour
{
    private int turnSpeed = 200;
    public bool shouldTurn = false;
    public bool faceUp = false;
    public static int turnedSquares = 0;

    private void Start()
    {
        turnedSquares = 0;
    }

    void OnMouseUp()
    {
        if(Time.timeScale != 0)
        {
            if (!shouldTurn)
            {
                shouldTurn = true;
                if (!faceUp)
                {
                    turnedSquares++;
                }
            }
        } 
    }

    void Update()
    {
        if (turnedSquares > 2)
        {
            if (faceUp)
            {
                shouldTurn = true;
            }
        }

        if (shouldTurn)
        {
            if (faceUp)
            {
                hideSquare();
            }
            else
            {
                showSquare();
            }
        }
        
        if(turnedSquares == 2)
        {
           this.GetComponent<DestroyGuessedCubes>().CheckCubes();
        }
    }

    void hideSquare()
    {
        transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime);
        if (transform.eulerAngles.y <= 4 && transform.eulerAngles.y >= -4)
        {
            transform.rotation = Quaternion.identity;
            turnedSquares--;
            shouldTurn = false;
            faceUp = false;
            print(turnedSquares);
        }
    }

    void showSquare()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        if (transform.eulerAngles.y >= 180)
        {
            faceUp = true;
            shouldTurn = false;
            print(turnedSquares);
        }
    }
}
