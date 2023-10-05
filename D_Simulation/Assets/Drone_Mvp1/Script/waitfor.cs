using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitfor : MonoBehaviour
{
    
    private void OnEnable()
    {
        Invoke("deactive", 5);
    }

   void deactive()
    {
        Destroy(this.gameObject);
    }

    
}
