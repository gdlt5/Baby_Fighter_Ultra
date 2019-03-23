using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1Projectile : MonoBehaviour
{
    playerController2 opponentScript;
    public float rangeDamage;
    // Start is called before the first frame update
    void Start()
    {
        opponentScript = GameObject.FindWithTag("Player2").GetComponent<playerController2>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player2")
        {
            if(opponentScript.blockCheck == false)
            {
                opponentScript.currentHealth = opponentScript.currentHealth - rangeDamage;
                opponentScript.healthBar.fillAmount = opponentScript.currentHealth / opponentScript.startHealth;
            }
        }
       	Destroy(this.gameObject);
    }
}
