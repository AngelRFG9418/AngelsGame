using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyType2 : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public GameObject laser;

    public float followDistance;

    private Vector2 direction;
    float distance;

    public float speed;
    public float rotSpeed;

    public 

    float r;

    bool canShoot;
    bool canMove;
    bool canRotate;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

        StartCoroutine(shooting());

        canRotate = true;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //gets distance between player and itself
        distance = Vector2.Distance(transform.position, player.transform.position);

        //faces player
        direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        

        if (canRotate == true)
        {
            transform.up = Vector2.MoveTowards(transform.up, direction, rotSpeed * Time.deltaTime);
        }

        //movement perameters
        if (canMove == true)
        {

            if (distance > followDistance + 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                canShoot = true;

            }

            if (distance < followDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * Time.deltaTime);
                canShoot = false;

            }

            else
            {
                canShoot = true;
            }
        }
    }

    private IEnumerator shooting()
    {
        while (true)
        {
            while (canShoot == true)
            {
                //disables movement
                canMove = false;

                //show laser
                laser.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.6f);

                //waits 1 second between each color change
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                laser.GetComponent<SpriteRenderer>().color = Color.yellow;
                yield return new WaitForSeconds(1);
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                laser.GetComponent<SpriteRenderer>().color = Color.yellow;
                yield return new WaitForSeconds(1);
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                laser.GetComponent<SpriteRenderer>().color = Color.red;
                canRotate = false;
                yield return new WaitForSeconds(0.5f);

                //once charge-up is complete, fire
                Instantiate(projectile, transform.position, transform.rotation);
               
                //wait for bullet to be offscreen, reset everything
                yield return new WaitForSeconds(0.5f);
                laser.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.0f);
                canRotate = true;
                canMove = true;
                gameObject.GetComponent<SpriteRenderer>().color = Color.black;

                //4 second cooldown to reposition
                yield return new WaitForSeconds(4);
            }
            yield return null;
        }
    }

}
