using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class AutonomousManager : MonoBehaviour
{
    private GameObject CurrentDrone;
    public Transform DronePosition;
    public List<DroneBehavior> droneBehaviors;
    public int maxCoin;
    private int currentCoin;
    public GameObject JoysticCanvas;
    public CanvasGroup PanelBetweenCoin;
    public CanvasGroup WinPanel;
    public Ease EaseFadeIn;
    public Ease EaseFadOut;


    private void OnEnable()
    {
        GameObject drone = null;
        foreach (var item in droneBehaviors)
        {
            if (item.GetDrone() != null)
            {
                drone = item.DroneObj;
            }
        }
        CurrentDrone = Instantiate(drone, DronePosition.position, DronePosition.rotation);
        StaticEvent.OnTriggerCoin += OnTriggerCoin;
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

    bool letcheck = false;
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
            StartCoroutine(DestroyNewCoin());
        }
        letcheck = false;
    }

    IEnumerator DestroyNewCoin()
    {
        JoysticCanvas.SetActive(false);
        PanelBetweenCoin.DOFade(1, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        Rigidbody rb = CurrentDrone.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        CurrentDrone.SetActive(false);
        yield return new WaitForSeconds(4);
        PanelBetweenCoin.DOFade(0, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1);
        CurrentDrone.SetActive(true);
        rb.constraints = RigidbodyConstraints.None;
        JoysticCanvas.SetActive(true);
    }

    IEnumerator GameWin()
    {
        JoysticCanvas.SetActive(false);
        WinPanel.gameObject.SetActive(true);
        WinPanel.DOFade(1, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        Rigidbody rb = CurrentDrone.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        CurrentDrone.SetActive(false);
    }

    public void LoadScene(string scenname)
    {
        SceneManager.LoadScene(scenname);
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

}
