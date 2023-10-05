using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accurancy : MonoBehaviour
{
    public Material material,oldMaterial;
    public Renderer myObj;
    public GameObject successChapter;
    // Start is called before the first frame update
    void Start()
    {
       // oldMaterial = this.GetComponent<Renderer>().material;
        if (oldMaterial == null)
            oldMaterial = myObj.GetComponent<Material>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<Renderer>().material = material;
        Invoke("success", 2.0f);
    }
    private void OnCollisionExit(Collision collision)
    {
        this.GetComponent<Renderer>().material = oldMaterial;
    }
    void success()
    {
       successChapter.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
