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

    public Rigidbody2D rb;

    public float raycastDistance;

    public LayerMask ladderLayer;

    private bool isClimbing;

    private float inputVertical;


    void Start ()
    {

        rb = GetComponent<Rigidbody2D>();

    }


    void Update ()
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

       RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, raycastDistance, ladderLayer);

       if (hitInfo.collider != null)
       {
           if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
           {
               isClimbing = true;
           }
       }

       else
       {
           isClimbing = false;
       }

       if (isClimbing == true)
       {
           inputVertical = Input.GetAxisRaw("Vertical");

           rb.velocity = new Vector2(rb.velocity.x, inputVertical * 20);

           rb.gravityScale = 0;
       }

       else
       {
           rb.gravityScale = 5;
       }

    }


}
