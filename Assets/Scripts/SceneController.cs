using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public GameObject canvas;

    void Start()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
    }

    void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                canvas.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                canvas.SetActive(false);
            }
        }	
	}

    public void ResumeGame()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        StartCoroutine(ChangeScene("scene1"));
    }

    private IEnumerator ChangeScene(string sceneToLoad)
    {
        float timeToWait = GetComponent<Fading>().BeginFade(1);
        Time.timeScale = 1;
        canvas.SetActive(false);
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(sceneToLoad);
    }
}
