using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nevigator : MonoBehaviour
{
    public Transform drone;
    public GameObject droneModel;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
      //  drone = FindObjectOfType<Drone_Engine>().gameObject.transform;
    }

    // Update is called once per frame
    //void Update()
    //{
    //   Quaternion rot = Quaternion.Euler(0, 0, drone.transform.rotation.eulerAngles.y+135.0f );
    //    this.transform.rotation = rot;
    //}
    
}
