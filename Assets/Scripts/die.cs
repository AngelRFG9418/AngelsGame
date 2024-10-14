using JetBrains.Annotations;
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

    public AudioSource bgMusic;
    public AudioSource deathSound;

    public Component[] render;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("evil"))
        {
            deathSound.Play();
            deathSound = null;
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

        

        bgMusic.Pause();
        //destroys player
        render = this.gameObject.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer render in render)
        {
            render.enabled = false;

            //repeats these lines to ensure that they are disabled if either script was in use during the death
            this.gameObject.GetComponent<Movement>().canMove = false;
            this.gameObject.GetComponent<shootScript>().canShoot = false;
        }


        //loads appropriate text and retry button
        Instantiate(text);
        Instantiate(retryButton);
    }

}
