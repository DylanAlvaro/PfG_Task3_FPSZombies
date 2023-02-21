using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class CharacterMover : MonoBehaviour
{
    public float movementSpeed = 10;
    public float jumpVelocity = 10;
    public Vector3 velocity;


    private CharacterController characterController;
    private Animator animator;
    private Vector2 moveInput = new Vector2();
    private bool jumpInput;

    public bool isGrounded = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        jumpInput = Input.GetButton("Jump");
        
        animator.SetFloat("Forwards", moveInput.y);
        animator.SetBool("Jump", !isGrounded);
    }

    private void FixedUpdate()
    {
        jumpVelocity = Mathf.Sqrt(2 * Physics.gravity.magnitude * jumpVelocity);
        
        Vector3 delta;
        delta = (moveInput.x * Vector3.right + moveInput.y * Vector3.forward) * movementSpeed;

        if(isGrounded || moveInput.x != 0 || moveInput.y != 0)
        {
            velocity.x = delta.x;
            velocity.z = delta.z;
        }
        
        if(jumpInput && isGrounded)
        {
            velocity.y = jumpVelocity;
        }


        if(isGrounded && velocity.y < 0)
            velocity.y = 0;

        velocity += Physics.gravity * Time.fixedDeltaTime;

       // transform.forward = camForward;
        
        //delta += velocity * Time.fixedDeltaTime;

        characterController.Move(velocity * Time.deltaTime);
        isGrounded = characterController.isGrounded;
    }
    
   
}
