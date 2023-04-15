using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material[] skyboxes;
    System.Random numGen = new System.Random();

    void Awake()
    {
        int x = numGen.Next(0, skyboxes.Length);
        RenderSettings.skybox = skyboxes[x];
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.25f);
    }
}
