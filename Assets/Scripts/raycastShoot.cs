using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastShoot : MonoBehaviour
{
    public GameObject laser;

    // Update is called once per frame
    void Update()
    {

    }

    public Transform firePoint;

    public void shoot()
    {

        RaycastHit[] hits = Physics.RaycastAll(firePoint.position, transform.position, 100f);

        foreach (RaycastHit hit in hits)
        {

            if (hit.collider.CompareTag("enemy"))
            {
                Debug.Log("HIT");
            }

        }
    }
}
