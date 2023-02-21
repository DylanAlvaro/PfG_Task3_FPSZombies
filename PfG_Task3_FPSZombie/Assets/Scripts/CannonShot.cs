using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CannonShot : MonoBehaviour
{
    public float fireForce = 400;

    private bool fire = false;
    private bool canFire = true;

    private Rigidbody rb = null;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && canFire)
        {
            rb.isKinematic = false;
            rb.AddForce(transform.forward * fireForce);
            canFire = false;
        }
    }
}
