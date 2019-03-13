using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScreenTextMovement : MonoBehaviour
{

	public GameObject ultra;
	private Vector3 ultraPosition = new Vector3(4f,0f,0f);
	public float moveSpeed;

    void FixedUpdate(){

    	Vector2 movement = new Vector2(moveSpeed * Time.deltaTime, 0f);

    	ultra.transform.Translate(movement.x,0f,0f);
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.name == "StopSpot"){
    		ultra.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
