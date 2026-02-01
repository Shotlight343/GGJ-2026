using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }




    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadLv1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLv2()
    {
        SceneManager.LoadScene("LEVEL 2 (1)");
    }
    public void LoadLv3()
    {
        SceneManager.LoadScene("LEVEL 3");
    }
    public void LoadLv4()
    {
        SceneManager.LoadScene("LEVEL 4");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void LeaveGame()
    {
        Application.Quit();
    }   
    public void LoadLevel(String name)
    {
        SceneManager.LoadScene(name);
    }

}
