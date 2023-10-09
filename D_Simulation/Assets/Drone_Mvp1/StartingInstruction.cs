using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingInstruction : MonoBehaviour
{
    public GameObject step1,step2,step3;

    // Start is called before the first frame update
    void Start()
    {
      //  StartCoroutine(xyz());
    }

    public void close()
    {
        SceneManager.LoadScene(1);
    }
    

    IEnumerator xyz()
    {
        step1.SetActive(true);
        step2.SetActive(false);
        step3.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        step1.SetActive(false);
        step2.SetActive(true);
        step3.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        step1.SetActive(false);
        step2.SetActive(false);
        step3.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame

    public void SetCurrentDrone(string currentDrone)
    {
        PlayerPrefs.SetString("currentDrone", currentDrone);
    }
}
