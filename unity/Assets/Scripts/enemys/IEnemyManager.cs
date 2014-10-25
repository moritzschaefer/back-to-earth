using UnityEngine;
using System.Collections;

public interface IEnemyManager {

	IHitable[] GetAllEnemys();
	void EnemyDied(IHitable enemy);
}
