using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    

    void Start()
    {
        
    }

    
    void Update()
    {

        if (transform.position.y < -14)
        {
            transform.position = new Vector2(-22.43298f, -10.112f);
        }  
        
    }
}
