using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPan : MonoBehaviour
{
	float margin = 0.01f;

	float z0 = 0f;
	float zCam;
	float wScene;
	float xL;
	float xR;

	Transform fighter1;
	Transform fighter2;
    // Start is called before the first frame update

	void calcScreen(Transform p1, Transform p2){
	     // Calculates the xL and xR screen coordinates 
	     if (p1.position.x<p2.position.x){
	         xL = p1.position.x-margin;
	         xR = p2.position.x+margin;
	     } else {
	         xL = p2.position.x-margin;
	         xR = p1.position.x+margin;
	     }
	 }


    void Start()
    {
		fighter1 = GameObject.FindWithTag("Player1").transform;
		fighter2 = GameObject.FindWithTag("Player2").transform;

		calcScreen(fighter1, fighter2);
		wScene = xR - xL;
		zCam = transform.position.z-z0;

    }

    // Update is called once per frame
    void Update()
    {
        calcScreen(fighter1, fighter2);
		float width = xR-xL;
		if(width > wScene){
			Vector3 change = new Vector3(transform.position.x, transform.position.y, zCam*width/wScene+z0);
			transform.position = change;
		}

		Vector3 center = new Vector3((xR+xL)/2,transform.position.y,transform.position.z);
		transform.position = center;
		
    }
}
