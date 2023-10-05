using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.level_2();
        //this.gameObject.SetActive(false);
    }
}
