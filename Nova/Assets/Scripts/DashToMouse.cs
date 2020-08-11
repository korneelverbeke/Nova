using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToMouse : MonoBehaviour
{


    public Rigidbody2D rb;

    public Animator animator;

    public Transform groundCheck;

    public LayerMask groundLayers;


    private void Start ()
    {
        rb.AddForce(Vector3.right * 1300);
    }


    void Update ()
    {

        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            Dash();

            animator.SetBool("IsDashing", true);
        }


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

    void Dash()
    {

        var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        var mouseDir = mousePos - gameObject.transform.position;

        mouseDir.z = 0.0f;

        mouseDir = mouseDir.normalized;

        rb.AddForce(mouseDir * 1600);

    }


}
