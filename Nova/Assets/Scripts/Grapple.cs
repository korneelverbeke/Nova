using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    Vector2 GrapplePoint;
    public LayerMask WhatIsGrappeable;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrappling();
        }
            else if (Input.GetMouseButtonUp(0))
        {
            StopGrappling();
        }
    }

}
