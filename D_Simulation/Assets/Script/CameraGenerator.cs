using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraGenerator : MonoBehaviour
{
    public CinemachineVirtualCamera Currentcamera;
    private void OnEnable()
    {
        StaticEvent.OnAssignDrone += OnAssignDrone;
    }

    private void OnAssignDrone(Transform Drone)
    {
        Currentcamera.LookAt = Drone;
        Currentcamera.Follow = Drone;
    }

    private void OnDisable()
    {
        StaticEvent.OnAssignDrone -= OnAssignDrone;
    }
}
