﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public Transform camera;

    public List<Vector2> cameraPositions = new List<Vector2>();

    public List<Vector2> respawnPositions = new List<Vector2>();

    int level;


    void Start()
    {
        transform.position = new Vector2(-23.5f, -9f);

        cameraPositions.Add(new Vector2(0f, 0f));

        cameraPositions.Add(new Vector2(46f, 6f));

        cameraPositions.Add(new Vector2(93f, 2f));

        respawnPositions.Add(new Vector2(-22.43298f, -10.112f));

        respawnPositions.Add(new Vector2(23.58f, 2f));

        respawnPositions.Add(new Vector2(70f, 2f));
    }


    void Update()
    {

        if (transform.position.y < -14)
        {
            transform.position = respawnPositions[level];
        }

        if (transform.position.x < 23.5)
        {
            camera.position = cameraPositions[0];
            level = 0;
        }
        else if (transform.position.x > 23.5 && transform.position.x < 70)
        {
            camera.position = cameraPositions[1];
            level = 1;
        }
        else if (transform.position.x > 70)
        {
            camera.position = cameraPositions[2];
            level = 2;
        }

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "spikes")
        {
            transform.position = respawnPositions[level];
        }
    }
}
