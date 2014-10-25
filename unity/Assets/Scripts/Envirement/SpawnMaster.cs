using UnityEngine;
using System.Collections;

public class SpawnMaster : Ground {

	public Spawn[] spawns;

	public int[] config = new int[]{
		0,0,1,2,1,0,2,2,1,2,1,2
	};
	public int spawnNumberInConfig = 0;
	public float waitTime;
	public float startTime;

	private bool doNeedToSpawn = true;

	public int aliveEnemyes;

	private int activeSpawnNumber;

	void Awake() {
		startTime = Time.time;
		for (int i = 0; i < spawns.Length; i++) {
			spawns[i].master = this;
		}
	}

	void Update () {
		if (doNeedToSpawn) {
			doNeedToSpawn = false;

			int unitsToSpawn = 10;
			int spawnId = 0;
			if (config.Length > spawnNumberInConfig) {
			 	spawnId = config[spawnNumberInConfig];
			}

			spawns[spawnId].spawnUnits(unitsToSpawn);
			ActivateSpawn(spawnId);
			aliveEnemyes += unitsToSpawn;

			spawnNumberInConfig++;
		}
	}

	void ActivateSpawn(int number) {
		DeactivateAll ();
		spawns[number].spawnAnimationOn = true;
		spawns[number].spawningUnits = true;
	}

	void DeactivateAll () {
		for (int i = 0; i < spawns.Length; i++) {
			spawns[i].spawnAnimationOn = false;
			spawns[i].spawningUnits = false;
		}
	}

	public void enemyDied()
	{
		aliveEnemyes--;
		if (aliveEnemyes == 0) {
			doNeedToSpawn = true;
		}
	}
}
