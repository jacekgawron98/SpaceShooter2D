﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("LevelSelection",LoadSceneMode.Single);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
