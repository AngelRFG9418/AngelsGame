using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject IndicatorObject;
    public GameObject Player;

    Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        Player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (render.isVisible == false)
        {
            if(IndicatorObject.activeSelf == false)
            {
                IndicatorObject.SetActive(true);
            }

            Vector2 dir = Player.transform.position - transform.position;

            RaycastHit2D ray = Physics2D.Raycast(transform.position, dir);

            if (ray.collider != null)
            {
                IndicatorObject.transform.position = ray.point;
            }
        }

        else
        {
            if (IndicatorObject.activeSelf == true)
            {
                IndicatorObject.SetActive(false);
            }

        }
    }
}
