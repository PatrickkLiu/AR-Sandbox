using UnityEngine;
using System.Collections;
 
public class CameraFacingBillboard : MonoBehaviour
{
    public Camera facingCamera;// define a camera to face 
 
    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(transform.position + facingCamera.transform.rotation * Vector3.forward,
            facingCamera.transform.rotation * Vector3.up);
    }
}