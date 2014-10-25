using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private Rigidbody2D _rigidbody;

	private Vector2 direction = Vector2.zero;
	[SerializeField]
	private float movementSpeed = 20;
	[SerializeField]
	private float damage = 5;

	void Start () {
		this._rigidbody = this.rigidbody2D;
	}

	void Update () {
		if(direction != Vector2.zero) {
			this._rigidbody.velocity = this.direction * this.movementSpeed;
		}
	}


	void OnCollisionEnter2D(Collision2D collision) {
		collision.collider.SendMessage("ProjectileHit", this.damage, SendMessageOptions.DontRequireReceiver);
		Object.Destroy(this.gameObject);
	}


	public void SetDirection(Vector2 direction) {
		if(direction != Vector2.zero) {
			this.direction = direction.normalized;
		} else {
			this.direction = Vector2.zero;
		}
	}
}
