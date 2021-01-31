using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void startClick() 
    {
        SceneManager.GetSceneByName("Main");
    }

    public void quitClick() 
    {
        Application.Quit();
    }
}
