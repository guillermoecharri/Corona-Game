﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        //change scene
        SceneManager.LoadScene(scene);
    }

}
