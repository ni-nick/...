﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    public string LevelToLoad;

    public void loadLevel()
    {
        //Load the level from LevelToLoad
        SceneManager.LoadScene(LevelToLoad);
    }
}
