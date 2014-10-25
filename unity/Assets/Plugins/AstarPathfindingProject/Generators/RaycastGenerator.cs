using UnityEngine;
using System.Collections;
//Include generics to be able to use Generics
using System.Collections.Generic;
//Include the Pathfinding namespace to gain access to a lot of useful classes
using Pathfinding;

//Inherit our new graph from a base graph type
public class RaycastGenerator : GridGraph , ISerializableGraph {
	
	public bool showDebugNotes;
	public GameObject myParent;
	//public static readonly Material RED = new Material(Shader.Find("Diffuse"));
	//public static readonly Material GREEN = new Material(Shader.Find("Diffuse"));
	//public static readonly Material BLUE = new Material(Shader.Find("Diffuse"));
	
    public override void Scan (){
		base.Scan();
		
		//RED.color = Color.red;
		//GREEN.color = Color.green;
		//BLUE.color = Color.blue;

		//while(dnotes.Count > 0){
		//	GameObject.DestroyImmediate(dnotes[0]);
		//	dnotes.RemoveAt(0);
		//}
		
		Transform[] ele = myParent.GetComponentsInChildren<Transform>();
		foreach(Transform e in ele){
			Debug.Log("Ele " + e.ToString());
			if(e.gameObject.name.Equals("NoteCube")){
				GameObject.DestroyImmediate(e.gameObject);
			}
		}
		
		if(showDebugNotes){
			Node[] nodes = base.nodes;
			Vector3 s = new Vector3(0.5f,0.5f,0.5f);
			foreach( Node n in nodes){
				GameObject gc = GameObject.CreatePrimitive(PrimitiveType.Cube);
				gc.collider.enabled = false;
				gc.transform.position = n.position;
				gc.transform.localScale = s;
				gc.name = "NoteCube";
				if(n.walkable)
					gc.renderer.material.color = Color.green;
				else
					gc.renderer.material.color = Color.red;
				if(myParent != null)
					gc.transform.parent = myParent.transform;
			}
		}
	}

}