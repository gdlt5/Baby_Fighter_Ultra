using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController2 : MonoBehaviour {
    //private Rigidbody2D rb;
    public GameObject player;
    public float speed;
    private bool isGrounded = true;

    // Use this for initialization
    
    
    // Update is called once per frame
    void FixedUpdate () {

        if(Input.GetAxis("P2Hor") > 0.5){

            Vector2 movingVector = new Vector2(Input.GetAxis("P2Hor") * speed * Time.deltaTime, Input.GetAxis("P2Vert")* 0 * Time.deltaTime);

            player.transform.Translate(movingVector.x, 0f, 0f);
        }

        if(Input.GetAxis("P2Hor") < -0.5){

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

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.name == "Floor"){
            isGrounded = true;
        }
    }
}