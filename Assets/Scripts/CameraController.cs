using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // the target we want the camera to follow/move to
    public Transform target;
    // used to smooth the camera following the player's movement
    public float smoothDelaySpeed = .06f; 

    void LateUpdate()
    {
        // Use the target's positional coordinates to create a new vector
        Vector3 calc = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        // interpolate cameras location with where the target location is
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, calc, smoothDelaySpeed);
        transform.position = smoothedPosition;
    }
}
