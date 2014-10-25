using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	private Transform _transform;
	private Rigidbody2D _rigidbody;

	[SerializeField]
	private float movementSpeed = 5.0f;
	
	[SerializeField]
	private float fireDelay = 0.2f;
	private float lastShotTime;
	private bool hasFiredSinceTriggered;
	[SerializeField]
	private GameObject projectilePrefab;
	[SerializeField]
	private float spreadAngle = 0.0f;


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

		if(Input.GetButton("Fire1")) {

			bool canFire = false;
			if(fireDelay == 0) {
				if(!this.hasFiredSinceTriggered) {
					canFire = true;
				}
			} else {
				if(Time.time > this.lastShotTime + this.fireDelay) {
					canFire = true;
				}
			}

			if(canFire) {
				this.Shoot();
				this.lastShotTime = Time.time;
			}

			this.hasFiredSinceTriggered = true;
		} else {
			this.hasFiredSinceTriggered = false;
		}
	}


	/**
	 * Gets called to perform the shoot itself.
	 * There is no checking if the player is able to shoot right now.
	 */
	private void Shoot() {
		GameObject projectile = (GameObject) Object.Instantiate(this.projectilePrefab, this._transform.position, this._transform.rotation);
		float angle = Mathf.Deg2Rad * (this._transform.eulerAngles.z + Random.Range(-this.spreadAngle, this.spreadAngle));
		Vector2 direction = new Vector2(Mathf.Sin(-angle), Mathf.Cos(angle));
		projectile.SendMessage("SetDirection", direction, SendMessageOptions.DontRequireReceiver);
	}
}
