using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class UISetup : MonoBehaviour
{
    public Image flashSceen;
    public CanvasGroup DroneSelectionScreen;

    private void OnEnable()
    {
        StartCoroutine(OnLOad());
        
    }

    IEnumerator OnLOad()
    {
        yield return new WaitForSeconds(1.0f);
        flashSceen.DOFade(0, 2);
        yield return new WaitForSeconds(2);
        DroneSelectionScreen.DOFade(1, 2);
    }

    public void FadeInPanel(CanvasGroup group)
    {
        StartCoroutine(FadeIn(group));
    }

    public void FadeOutPanel(CanvasGroup group)
    {
        group.DOFade(0, 2);
    }

    IEnumerator FadeIn(CanvasGroup group)
    {
        yield return new WaitForSeconds(2.0f);
        group.DOFade(1, 2);
    }
}
