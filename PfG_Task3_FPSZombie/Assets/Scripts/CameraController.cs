using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float camSpeed = 360;
    public float distance = 5;
    public Transform cam;
    public Transform target;
    public float currentDistance;


    public float heightOffset = 1.5f;
    
    private Vector2 moveInput = new Vector2();
   
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        currentDistance = distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Vector3 angles = transform.eulerAngles;
            float dx = Input.GetAxis("Mouse Y");
            float dy = Input.GetAxis("Mouse X");

            angles.x = Mathf.Clamp(angles.x + dx * camSpeed * Time.deltaTime, 0, 70);
            angles.y += dy * camSpeed * Time.deltaTime;
            transform.eulerAngles = angles;
        }
        
        

        RaycastHit hit;
        if(Physics.Raycast(GetTargetPosition(), -transform.forward, out hit, distance))
        {
            currentDistance = hit.distance;
        }
        else
        {
            currentDistance = Mathf.MoveTowards(currentDistance, distance, Time.deltaTime);
        }

        transform.position = GetTargetPosition() - distance * transform.forward;
    }

    private void FixedUpdate()
    {
        Vector3 delta;

        Vector3 camForward = cam.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cam.right;
        
        delta = (moveInput.x * camRight + moveInput.y * camForward) * camSpeed;
    }

    Vector3 GetTargetPosition()
    {
        return target.position + heightOffset * Vector3.up;
    }
}
