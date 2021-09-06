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
        gameObject.transform.rotation = cameraTransform.rotation * originalRotation;
    }
    
}
