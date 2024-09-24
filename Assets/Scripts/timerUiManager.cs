using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerUiManager : MonoBehaviour
{

    public Image timerImage;
    public float timer;
    public float fraction;

    const float maxTime = 60.0f;

    // Update is called once per frame

    public void Update()
    {
        timer -= Time.deltaTime;
        fraction = timer / maxTime;
        timerImage.fillAmount = fraction;
    }
}
