using UnityEngine;
using System.Collections;

public class Cannon : BuildThing {

	private float spinSpeed = 100;

	private float timeToShoot = 1;
	private float lastShoot = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//TODO SEE enemy
		//else turn around
		transform.RotateAround(transform.position, Vector3.forward, Time.deltaTime * spinSpeed);

		if (Time.time > lastShoot + timeToShoot) {
			lastShoot = Time.time;
			shoot();
		}
	}

	void shoot() {
		Enemy[] enemyes =  (Enemy[])SpawnMaster.Instance.GetAllEnemys ();
		if (enemyes.Length < 1) {
			return;
		}
		float minRange = Vector3.Distance(transform.position, enemyes[0].transform.position);
		int minId = 0;
		for (int i = 1; i < enemyes.Length; i ++) {
			float range = Vector3.Distance(transform.position, enemyes[i].transform.position);
			if (range < minRange) {
				minRange = range;
				minId = i;
			}
		}
		enemyes [minId].HitProjectile (5);
	}
}
