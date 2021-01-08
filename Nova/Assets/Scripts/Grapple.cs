using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    //creating a var called mousePos
    public Vector3 mousePos;

    public MonoBehaviour PlayerMovement;

    public MonoBehaviour CharacterController2D;

    public MonoBehaviour DashToMouse;

    DistanceJoint2D joint;

    public bool swinging = false;

    public float raycastDistance;

    public LayerMask GrappleableLayer;

    void Update()
    {
        //When you click...
        if(Input.GetMouseButtonDown(0))
        {
          //get the mouseposition and store it in our mousPos variable
          mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

          var mouseDif = mousePos - gameObject.transform.position;

          mouseDif.z = 0.0f;

          mouseDif.Normalize();

          RaycastHit2D hitInfo = Physics2D.Raycast(mousePos, mouseDif, raycastDistance, GrappleableLayer);

          if (hitInfo.collider != null)
          {
              swinging = true;

              Debug.Log(Vector2.Distance(transform.position, gameObject.transform.position));

              StartSwing();
          }
        }
        if (Input.GetMouseButtonUp(0) && swinging == true)
        {
            swinging = false;

            EndSwing();
        }
    }

    void StartSwing()
    {
        PlayerMovement.enabled = false;

        CharacterController2D.enabled = false;

        DashToMouse.enabled = false;
        //We create a new Distancejoint2D component and we store it in a joint variable
        joint = gameObject.AddComponent<DistanceJoint2D>();

        joint.enableCollision = true;

        //setting the values of the joint
        joint.autoConfigureDistance = false;

        var distanceToMouse = (mousePos - transform.position);

        var distance = distanceToMouse.magnitude;

        //the first distance is from the DistanceJoint2D component and the 2nd distance is our var from above
        joint.distance = distance;

        joint.maxDistanceOnly = true;

        joint.autoConfigureConnectedAnchor = false;

        joint.connectedAnchor = mousePos;
    }

    void EndSwing()
    {
        PlayerMovement.enabled = true;

        CharacterController2D.enabled = true;

        DashToMouse.enabled = true;

        Destroy(joint);
    }
}
