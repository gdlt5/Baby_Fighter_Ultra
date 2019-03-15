﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fightManager : MonoBehaviour
{

	public float fightTime;
	private int displayTime;
	public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
    	displayTime = (int) fightTime;
        timerText.text = displayTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
         fightTime -= Time.deltaTime;
         displayTime = (int) fightTime;
         timerText.text = displayTime.ToString();
         /*
         if (fightTime <= 0.0f){
		    timerEnded();
		 }
		 */
    }
}