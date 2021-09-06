using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (float)0.1);
        }
        if (Input.GetKey("a"))
        {
            transform.position = new Vector3(transform.position.x - (float)0.1, transform.position.y, transform.position.z);
        }
        if (Input.GetKey("s"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (float)0.1);
        }
        if (Input.GetKey("d"))
        {
            transform.position = new Vector3(transform.position.x + (float)0.1, transform.position.y, transform.position.z);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            GetComponent<Camera>().fieldOfView--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            GetComponent<Camera>().fieldOfView++;
        }
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles += speed*new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);        
        }

    }
}
