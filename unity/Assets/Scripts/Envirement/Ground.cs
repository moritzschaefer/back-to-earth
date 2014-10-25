using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

	public bool buildPossible;
	public bool buildOn;

	public bool IsBuildPossible(){
		return !buildOn && buildPossible;
	}

	public bool CanRecyle(){
		return buildPossible && buildOn;
	}

}
