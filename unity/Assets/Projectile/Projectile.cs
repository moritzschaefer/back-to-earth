using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

	[SerializeField]
	private Rigidbody2D _rigidbody;

	private Vector2 direction;
	[SerializeField]
	private float movementSpeed = 20;
	[SerializeField]
	private float damage = 5;

	void Awake () {
		this._rigidbody = this.rigidbody2D;
	}

	void Update () {
		if(this.direction != Vector2.zero) {
			this._rigidbody.velocity = this.direction * this.movementSpeed;
		}
	}


	public void SetDirection(Vector2 direction) {
		if(direction != Vector2.zero) {
			this.direction = direction.normalized;
		} else {
			this.direction = Vector2.zero;
		}
	}


	void OnCollisionEnter2D(Collision2D collision) {
		collision.collider.SendMessage("HitProjectile", this.damage, SendMessageOptions.DontRequireReceiver);
		Object.Destroy(this.gameObject);
	}
}
