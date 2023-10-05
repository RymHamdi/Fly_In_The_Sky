using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    private bool level2=false;
    private Transform _dronePos;
    public float targetRotation = 270f;
    public float rotationThreshold = 1f;

    private float totalRotation;
    private void OnEnable()
    {
        _dronePos = FindObjectOfType<Drone_Input>().transform;
         level2 = true;
    }
    private void Update()
    {
        if (level2)
        {
            // Get the current rotation of the GameObject around the y-axis
            float currentRotation = _dronePos.transform.eulerAngles.y;

            // Calculate the difference in rotation between the current and previous frame
            float rotationDelta = Mathf.DeltaAngle(currentRotation, totalRotation);

            // Add the rotation delta to the total rotation
            totalRotation += rotationDelta;

            // Ensure totalRotation stays within the range of 0 to 360 degrees
            totalRotation = Mathf.Repeat(totalRotation, 360f);

            // Check if the total rotation is within the threshold of the target rotation
            if (Mathf.Abs(totalRotation - targetRotation) <= rotationThreshold)
            {
                // The GameObject has completed a full rotation from 0 to 270 degrees
                level2 = false;
                UIManager.instance.Level2_Complete();
            //    GameManager.instance.Level2_Complete();
                Debug.Log("Object has completed a full rotation!");
            }
        }
    }
}
