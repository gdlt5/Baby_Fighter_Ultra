using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScreenTransition : MonoBehaviour
{

	public Animator animator;
	
    void Update()
    {
        if (Input.anyKey)
        {
        	animator.SetTrigger("FadeOut");
			SceneManager.LoadScene(sceneBuildIndex:1);        
		}
    }
}
