﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Drone_Input))]
public class Drone_Controller : Drone_RigidBody
{
    #region Variables
    [Header("Control Properties")]
    [SerializeField] private float minMaxPitch = 30f;
    [SerializeField] private float minMaxRoll = 30f;
    [SerializeField] private float yawPower = 4f;
    [SerializeField] private float lerpSpeed = 2f;
    private Drone_Input input;

    private List<IEngine> engines = new List<IEngine>();
    private float yaw;
    private float finalPitch;
    private float finalRoll;
    private float finalYaw;
    #endregion

    #region main methods
    void Start()
    {
        input = GetComponent<Drone_Input>();
        engines = GetComponentsInChildren<IEngine>().ToList<IEngine>();
        StaticEvent.CallAssignDrone(transform);
    }

    #endregion

    #region custom method
    protected override void HandlePysics()
    {
        HandleEngines();
        HandleControls();
    }

    protected virtual void HandleEngines()
    {
        // rb.AddForce(Vector3.up * (rb.mass * Physics.gravity.magnitude));
        foreach (IEngine engine in engines)
        {
            engine.UpdateEngine(rb, input);
        }
    }
    protected virtual void HandleControls()
    {
        float pitch = input.Cyclic.y * minMaxPitch;
        float roll = -input.Cyclic.x * minMaxRoll;
        
        yaw += input.Pedals * yawPower;

        finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
        finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
        finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed * Time.deltaTime * 20);
        //if (input.Throttle == 0)
        //{
        //    finalYaw = 1;
        //}

        Quaternion rot = Quaternion.Euler(finalPitch/2, finalYaw, finalRoll);
        rb.MoveRotation(rot);
        rb.velocity += input.Cyclic.y * (transform.forward + transform.up / 10) * Time.deltaTime * 5;
        //rb.velocity += transform.up * Time.deltaTime;
    }

    #endregion
}
