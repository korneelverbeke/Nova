using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToMouse : MonoBehaviour
{

    public float dashDuration;

    [HideInInspector]
    public bool touchingWall;

    public Transform ceilingCheck;

    public Transform groundCheck;

    public Transform frontWallCheck;

    public Transform backWallCheck;

    public LayerMask groundLayers;

    bool quitDash = false;

    public Rigidbody2D rb;

    public Animator animator;

    public ParticleSystem dash;

    public CameraShake cameraShake;

    public float dashForce;

    public Vector2 mouseDir;

    [HideInInspector]
    public int dashCount = 0;


    private void Start ()
    {
        rb.AddForce(Vector3.right * 1300);
    }


    void Update ()
    {
        Collider2D frontWallCheckRadius = Physics2D.OverlapCircle(frontWallCheck.position, 0.5f, groundLayers);

        Collider2D backWallCheckRadius = Physics2D.OverlapCircle(backWallCheck.position, 0.5f, groundLayers);

        if (frontWallCheckRadius != null || backWallCheckRadius != null)
        {
            touchingWall = true;
        }
        else
        {
            touchingWall = false;
        }

        if (IsGrounded())
        {
            dashCount = 0;
        }

        if (Input.GetMouseButtonDown(0) && dashCount <= 0)
        {

            dash.Play();

            StartCoroutine(Dash(dashDuration));

            StartCoroutine(cameraShake.Shake(.15f, .2f));

            FindObjectOfType<AudioManager>().Play("PlayerDash");

            if (animator.GetBool("IsJumping"))
            {
              animator.SetBool("IsJumping", false);
            }

            animator.SetBool("IsDashing", true);

            StartCoroutine(AddToDashCount(1));
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

    public IEnumerator Dash(float duration)
    {

        var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        var mouseDif = mousePos - gameObject.transform.position;

        mouseDif.z = 0.0f;

        float distance = mouseDif.magnitude;

        mouseDir = mouseDif / distance;

        mouseDir.Normalize();

        float elapsed = 0.0f;

        quitDash = false;

        while(elapsed < duration && quitDash == false)
        {
            rb.velocity = mouseDir * dashForce;

            elapsed += Time.deltaTime;

            if (transform.position.y < -14)
            {
                quitDash = true;
            }

            if (HitCeiling())
            {
                quitDash = true;
            }

            if(touchingWall == true)
            {
                quitDash = true;
            }

            yield return null;
        }

        rb.velocity = mouseDir * dashForce;

        if(IsGrounded())
        {
            animator.SetBool("IsDashing", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "spikes")
        {
            quitDash = true;
        }
    }


    IEnumerator AddToDashCount(int numberOfDashes)
    {

        while(IsGrounded() == true)
        {
          yield return null;
        }

        dashCount = dashCount + numberOfDashes;

    }
    public bool HitCeiling()
    {

        Collider2D ceilingCheckRadius = Physics2D.OverlapCircle(ceilingCheck.position, 0.5f, groundLayers);

        if(ceilingCheckRadius != null)
        {
            return true;
        }

        return false;

    }

}
