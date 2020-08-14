using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController2D controller;

    public ParticleSystem dust;

    float horizontalMove = 0f; 

    public float runSpeed = 40f;

    bool jump = false;

    bool crouch = false;

    public Animator animator;

    public Transform groundCheck;

    public LayerMask groundLayers;

    
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            dust.Play();
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true; 
            animator.SetBool("IsCrouching", true);    
        }

        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("IsCrouching", false); 
        }

    }


    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsDashing", false);
    }

    
    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }


    public bool IsGrounded()
    {

        Collider2D groundCheckRadius = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayers);

        if(groundCheckRadius != null)
        {
            return true;
        }

        return false;

    }

    void FixedUpdate () 
    {
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        
        jump = false;

    }


}
