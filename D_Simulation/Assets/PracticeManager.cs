using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeManager : MonoBehaviour
{
    public CanvasGroup Console;
    public CanvasGroup Instruction;
    private GameObject CurrentDrone;
    public Transform DronePosition;
    public List<DroneBehavior> droneBehaviors;
    public int maxCoin;
    public GameObject JoysticCanvas;
    public CanvasGroup NextCoursePanel;
    private int currentCoin;
    private bool letcheck;

    private void OnEnable()
    {
        StaticEvent.OnTriggerCoin += OnTriggerCoin;
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        Instruction.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        Instruction.DOFade(0, 3).SetEase(Ease.Linear);
        
        yield return new WaitForSeconds(3);
        Instruction.gameObject.SetActive(false);
        Console.gameObject.SetActive(true);
        Console.DOFade(1, 1).SetEase(Ease.Linear);
        GameObject drone = null;
        foreach (var item in droneBehaviors)
        {
            if (item.GetDrone() != null)
            {
                drone = item.DroneObj;
            }
        }
        CurrentDrone = Instantiate(drone, DronePosition.position, DronePosition.rotation);
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
        NextCoursePanel.DOFade(1, 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.1f);
        Rigidbody rb = CurrentDrone.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        CurrentDrone.SetActive(false);
    }

}
