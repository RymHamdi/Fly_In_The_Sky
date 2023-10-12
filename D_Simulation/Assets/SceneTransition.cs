using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneTransition : MonoBehaviour
{
    public Image FillImage;

    private void Start()
    {
        LoadScene("StartScene");
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        // Play the transition animation

        // Wait for a short duration to allow the transition animation to play
        yield return new WaitForSeconds(1.0f);

        // Load the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            print("heee");
            FillImage.fillAmount += asyncLoad.progress*Time.deltaTime;
            yield return null;
        }
    }
}
