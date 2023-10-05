using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class Drone_Engine : MonoBehaviour, IEngine
{
    private float currentValue;
    private float startTime;
    private float startValue = 0.0f;
    private float lerpDuration = 10.0f;
    #region Variables
    [Header("Engine Properties")]
    [SerializeField] private float maxPower = 4f;

    [Header("Propeller Properties")]
    [SerializeField] private Transform propeller;
    [SerializeField] private float propRotationSpeed = 300f;

    #endregion

    #region Interface Methods
    public void InitEngine()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateEngine(Rigidbody rb, Drone_Input input)
    {
        //Debug.Log("running engine: " + gameObject.name);
        Vector3 engineForce = Vector3.zero;
        if ( input.Throttle != 0)
        {

            // Linearly interpolate between start and end values
            currentValue = 1;
        }
        else
        {
            currentValue -= Time.deltaTime*5;
            if (currentValue < 0)
            {
                currentValue = 0;
            }
        }

        int sign;
        if (currentValue == 0)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        if (input.Throttle < 0)
        {
            sign = -1;
        }
        else
        {
            sign = 1;
        }
        engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude *sign*3) + (input.Throttle * maxPower)) / 4f;
        rb.AddForce(engineForce, ForceMode.Force);
        HandlePropellers();
    }


    void HandlePropellers()
    {
        if (!propeller) { return; }
        propeller.Rotate(Vector3.forward * propRotationSpeed);//Set Drone Fan Rotation
    }
    #endregion
    private IEnumerator LerpFloat(Drone_Input input)
    {
        while (currentValue != input.Throttle)
        {
            // Calculate the interpolation factor based on elapsed time
            float elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / lerpDuration);

            // Linearly interpolate between start and end values
            currentValue = Mathf.Lerp(startValue, input.Throttle, t);

            yield return null;
        }

        // Ensure the final value is exactly the endValue
        currentValue = input.Throttle;

        // Print or use the final value as needed
        Debug.Log("Lerp completed. Final value: " + currentValue);
    }

}
