using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController2 : MonoBehaviour {
    //private Rigidbody2D rb;
    public GameObject player;
    public float speed;
    private bool isGrounded = true;
    Transform target;
    float someScale;

    float startHealth = 100;
    float currentHealth;   

    public Image healthBar;

    playerController opponentScript;

    /* Blocking Flag */
    public bool blockCheck = false;

    /* Attack Flags */
    public bool actionCheck = false;

    public float lightTimer;
    private float lightNext;

    public float lightDistance;





     // Use this for initialization
    void Start(){

    	target = GameObject.FindWithTag("Player1").transform;
        opponentScript = GameObject.FindWithTag("Player1").GetComponent<playerController>();

    	someScale = transform.localScale.x;
        currentHealth = startHealth;

    }
    
    // Update is called once per frame
    void FixedUpdate () {

        blockCheck = false;

        if (transform.position.x > target.position.x){

            transform.localScale = new Vector2(someScale, transform.localScale.y);

	        if(Input.GetAxis("P2Hor") > 0.5){

                blockCheck = true;

	            Vector2 movingVector = new Vector2(Input.GetAxis("P2Hor") * (speed/4) * Time.deltaTime, Input.GetAxis("P2Vert")* 0 * Time.deltaTime);

	            player.transform.Translate(movingVector.x, 0f, 0f);
	        }

	        if(Input.GetAxis("P2Hor") < -0.5){

	            Vector2 movingVector = new Vector2(Input.GetAxis("P2Hor") * speed * Time.deltaTime, Input.GetAxis("P2Vert")* 0 * Time.deltaTime);

	            player.transform.Translate(movingVector.x, 0f, 0f);
	        }


	        if(Input.GetAxis("P2Vert") == 1){
	            if(isGrounded){
	                isGrounded = false;
	                GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10), ForceMode2D.Impulse);
	            }
	        }
	    }
	    else{
	    	transform.localScale = new Vector2(-someScale, transform.localScale.y);
	        
	        if(Input.GetAxis("P2Hor") > 0.5){

	            Vector2 movingVector = new Vector2(Input.GetAxis("P2Hor") * speed * Time.deltaTime, Input.GetAxis("P2Vert")* 0 * Time.deltaTime);

	            player.transform.Translate(movingVector.x, 0f, 0f);
	        }

	        if(Input.GetAxis("P2Hor") < -0.5){
                blockCheck = true;

	            Vector2 movingVector = new Vector2(Input.GetAxis("P2Hor") * (speed/4) * Time.deltaTime, Input.GetAxis("P2Vert")* 0 * Time.deltaTime);

	            player.transform.Translate(movingVector.x, 0f, 0f);
	        }

	        if(Input.GetAxis("P2Vert") == 1){
	            if(isGrounded){
	                isGrounded = false;
	                GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10), ForceMode2D.Impulse);
	            }
	        }
	    }
        /* End Movement */
        
        if(currentHealth == 0){
            Destroy(this.gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.name == "Floor"){
            isGrounded = true;
        }

        if(coll.gameObject.tag == "Player1"){
            if(blockCheck == false){
                if(opponentScript.actionCheck){
                    currentHealth = currentHealth - 10;
                    healthBar.fillAmount = currentHealth / startHealth;
                }
            }
        }
    }
}