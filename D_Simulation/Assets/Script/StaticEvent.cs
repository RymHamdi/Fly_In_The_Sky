using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEvent
{
    public delegate void AssignDrone(Transform Drone);

    public static event AssignDrone OnAssignDrone;

    public delegate void TriggerCoin();
    public static event TriggerCoin OnTriggerCoin;
    
    public static void CallAssignDrone(Transform Drone)
    {
        OnAssignDrone?.Invoke(Drone);
    }

    public static void CallTriggerCoin()
    {
        OnTriggerCoin?.Invoke();
    }
}
