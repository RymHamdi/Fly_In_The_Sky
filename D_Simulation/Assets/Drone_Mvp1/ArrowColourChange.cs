using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowColourChange : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0, 1);
    }
}
