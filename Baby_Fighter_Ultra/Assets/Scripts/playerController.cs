using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    //private Rigidbody2D rb;
    public GameObject player;
    public float speed;
    private bool isGrounded = true;
    Transform target;
    float someScale;
    // Use this for initialization
    void Start(){

    	target = GameObject.FindWithTag("Player2").transform;
    	someScale = transform.localScale.x;

    }
    
    // Update is called once per frame
    void FixedUpdate () {

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

    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.name == "Floor"){
            isGrounded = true;
        }
    }
}