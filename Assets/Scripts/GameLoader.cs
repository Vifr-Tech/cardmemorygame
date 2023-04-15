using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour {

	public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel1()
    {
        StartCoroutine(LoadFirstLevel());
    }

    private IEnumerator LoadFirstLevel()
    {
        float timeToWait = GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("scene1");
    }
}
