using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;

    public GameObject player;

    public float interval;

    public Camera cam;


    void Start()
    {
        StartCoroutine(spawn(interval, enemy));
    }

    public IEnumerator spawn(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        Vector2 direction = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(cam.transform.position.x - 10, cam.transform.position.x + 10), Random.Range(cam.transform.position.y + 10, cam.transform.position.y - 10), 0), Quaternion.Euler(player.transform.position.x, player.transform.position.y, player.transform.position.z));
        

        StartCoroutine(spawn(interval, enemy));
    }



}
