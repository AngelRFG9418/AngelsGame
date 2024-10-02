using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ColliderTests : MonoBehaviour
{

    BoxCollider2D col;
    float width;
    float height;
    public float edgeOffset;
    public float offset;

    public Camera cam;
    public float baseResolution;
    public float ratio;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCollider();
    }


    public void UpdateCollider()
    {
        height = cam.pixelHeight;
        width = cam.pixelWidth;
        float oppositeAspect = height > width ? cam.pixelHeight / cam.pixelWidth : 1;
        col.size = new Vector2 ((cam.pixelWidth * baseResolution / 1000) + (offset * cam.aspect), (cam.pixelHeight * baseResolution / 1000) + (offset * oppositeAspect));
    }
}
