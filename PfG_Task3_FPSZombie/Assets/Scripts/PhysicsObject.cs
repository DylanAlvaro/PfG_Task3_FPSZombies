using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsObject : MonoBehaviour
{
    public Material awakeMaterial = null;
    public Material asleepMaterial = null;

    private Rigidbody _rb = null;
    private bool _isSleeping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_rb.IsSleeping() && _isSleeping && asleepMaterial != null)
        {
            _isSleeping = false;
            GetComponent<MeshRenderer>().material = asleepMaterial;
        }

        if(!_rb.IsSleeping() && !_isSleeping && awakeMaterial != null)
        {
            _isSleeping = true;
            GetComponent<MeshRenderer>().material = awakeMaterial;
        }
    }
}
