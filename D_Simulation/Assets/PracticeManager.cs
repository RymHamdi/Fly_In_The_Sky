using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeManager : MonoBehaviour
{
    public CanvasGroup Console;
    public CanvasGroup Instruction;
    public CanvasGroup WinPanel;
    private GameObject CurrentDrone;
    public Transform DronePosition;
    public TextMeshProUGUI timerText;
    public List<DroneBehavior> droneBehaviors;
    public int maxCoin;
    public GameObject JoysticCanvas;
    public CanvasGroup NextCoursePanel;
    private int currentCoin;
    private bool letcheck;
    private float StartTime;
    public Ease EaseFadeIn;
    public Ease EaseFadOut;

    private void OnEnable()
    {
        StaticEvent.OnTriggerCoin += OnTriggerCoin;
        GameObject drone = null;
        foreach (var item in droneBehaviors)
        {
            if (item.GetDrone() != null)
            {
                drone = item.DroneObj;
            }
        }
        CurrentDrone = Instantiate(drone, DronePosition.position, DronePosition.rotation);
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        Instruction.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        CurrentDrone.SetActive(false);
        Instruction.DOFade(0, 3).SetEase(Ease.Linear);
        yield return new WaitForSeconds(3);
        Instruction.gameObject.SetActive(false);
        Console.gameObject.SetActive(true);
        Console.DOFade(1, 1).SetEase(Ease.Linear);
        CurrentDrone.SetActive(true);
        StartTime = Time.time;
    }


    private void OnDisable()
    {
        StaticEvent.OnTriggerCoin -= OnTriggerCoin;
    }

    private void OnTriggerCoin()
    {
        if (letcheck == false)
        {
            StartCoroutine(LetCheck());
        }
    }

    IEnumerator LetCheck()
    {
        letcheck = true;
        yield return new WaitForSeconds(0.1f);
        currentCoin++;
        if (currentCoin >= maxCoin)
        {
            // player win
            // Desactivate canvas of mvt
            // Destroy currentDrone
            StartCoroutine(GameWin());
        }
        else
        {
            //call a caroutine here
            //StartCoroutine(DestroyNewCoin());
        }
        letcheck = false;
    }

    IEnumerator GameWin()
    {
        JoysticCanvas.SetActive(false);
        NextCoursePanel.gameObject.SetActive(true);
        UpdateTimerText(Time.time - StartTime);
        NextCoursePanel.DOFade(1, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        Rigidbody rb = CurrentDrone.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        CurrentDrone.SetActive(false);
    }

    private void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100f) % 100f);

        timerText.SetText("" + string.Format("{0:00}:{1:00}", minutes, seconds));
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void FadeInPanel(CanvasGroup group)
    {
        group.gameObject.SetActive(true);
        StartCoroutine(FadeIn(group));
    }

    public void FadeOutPanel(CanvasGroup group)
    {
        group.DOFade(0, 0.3f).SetEase(EaseFadOut);
        group.gameObject.SetActive(false);
    }

    IEnumerator FadeIn(CanvasGroup group)
    {
        yield return new WaitForSeconds(Time.deltaTime);
        group.DOFade(1, 0.3f).SetEase(EaseFadeIn);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
