﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {

    }

    public void Credits()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
