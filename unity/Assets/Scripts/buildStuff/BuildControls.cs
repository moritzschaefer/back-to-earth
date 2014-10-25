using UnityEngine;
using System.Collections;

public class BuildControls : MonoBehaviour {

	public LayerMask mask;
	public GameObject cannon;


	public Ground FindGround(){

		RaycastHit2D hit;
		hit = Physics2D.Raycast(transform.position, Vector2.zero, 0, mask.value);
		if( hit.collider != null){
			Ground gr = hit.collider.GetComponent<Ground>();
			return gr;
		}
		return null;
	}

	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("BuildCannon")){
			Ground g = FindGround();
			if(g != null && g.IsBuildPossible()){
				GameObject instance = (GameObject)GameObject.Instantiate(cannon, g.transform.position, Quaternion.identity);
				g.buildOn = true;
			}
		}
	}
}
