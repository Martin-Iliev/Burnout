using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] Transform cameraAngleCorridor1;
    [SerializeField] Transform cameraAngleCorridor2;
    [SerializeField] Transform cameraAngleRoomMain;
    [SerializeField] GameObject lightsCorridor1;
    [SerializeField] GameObject lightsCorridor2;
    [SerializeField] GameObject lightsRoomMain;
    [SerializeField] GameObject chargingStation1;
    [SerializeField] GameObject chargingStation2;
    private bool isInCorridor1 = true;
    private bool isInCorridor2 = false;
    private bool isInRoomMain = true;
    private bool pickedUpStation = false;
    private bool placedStation = false;


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
            lightsRoomMain.SetActive(true);
            lightsCorridor1.SetActive(false);
            lightsCorridor2.SetActive(false);
        }
        if (isInCorridor1)
        {
            Quaternion lerpedRotation = Quaternion.RotateTowards(cameraTransform.rotation, cameraAngleCorridor1.rotation, Time.deltaTime * rotateSpeed);
            lerpedRotation.x = 0; lerpedRotation.z = 0;
            transform.rotation = lerpedRotation;
            lightsRoomMain.SetActive(false);
            lightsCorridor1.SetActive(true);
            lightsCorridor2.SetActive(false);
        }
        if (isInCorridor2)
        {
            Quaternion lerpedRotation = Quaternion.RotateTowards(cameraTransform.rotation, cameraAngleCorridor2.rotation, Time.deltaTime * rotateSpeed);
            lerpedRotation.x = 0; lerpedRotation.z = 0;
            transform.rotation = lerpedRotation;
            lightsRoomMain.SetActive(false);
            lightsCorridor1.SetActive(false);
            lightsCorridor2.SetActive(true);
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

        if (other.CompareTag("chargingStation1") && !pickedUpStation)
        {
            chargingStation1.SetActive(false);
            pickedUpStation = true;
        }
        
        if (other.CompareTag("chargingStation2") && !placedStation)
        {
            chargingStation2.SetActive(true);
            placedStation = true;
        }

    }
}
