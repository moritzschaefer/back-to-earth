using UnityEngine;
using System.Collections;

public class Spawn : Ground {

	public bool spawnAnimationOn = true;
	public bool spawningUnits = false;

	public Transform spawnPosition;

	public GameObject spawnAnimation;
	private GameObject current;
	private int lastRotationAngle = 0;
	private int rotationTick = 10;
	public SpawnMaster master;

	private int unitsLeftToCreate = 0;

	void Awake() {
		buildPossible = false;

		current = (GameObject)GameObject.Instantiate(spawnAnimation, spawnPosition.position, Quaternion.identity);
		current.transform.parent = spawnPosition;
		current.renderer.enabled = false;
	}

	void Update () {
		if (spawnAnimationOn) {
				lastRotationAngle += rotationTick;
				if (lastRotationAngle > 360) {
						lastRotationAngle = 0;
				}
			current.renderer.enabled = true;
				//current.transform.RotateAround(transform.position, Vector3.forward, (float) lastRotationAngle);
			Vector3 rot = current.transform.rotation.eulerAngles;
			rot = new Vector3 (rot.x, rot.y, lastRotationAngle);
			Quaternion q = current.transform.rotation;
			q.eulerAngles = rot;
			current.transform.rotation = q;
		} else {
			current.renderer.enabled = false;
		}
	}

	public void spawnUnits(int number) {

		//enemy = new Enemy ();
		unitsLeftToCreate = number - 1;
	}
}
