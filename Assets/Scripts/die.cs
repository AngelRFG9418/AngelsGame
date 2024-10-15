using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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

    public bool timer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("evil"))
        {
            //'timer' varible checks if the timer has completed, or if it no longer needed. Otherwise, disbale other UI to avoid bugs
            if (!timer)
            {
                deathSound.Play();
                deathSound = null;
                gameOver(deathText);
                bgMusic.Pause();
            }
        }

    }

    public void Update()
    {
        if (timerUiManager.fraction <= 0)
        {
            if (!timer)
            {
                gameOver(timeUp);
            }
        }
    }

    public void gameOver(GameObject text)
    {
        timer = true;

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

        //destroy all missiles
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("evil"))
        {
            Destroy(o);
        }

        //stops player
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        this.GetComponent<Movement>().horiz = 0;
        this.GetComponent<Movement>().vert = 0;


        //destroys player
        render = this.gameObject.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer render in render)
        {
            render.enabled = false;

            //repeats these lines to ensure that they are disabled if either script was in use during the death
            this.gameObject.GetComponent<Movement>().canMove = false;
            this.gameObject.GetComponent<shootScript>().canShoot = false;
            //Destroy(this.gameObject);
        }


        //loads appropriate text and retry button
        Instantiate(text);
        Instantiate(retryButton);
    }

}
