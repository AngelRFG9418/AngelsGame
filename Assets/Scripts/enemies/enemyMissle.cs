using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMissle : MonoBehaviour
{
    private float distance;

    private Vector2 direction;

    private GameObject player;

    public float speed;

    public float lifespan;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);

        direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        transform.up = direction;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }
}
