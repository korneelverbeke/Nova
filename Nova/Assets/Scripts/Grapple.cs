using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    //creating a var called mousePos
    public Vector3 mousePos;

    void Update()
    {
        //get the mouseposition and store it in our mousPos variable
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //z = 0, to keep eerything in the 2D scene
        mousePos.z = 0f;

        //When you click...
        if(Input.GetMouseButtonDown(0))
        {
            //We create a new Distancejoint2D component and we store it in a joint variable
            var joint = gameObject.AddComponent<DistanceJoint2D>();

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
    }
}
