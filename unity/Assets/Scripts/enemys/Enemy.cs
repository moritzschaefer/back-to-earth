//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IHitable
{
	private int health = 20;

	public Enemy (Transform t)
	{
		transform.position = t.position;
		SpawnMaster.Instance.addEnemy (this);
	}

	public void HitProjectile(int d) {
		health -= d;
		if (d <= 0) {
			die();
		}
	}

	private void die() {
		SpawnMaster.Instance.EnemyDied (this);
	}

				
}

