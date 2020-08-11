using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToMouse : MonoBehaviour
{

    public Rigidbody2D rb;

    public Animator animator;

    private void Start()
    {

    }


    void Update ()
    {

        var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;
 
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(mouseDir * 1500);

            //animator.SetBool("IsDashing", true);
        }

    }


    /*public bool isGrounded()
    {

    }*/


}
