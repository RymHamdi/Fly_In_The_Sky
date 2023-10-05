using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public GameObject console;
    // Start is called before the first frame update
   
    public void OnEnable()
    {
        console.SetActive(false);
        StartCoroutine(waitandDestroy());
    }
    IEnumerator waitandDestroy()
    {
        yield return new WaitForSeconds(4.0f);
        console.SetActive(true);
        GlobalTimer.Instance.StartCountUpTimer();
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}