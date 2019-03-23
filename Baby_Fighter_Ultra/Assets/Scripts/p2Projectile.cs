using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Projectile : MonoBehaviour
{
    playerController opponentScript;
    public float rangeDamage;
    // Start is called before the first frame update
    void Start()
    {
        opponentScript = GameObject.FindWithTag("Player1").GetComponent<playerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player1")
        {
            if(opponentScript.blockCheck == false)
            {
                opponentScript.currentHealth = opponentScript.currentHealth - rangeDamage;
                opponentScript.healthBar.fillAmount = opponentScript.currentHealth / opponentScript.startHealth;
            }
        }
        
    }
}
