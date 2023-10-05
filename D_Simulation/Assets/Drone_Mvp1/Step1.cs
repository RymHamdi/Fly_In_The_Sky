using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step1 : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.level_1();
        this.gameObject.SetActive(false);
    }
}
