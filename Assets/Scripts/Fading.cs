﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    public float fadeSpeed = 0.5f;
    public Texture overlayTexture;

    private int drawDepth = -500;
    private float alpha = 1.0f;
    private int fadeDir = -1; // to fade in => fadeDir = -1; to fade out => fadeDir = 1;

    private void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), overlayTexture);
    }

    public float BeginFade(int dir)
    {
        fadeDir = dir;
        return fadeSpeed;
    }

    private void OnLevelWasLoaded(int level)
    {
        BeginFade(-1);
    }

}
