using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public int multiplier;
    public int currentScore;
    public float comboCooldown;
    public float maxCooldown;


    public TMP_Text scoreText;
    public GameObject BG;
    public GameObject coolDownIcon;
    public TMP_Text multiplierText;

    // Update is called once per frame
    void Update()
    {
        comboCooldown -= Time.deltaTime;
        float fraction = comboCooldown / maxCooldown;
        coolDownIcon.GetComponent<Image>().fillAmount = fraction;
    }

    public void setMultiplier(RaycastHit2D[] hits)
    {
        //stop multiplier cooldown
        StopAllCoroutines();

        //calculate new multiplier and score
        multiplier += hits.Length;
        int pointsFromShot = 10 * multiplier;
        currentScore += pointsFromShot;

        //sets score and multiplier text
        string multiplierString = multiplier.ToString();
        scoreText.SetText("Score: " + currentScore);
        multiplierText.SetText("x" + multiplierString);

        //resets timer UI
        comboCooldown = maxCooldown;
        BG.SetActive(true);

        //start multiplier cooldownm
        StartCoroutine(multiplierCooldown());
    }

    public IEnumerator multiplierCooldown()
    {
        yield return new WaitForSeconds(maxCooldown);
        multiplier = 0;
        string multiplierString = multiplier.ToString();
        multiplierText.SetText("");
        BG.SetActive(false);
    }

}
