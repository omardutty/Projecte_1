using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string startLvl;
    public string cosas;

    public void NewGame()
    {
        Application.LoadLevel(startLvl);
        

    }


    public void creditos()
    {

        Application.LoadLevel(cosas);

    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
