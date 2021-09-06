using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    private Transform cameraTransform;
    private Quaternion originalRotation;
    public void Start()
    {
        originalRotation = transform.rotation;
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

    }
    private void Update()
    {
        transform.LookAt(cameraTransform);
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y, 0);
    }
    
}
