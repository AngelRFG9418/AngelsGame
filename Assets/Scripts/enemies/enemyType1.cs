using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyType1 : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public float followDistance;

    private Vector2 direction;
    float distance;

    public float speed;
    public float rotSpeed;

    bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

        StartCoroutine(shooting());
    }

    // Update is called once per frame
    void Update()
    {
        //gets distance between player and itself
        distance = Vector2.Distance(transform.position, player.transform.position);

        //faces player
        direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        transform.up = Vector2.MoveTowards(transform.up, direction, rotSpeed * Time.deltaTime);


        //movement perameters
        if (distance > followDistance + 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            canShoot = true;

        }

        if(distance < followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
            canShoot = false;

        }

        else
        {
            canShoot = true;
        }
    }

    private IEnumerator shooting()
    {
        while (true)
        {
            while (canShoot == true)
            {
                
                Instantiate(projectile, transform.position, transform.rotation);
                yield return new WaitForSeconds(4);
            }
            yield return null;
        }
    }

}
