using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{


    public Transform groundDetection;

    public float  speed;

    private bool movingRight = true;

    public string groundTag = "patrol";


    void Update ()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
        if(groundInfo.collider != null)
        {
            groundTag = groundInfo.collider.tag;
        }
        if(groundTag != "patrol" || groundInfo.collider == null)
        {
            if(movingRight == false)
            {
                transform.eulerAngles =  new Vector3(0, -180, 0);
                movingRight = true;
            }

            else
              {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
        }



    }

}
