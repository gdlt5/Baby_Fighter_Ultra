using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    //private Rigidbody2D rb;
    public GameObject player;
    public float speed;
    private bool isGrounded = true;
    Transform target;
    float someScale;

    float startHealth = 100;
    float currentHealth;

    public Image healthBar;

    playerController2 opponentScript;

    /* Attack Flags */
    public bool actionCheck = false;

    public float lightTimer;
    private float lightNext;

    public float lightDistance;




    // Use this for initialization
    void Start(){

    	target = GameObject.FindWithTag("Player2").transform;
        opponentScript = GameObject.FindWithTag("Player2").GetComponent<playerController2>();

    	someScale = transform.localScale.x;
    	currentHealth = startHealth;

    }
    
    // Update is called once per frame
    void FixedUpdate () {

    	actionCheck = false;

    	/* Movement */
        if (transform.position.x < target.position.x){
            transform.localScale = new Vector2(someScale, transform.localScale.y);

            if(Input.GetAxis("Horizontal") > 0.5){

	        	Vector2 movingVector = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical")* 0 * Time.deltaTime);

	        	player.transform.Translate(movingVector.x, 0f, 0f);
    		}

    		if(Input.GetAxis("Horizontal") < -0.5){

    			Vector2 movingVector = new Vector2(Input.GetAxis("Horizontal") * (speed/4) * Time.deltaTime, Input.GetAxis("Vertical")* 0 * Time.deltaTime);

	       		player.transform.Translate(movingVector.x, 0f, 0f);
    		}

        	if(Input.GetAxis("Vertical") == 1){
            	if(isGrounded){
                	isGrounded = false;
                	GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10), ForceMode2D.Impulse);
            	}
        	}
        }

        else{
            transform.localScale = new Vector2(-someScale, transform.localScale.y);

		    if(Input.GetAxis("Horizontal") < -0.5){

		        Vector2 movingVector = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical")* 0 * Time.deltaTime);

		        player.transform.Translate(movingVector.x, 0f, 0f);
			}

			if(Input.GetAxis("Horizontal") > 0.5){

				Vector2 movingVector = new Vector2(Input.GetAxis("Horizontal") * (speed/4) * Time.deltaTime, Input.GetAxis("Vertical")* 0 * Time.deltaTime);

		        player.transform.Translate(movingVector.x, 0f, 0f);
			}

		    if(Input.GetAxis("Vertical") == 1){
		        if(isGrounded){
		            isGrounded = false;
		            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10), ForceMode2D.Impulse);
		        }
		    }
		}
		/* End Movement */

		/* Combat */
		if(Input.GetButton("P1_Light") && Time.time > lightNext){
			if (transform.position.x < target.position.x){
				lightNext = Time.time + lightTimer;
				actionCheck = true;
				Vector2 bellyBump = new Vector2(transform.position.x + lightDistance, transform.position.y);
				player.transform.position = bellyBump;
			}
			else{
				lightNext = Time.time + lightTimer;
				actionCheck = true;
				Vector2 bellyBump = new Vector2(transform.position.x - lightDistance, transform.position.y);
				player.transform.position = bellyBump;
			}
		}

		if(currentHealth == 0){
			Destroy(this.gameObject);
		}

    }


    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.name == "Floor"){
            isGrounded = true;
        }
        if(coll.gameObject.tag == "Player2"){
        	if(opponentScript.actionCheck){
        		currentHealth = currentHealth - 10;
        		healthBar.fillAmount = currentHealth / startHealth;
        	}
        }
    }
}