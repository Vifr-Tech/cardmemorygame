using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSelector : MonoBehaviour
{

    public Texture[] allImages;
    private List<Texture> pickedImages = new List<Texture>();
    System.Random numGen = new System.Random();
    List<GameObject> cubes = new List<GameObject>();

    void Awake()
    {
        pickImagesFromList();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("ImageSide"))
        {
            cubes.Add(go);
        }
        foreach (Texture img in pickedImages)
        {
            for (int i = 1; i <= 2; i++)
            {
                if (cubes.Count != 0)
                {
                    int x = numGen.Next(0, cubes.Count);
                    cubes[x].GetComponent<Renderer>().material.mainTexture = img;
                    cubes.RemoveAt(x);
                }
            }
        }
    }

    void pickImagesFromList()
    {
        List<int> usedNums = new List<int>();
        while (usedNums.Count <= 8)
        {
            int x = numGen.Next(0, allImages.Length);
            if (!usedNums.Contains(x))
            {
                pickedImages.Add(allImages[x]);
                usedNums.Add(x);
            }
        }
    }

}
