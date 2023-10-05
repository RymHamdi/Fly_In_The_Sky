using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step3 : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.level_3();
        this.gameObject.SetActive(false);
    }
}
