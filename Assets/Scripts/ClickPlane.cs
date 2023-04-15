using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPlane : MonoBehaviour {
    public bool faceUp;

    private void Update()
    {
        faceUp = transform.parent.GetComponent<ClickSquare>().faceUp;
    }

    void OnMouseUp()
    {
        if (Time.timeScale != 0)
        {
            transform.parent.GetComponent<ClickSquare>().shouldTurn = true;
        }
    } 
}
