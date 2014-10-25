using UnityEngine;
using System.Collections;

public class alien : MonoBehaviour {
	public Transform target; // the target to walk to
	private NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start () {
		this._navMeshAgent = this.transform.GetComponent<NavMeshAgent>();

	
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
						this._navMeshAgent.SetDestination (target.position);
				}

	
	}
}
