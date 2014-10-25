using UnityEngine;
using System.Collections;

public class Cannon : BuildThing {

	private float spinSpeed = 100;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//TODO SEE enemy
		//else turn around
		transform.RotateAround(transform.position, Vector3.forward, Time.deltaTime * spinSpeed);
	}
}
