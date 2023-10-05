using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step6 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.level_6();
        this.gameObject.SetActive(false);
    }
}
