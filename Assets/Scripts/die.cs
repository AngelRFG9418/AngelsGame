using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    //this can be changed to just lod one death canvas
    public GameObject deathText;
    public GameObject timeUp;
    public GameObject retryButton;

    public GameObject[] spawners;
    
    public timerUiManager timerUiManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("evil"))
        {
            gameOver(deathText);
        }

    }

    public void Update()
    {
        if (timerUiManager.fraction <= 0)
        {

            gameOver(timeUp);
        }
    }

    public void gameOver(GameObject text)
    {

        //disables all spawners
        foreach (GameObject o in spawners)
        {
            o.GetComponent<enemySpawner>().StopAllCoroutines();
        }

        //destroys all enemies

        foreach (GameObject o in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Destroy(o);
        }

        //destroys player
        Destroy(gameObject);

        //loads appropriate text and retry button
        Instantiate(text);
        Instantiate(retryButton);
    }

}
