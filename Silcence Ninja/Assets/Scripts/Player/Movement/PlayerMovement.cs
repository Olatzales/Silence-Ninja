using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controler;

    public float Gravity = -9.81f;

    public float WalkSpeed = 6f;

    public float JumpForce = 3f;

    public Transform GroundCheck;

    public float GroundDistance = 0.4f;

    public LayerMask groundMask;


    Vector3 velocity;
    public bool IsGrounded = true;
    private void Start()
    {
        
    }
    private void Update()
    {

        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);

        if (IsGrounded! && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controler.Move(move * WalkSpeed * Time.deltaTime); 
        

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            Debug.Log("Jump");
            velocity.y = Mathf.Sqrt(JumpForce * -2f * Gravity);
        }

        velocity.y =+ Gravity * Time.deltaTime;

        controler.Move(velocity * Time.deltaTime);
    }
}
