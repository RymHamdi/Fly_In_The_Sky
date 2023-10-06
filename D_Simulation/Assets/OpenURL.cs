using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenURL : MonoBehaviour, IPointerClickHandler
{
    // The URL you want to open
    public string url = "https://smartstore.naver.com/cocodroneshop";

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(url);
    }
}
