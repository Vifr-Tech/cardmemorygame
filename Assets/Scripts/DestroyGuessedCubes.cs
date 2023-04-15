using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGuessedCubes : MonoBehaviour
{

    public GameObject destroyEffect;

    public void CheckCubes()
    {
        GameObject[] allPlanes = GameObject.FindGameObjectsWithTag("ImageSide");
        List<GameObject> turnedPlanes = new List<GameObject>();
        foreach (GameObject go in allPlanes)
        {
            if (go.GetComponent<ClickPlane>().faceUp)
            {
                turnedPlanes.Add(go);
            }
        }
        if (turnedPlanes.Count == 2)
        {
            if (turnedPlanes[0].GetComponent<Renderer>().material.mainTexture == turnedPlanes[1].GetComponent<Renderer>().material.mainTexture)
            {
                GameObject effect1 = Instantiate(destroyEffect, turnedPlanes[0].transform.position, turnedPlanes[0].transform.rotation);
                Destroy(turnedPlanes[0].transform.parent.gameObject);

                GameObject effect2 = Instantiate(destroyEffect, turnedPlanes[1].transform.position, turnedPlanes[1].transform.rotation);
                Destroy(turnedPlanes[1].transform.parent.gameObject);

                Destroy(effect1, 2);
                Destroy(effect2, 2);
                ClickSquare.turnedSquares = 0;
            }
        }
    }
}
