using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step5 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.level_5();
        this.gameObject.SetActive(false);
    }
}
