using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepZaMusicAlive : MonoBehaviour {

    private static GameObject instance = null;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this.gameObject;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
