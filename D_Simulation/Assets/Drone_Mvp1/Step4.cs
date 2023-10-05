using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step4 : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.level_4();
        //this.gameObject.SetActive(false);
    }
}
