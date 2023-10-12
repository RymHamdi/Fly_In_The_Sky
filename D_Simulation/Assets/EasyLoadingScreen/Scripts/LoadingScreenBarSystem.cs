using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreenBarSystem : MonoBehaviour {

    public GameObject bar;
    public Text loadingText;
    public bool backGroundImageAndLoop;
    public float LoopTime;
    public GameObject[] backgroundImages;
    [Range(0,1f)]public float vignetteEfectVolue; // Must be a value between 0 and 1
    Image vignetteEfect;


    public void loadingScreen (int sceneNo)
    {
        //this.gameObject.SetActive(true);
        //StartCoroutine(Loading(sceneNo));
    }

    // Used to try. Delete the comment lines (25 and 36)
    /*
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bar.transform.localScale += new Vector3(0.001f,0,0);

            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");
        }
    }
    */
    private void OnEnable()
    {
        
    }

    private void Start()
    {
        vignetteEfect = transform.Find("VignetteEfect").GetComponent<Image>();
        vignetteEfect.color = new Color(vignetteEfect.color.r,vignetteEfect.color.g,vignetteEfect.color.b,vignetteEfectVolue);
        //loadingScreen(1);
        LoadScene("StartScene");
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Loading(sceneName));
    }

    // The pictures change according to the time of
    IEnumerator transitionImage ()
    {
        for (int i = 0; i < backgroundImages.Length; i++)
        {
            yield return new WaitForSeconds(LoopTime);
            for (int j = 0; j < backgroundImages.Length; j++)
                backgroundImages[j].SetActive(false);
            backgroundImages[i].SetActive(true);           
        }
    }

    // Activate the scene 
    IEnumerator Loading (string sceneName)
    {

        yield return new WaitForSeconds(1.0f);

        // Load the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        float x = 0;
        // Wait until the scene is fully loaded
        while (!asyncLoad.isDone)
        {
            print("heee");
            bar.transform.localScale = new Vector3(asyncLoad.progress, 0.9f, 1);
            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");
            yield return null;
        }

            // Continue until the installation is completed
       
    }

}
