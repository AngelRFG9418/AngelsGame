using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
    public float speed;
    void Update()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }
}
