using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEvent
{
    public delegate void AssignDrone(Transform Drone);

    public static event AssignDrone OnAssignDrone;
    
    public static void CallAssignDrone(Transform Drone)
    {
        OnAssignDrone?.Invoke(Drone);
    }
}
