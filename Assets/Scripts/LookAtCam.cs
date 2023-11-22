using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookAtCam : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(cameraTransform.position.x, cameraTransform.position.y, cameraTransform.position.z);
        
        transform.LookAt(targetPosition);
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.x = 0;
        eulerAngles.z = 0;
        eulerAngles.y = eulerAngles.y + 180;

        transform.rotation = Quaternion.Euler(eulerAngles);
    }
}