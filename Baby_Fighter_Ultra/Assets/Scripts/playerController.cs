using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    //private Rigidbody2D rb;
    public GameObject player;
    public float speed;
    Transform trans;
    Rigidbody2D rb;
	// Use this for initialization
	void Awake(){
		trans = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {


        if(Input.GetKey(KeyCode.A)){
        	//Vector3 movement = new Vector3(10,0,0);
        	rb.AddTorque(10);

        }
        else if(Input.GetKey(KeyCode.D)){
        	//Vector3 movement = new Vector3(10,0,0);
        	rb.AddTorque(-10);

        }
        else
        	rb.velocity = Vector3.zero;
	}
}
