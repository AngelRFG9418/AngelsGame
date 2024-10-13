using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class lookAtMouse : MonoBehaviour
{
    public Vector2 direction;
    public float rotSpeed;

    // Update is called once per frame
    void Update()
    {
        mousePosition();
    }

    public void mousePosition()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = Vector2.MoveTowards(transform.up, direction, rotSpeed * Time.deltaTime);


    }
}
