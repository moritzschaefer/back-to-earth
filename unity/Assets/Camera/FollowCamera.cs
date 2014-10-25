using UnityEngine;
using System.Collections;


public class FollowCamera : MonoBehaviour {

	private Transform _transform;

	[SerializeField]
	private Transform followed;
	private float distance;

	void Awake() {
		this._transform = this.transform;
		this.distance = this._transform.position.z;
	}

	void Update () {
		if(this.followed != null) {
			Vector3 position = this.followed.position;
			position.z = this.distance;
			this._transform.position = position;
		}
	}
}
