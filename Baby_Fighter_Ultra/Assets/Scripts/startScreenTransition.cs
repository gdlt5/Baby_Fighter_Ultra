﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScreenTransition : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
			SceneManager.LoadScene(sceneBuildIndex:1);        
		}
    }
}
