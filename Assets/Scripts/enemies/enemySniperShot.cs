using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySniperShot : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
