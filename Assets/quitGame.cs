using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour
{

    public void doExitGame()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
