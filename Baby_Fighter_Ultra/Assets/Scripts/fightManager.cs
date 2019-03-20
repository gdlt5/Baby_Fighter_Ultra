using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fightManager : MonoBehaviour
{

	public float fightTime;
	private int displayTime;
	public Text timerText;
    public float startTime;
    private float startTrigger = 0f;

    public playerController player1;
    public playerController2 player2;
    public Text winText;

    public Text timeWinner;
    public float textTimer;
    public float disableTimeText;

    // Start is called before the first frame update
    void Start()
    {
    	displayTime = (int) fightTime;
        timerText.text = displayTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        startTrigger += Time.deltaTime;
    
        if(startTrigger >= startTime){
            if(player1.currentHealth > 0 && player2.currentHealth > 0){
                 fightTime -= Time.deltaTime;
                 displayTime = (int) fightTime;
                 timerText.text = displayTime.ToString();

                if(fightTime < 0){
                    timerText.text = "0"; 
                    if(fightTime <= disableTimeText){
                        if(player1.currentHealth > player2.currentHealth){
                            winText.text = "Player 1 Wins!";
                        }
                        else if(player1.currentHealth < player2.currentHealth){
                            winText.text = "Player 2 Wins!";
                        }
                        else if(player1.currentHealth == player2.currentHealth){
                            winText.text = "Draw!";
                        }
                    }
                    else{
                        winText.text = "Time!";
                    }
                }

            }
            else{
                if(player1.currentHealth <= 0 && player2.currentHealth > 0){
                    winText.text = "Player 2 Wins!";
                }
                else if(player2.currentHealth <= 0 && player1.currentHealth > 0){
                    winText.text = "Player 1 Wins!";
                }
                else if(player1.currentHealth <= 0 && player2.currentHealth <= 0){
                    winText.text = "Draw!";
                }
            }
        }

    }
}
