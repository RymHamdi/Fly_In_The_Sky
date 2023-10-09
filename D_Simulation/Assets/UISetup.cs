using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class UISetup : MonoBehaviour
{
    public CanvasGroup flashSceen;
    public CanvasGroup DroneSelectionScreen;
    public Ease EaseFadeIn;
    public Ease EaseFadOut;

    private void OnEnable()
    {
        StartCoroutine(OnLOad());
        
    }

    IEnumerator OnLOad()
    {
        flashSceen.DOFade(1, 0.5f).SetEase(EaseFadeIn);
        yield return new WaitForSeconds(1.0f);
        flashSceen.DOFade(0, 1).SetEase(EaseFadOut);
        yield return new WaitForSeconds(1);
        DroneSelectionScreen.gameObject.SetActive(true);
        DroneSelectionScreen.DOFade(1, 1).SetEase(EaseFadeIn);
    }

    public void FadeInPanel(CanvasGroup group)
    {
        group.gameObject.SetActive(true);
        StartCoroutine(FadeIn(group));
    }

    public void FadeOutPanel(CanvasGroup group)
    {
        group.DOFade(0, 1).SetEase(EaseFadOut);
        group.gameObject.SetActive(false);
    }

    IEnumerator FadeIn(CanvasGroup group)
    {
        yield return new WaitForSeconds(1.0f);
        group.DOFade(1, 1).SetEase(EaseFadeIn);
    }
}
