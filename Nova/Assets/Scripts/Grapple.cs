using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    Vector2 GrapplePoint;

    public LayerMask WhatIsGrappeable;

    public Transform GrapplingRope, player;

    public int maxDistance = 1000;

    SpringJoint2D joint;

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

    void StartGrappling()
    {
        var mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        var mouseDif = mousePos - gameObject.transform.position;

        mouseDif.z = 0.0f;

        float distance = mouseDif.magnitude;

        var mouseDir = mouseDif / distance;

        mouseDir.Normalize();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        if (hit.collider != null)
        {
            GrapplePoint = hit.point;

            joint = player.gameObject.AddComponent<SpringJoint2D>();

            joint.autoConfigureConnectedAnchor = false;

            joint.connectedAnchor = GrapplePoint;

            float distanceFromPoint = Vector2.Distance(player.position, GrapplePoint);

            joint.distance = distanceFromPoint;

            joint.dampingRatio = 7f;
        }

    }

    void StopGrappling()
    {

    }

}
