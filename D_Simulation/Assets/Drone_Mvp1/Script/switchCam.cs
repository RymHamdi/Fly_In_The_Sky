using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCam : MonoBehaviour
{
    public Camera mainCam, droneCam,mapViwe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SwitchCamera()
    {
        if (mainCam.isActiveAndEnabled)
        {
            mainCam.gameObject.SetActive(false);
            droneCam.gameObject.SetActive(true);
            mapViwe.gameObject.SetActive(false);
        }
        else if(droneCam.isActiveAndEnabled) {
            mapViwe.gameObject.SetActive(true);
            droneCam.gameObject.SetActive(false);
            mainCam.gameObject.SetActive(false);
        }
        else
        {
            mainCam.gameObject.SetActive(true);
            droneCam.gameObject.SetActive(false);
            mapViwe.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
