using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public Transform camera;
    

    void Start()
    {
        
    }

    
    void Update()
    {

        if (transform.position.y < -14)
        {
            transform.position = new Vector2(-22.43298f, -10.112f);
        }  

        if (transform.position.x > 23.5)
        {
            camera.position = new Vector2(46f, 6f);
        }  
        
    }
}
