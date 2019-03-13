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

        if(Input.GetKey("up")){
            if(isGrounded){
                isGrounded = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0,5), ForceMode2D.Impulse);
            }
        }

        Vector2 movingVector = new Vector2(Input.GetAxis("P2Hor") * speed * Time.deltaTime, Input.GetAxis("P2Vert")* speed * Time.deltaTime);

        player.transform.Translate(movingVector.x, movingVector.y, 0f);

        /*
        else if(Input.GetKey("right")){
            player.transform.Translate(Vector3.right*speed*Time.deltaTime);

        }
        else if(Input.GetKey("left")){
            player.transform.Translate(Vector3.left*speed*Time.deltaTime);

        }
        */
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.name == "Floor"){
            isGrounded = true;
        }
    }
}