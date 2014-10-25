using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	private Transform _transform;
	private Rigidbody2D _rigidbody;

	[SerializeField]
	private float movementSpeed = 5.0f;


	void Awake() {
		this._transform = this.transform;
		this._rigidbody = this.rigidbody2D;
	}


	void Start () {

	}

	void Update () {
		float hor = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");
    Vector3 mouseWorldPoint =Camera.main.ScreenToWorldPoint((Vector3)(Input.mousePosition));
    // calculate the view angle
    Vector3 viewVector  = (mouseWorldPoint - this._transform.position);
    Vector3 angles = this._transform.eulerAngles;
    angles.z = (180.0f*Mathf.Atan2(-viewVector.x, viewVector.y)/Mathf.PI);
    this._transform.eulerAngles = angles;


		Vector2 movement = new Vector2(hor, vert) * this.movementSpeed;
		this._rigidbody.velocity = movement;
	}
}
