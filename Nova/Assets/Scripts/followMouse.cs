using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(Mousepos.x, Mousepos.y);
    }
}
