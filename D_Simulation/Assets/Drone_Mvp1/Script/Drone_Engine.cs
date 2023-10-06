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
        engineForce =  transform.up * ((rb.mass * Physics.gravity.magnitude) + (input.Throttle * maxPower * 5)) / (4f + (rb.velocity.y * Time.deltaTime * 10));
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
