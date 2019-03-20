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
    public float currentHealth;

    public Image healthBar;

    playerController2 opponentScript;

    /* Blocking Flag */
    public bool blockCheck = false;

    /* Attack Flags */
    public bool actionCheck = false;


    public bool lightCheck = false;
    public float lightTimer;
    private float lightNext;

    public float lightDistance;

    public bool medCheck = false;
    public float medTimer;
    private float medNext;

    public float medDistance;

    public bool heavyCheck = false;
    public bool heavyDownCheck = false;
    public float heavyTimer;
    private float heavyNext;
    private float heavyDown;
    public float heavyDownTime;

    public float heavyDistance;

    public float lightDamage;
    public float medDamage;
    public float heavyDamage;





    // Use this for initialization
    void Start(){

    	target = GameObject.FindWithTag("Player2").transform;
        opponentScript = GameObject.FindWithTag("Player2").GetComponent<playerController2>();

    	someScale = transform.localScale.x;
    	currentHealth = startHealth;

    }
    
    // Update is called once per frame
    void FixedUpdate () {

        if(Time.time >= lightNext && lightCheck == true){
           GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    	   lightCheck = false;
           actionCheck = false;
        }
        if(Time.time >= medNext && medCheck == true){
           GetComponent<Rigidbody2D>().velocity = Vector2.zero;
           medCheck = false;
           actionCheck = false;
        }
        if(Time.time >= heavyNext && heavyCheck == true){
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            heavyCheck = false;
        }
        if(Time.time >= heavyDown && heavyDownCheck == true){
            actionCheck = false;
        }


    	blockCheck = false;

    	/* Movement */
        if (transform.position.x < target.position.x){
            transform.localScale = new Vector2(someScale, transform.localScale.y);

            if(Input.GetAxis("Horizontal") > 0.5 && actionCheck == false){

	        	Vector2 movingVector = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical")* 0 * Time.deltaTime);

	        	player.transform.Translate(movingVector.x, 0f, 0f);
    		}

    		if(Input.GetAxis("Horizontal") < -0.5 && actionCheck == false){
    			blockCheck = true;

    			Vector2 movingVector = new Vector2(Input.GetAxis("Horizontal") * (speed/2) * Time.deltaTime, Input.GetAxis("Vertical")* 0 * Time.deltaTime);

	       		player.transform.Translate(movingVector.x, 0f, 0f);
    		}

        	if(Input.GetAxis("Vertical") == 1 && actionCheck == false){
            	if(isGrounded){
                	isGrounded = false;
                	GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10), ForceMode2D.Impulse);
            	}
        	}
        }

        else{
            transform.localScale = new Vector2(-someScale, transform.localScale.y);

		    if(Input.GetAxis("Horizontal") < -0.5 && actionCheck == false){

		        Vector2 movingVector = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical")* 0 * Time.deltaTime);

		        player.transform.Translate(movingVector.x, 0f, 0f);
			}

			if(Input.GetAxis("Horizontal") > 0.5 && actionCheck == false){
				blockCheck = true;

				Vector2 movingVector = new Vector2(Input.GetAxis("Horizontal") * (speed/2) * Time.deltaTime, Input.GetAxis("Vertical")* 0 * Time.deltaTime);

		        player.transform.Translate(movingVector.x, 0f, 0f);
			}

		    if(Input.GetAxis("Vertical") == 1 && actionCheck == false){
		        if(isGrounded){
		            isGrounded = false;
		            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10), ForceMode2D.Impulse);
		        }
		    }
		}
		/* End Movement */

		/* Combat */
        if(actionCheck == false){

    		if(Input.GetButtonDown("P1_Light") && actionCheck == false){
    			if (transform.position.x < target.position.x){
    				lightNext = Time.time + lightTimer;
    				lightCheck = true;
                    GetComponent<Rigidbody2D>().AddForce(Vector2.right*lightDistance);			}
    			else{
    				lightNext = Time.time + lightTimer;
    				lightCheck = true;
                    GetComponent<Rigidbody2D>().AddForce(Vector2.left*lightDistance);
    			}
    		}

            if(Input.GetButtonDown("P1_Med") && actionCheck == false){
                if (transform.position.x < target.position.x){
                    medNext = Time.time + medTimer;
                    medCheck = true;
                    GetComponent<Rigidbody2D>().AddForce(Vector2.right*medDistance);
                }
                else{
                    medNext = Time.time + medTimer;
                    medCheck = true;
                    GetComponent<Rigidbody2D>().AddForce(Vector2.left*medDistance);
                }
            }


            if(Input.GetButtonDown("P1_Heavy") && actionCheck == false){
                if (transform.position.x < target.position.x){
                    heavyNext = Time.time + heavyTimer;
                    heavyDown = Time.time + heavyDownTime;
                    heavyDownCheck = true;
                    heavyCheck = true;
                    GetComponent<Rigidbody2D>().AddForce(Vector2.right*heavyDistance);
                }
                else{
                    heavyNext = Time.time + heavyTimer;
                    heavyDown = Time.time + heavyDownTime;
                    heavyDownCheck = true;
                    heavyCheck = true;
                    GetComponent<Rigidbody2D>().AddForce(Vector2.left*heavyDistance);
                }

            }

            if(lightCheck || medCheck || heavyCheck){
                actionCheck = true;
            }
        }

		if(currentHealth == 0){
			player.GetComponent<playerController>().enabled = false;
		}

    }


    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.name == "Floor"){
            isGrounded = true;
        }
        if(coll.gameObject.tag == "Player2"){
            if(opponentScript.blockCheck == false){
                if(lightCheck){
                    opponentScript.currentHealth = opponentScript.currentHealth - lightDamage;
                    opponentScript.healthBar.fillAmount = opponentScript.currentHealth / opponentScript.startHealth;
                    lightCheck = false;
                    actionCheck = false;
               }
               if(medCheck){
                    opponentScript.currentHealth = opponentScript.currentHealth - medDamage;
                    opponentScript.healthBar.fillAmount = opponentScript.currentHealth / opponentScript.startHealth;
                    medCheck = false;
                    actionCheck = false;
               }
               if(heavyCheck){
                    opponentScript.currentHealth = opponentScript.currentHealth - heavyDamage;
                    opponentScript.healthBar.fillAmount = opponentScript.currentHealth / opponentScript.startHealth;
                    heavyCheck = false;
                    actionCheck = false;
               }

            }
        }
    }
}