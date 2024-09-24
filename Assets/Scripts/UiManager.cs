using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Image stamBar;
    public float stam;

    // Update is called once per frame

    public void Update()
    {
        stamBar.fillAmount = stam;
    }
}
