using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngleController : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] Transform cameraAngleCorridor1;
    [SerializeField] Transform cameraAngleCorridor2;
    [SerializeField] Transform cameraAngleRoomMain;
    private bool isInCorridor1 = true;
    private bool isInCorridor2 = false;
    private bool isInRoomMain = true;

    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float rotateSpeed = 20.0f;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (isInRoomMain)
        {
            Quaternion lerpedRotation = Quaternion.RotateTowards(cameraTransform.rotation, cameraAngleRoomMain.rotation, Time.deltaTime * rotateSpeed);
            lerpedRotation.x = 0; lerpedRotation.z = 0;
            transform.rotation = lerpedRotation;
        }
        if (isInCorridor1)
        {
            Quaternion lerpedRotation = Quaternion.RotateTowards(cameraTransform.rotation, cameraAngleCorridor1.rotation, Time.deltaTime * rotateSpeed);
            lerpedRotation.x = 0; lerpedRotation.z = 0;
            transform.rotation = lerpedRotation;
        }
        if (isInCorridor2)
        {
            Quaternion lerpedRotation = Quaternion.RotateTowards(cameraTransform.rotation, cameraAngleCorridor2.rotation, Time.deltaTime * rotateSpeed);
            lerpedRotation.x = 0; lerpedRotation.z = 0;
            transform.rotation = lerpedRotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("roomMain") && (isInCorridor1 || isInCorridor2))
        {
            isInCorridor1 = false;
            isInCorridor2 = false;
            isInRoomMain = true;
        }

        if (other.CompareTag("corridor1") && isInRoomMain)
        {
            isInRoomMain = false;
            isInCorridor1 = true;
        }

        if (other.CompareTag("corridor2") && isInRoomMain)
        {
            isInRoomMain = false;
            isInCorridor2 = true;
        }
    }
}
