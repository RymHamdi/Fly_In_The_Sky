using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]
public class Drone_Input : MonoBehaviour
{
    #region Variables
    private Vector2 cyclic;
    private float pedals;
    private float throttle;

    public Vector2 Cyclic { get => cyclic; }
    public float Pedals { get => pedals; }
    public float Throttle { get => throttle; }

    #endregion

    private void OnEnable()
    {
        StaticEvent.OnTriggerCoin += ResetInputAxes;
    }

    private void OnDisable()
    {
        StaticEvent.OnTriggerCoin -= ResetInputAxes;
    }

    #region Main Methods
    // Update is called once per frame
    void Update()
    {

    }
    #endregion


    #region Input Methods
    private void OnCyclic(InputValue value)
    {
        
        cyclic = value.Get<Vector2>();
        Debug.Log("hey broo is Cyclic" + cyclic);
    }
    private void OnPedals(InputValue value)
    {
        pedals = value.Get<float>();
        Debug.Log("hey broo is pedals " + pedals);
    }
    private void OnThrottle(InputValue value)
    {
        throttle = value.Get<float>();
        Debug.Log("hey broo is throll " + throttle);
    }
    #endregion

    public void ResetInputAxes()
    {
        cyclic = Vector2.zero;
        pedals = 0;
        throttle = 0;
    }
}
