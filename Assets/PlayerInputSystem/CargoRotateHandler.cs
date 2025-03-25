using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoRotateHandler : MonoBehaviour
{
    [SerializeField] GameObject cargo;
    private Quaternion rotatonBase;
    [SerializeField] float rotateSpeed = 0.5f;
    private void Start()
    {
        rotatonBase = cargo.transform.rotation;
    }
    public void RotationControl()
    {
       cargo.transform.rotation = rotatonBase;
     
    }
    public void RotationLeft()
    {
        StartCoroutine(RotateOverTime(90, rotateSpeed));
    }
    public void RotationRight()
    {
        StartCoroutine(RotateOverTime(-90, rotateSpeed));
    }
    private IEnumerator RotateOverTime(float angle, float duration)
    {
        Quaternion startRotation = cargo.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, -angle, 0); // Rotate left

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            cargo.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        cargo.transform.rotation = endRotation; // Ensure the final rotation is set
    }
}
