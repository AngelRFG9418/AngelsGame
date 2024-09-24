using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadGame : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene("Level_01"); // loads current scene
    }
}
