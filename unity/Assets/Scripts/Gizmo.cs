using UnityEngine;
using System.Collections;

public class Gizmo : MonoBehaviour {
	
	public static bool showGizmo = false;
	public Texture gizmo;
	private GUITexture t;
	private int oldScreenWidth;
	
	void Update () {
		if(showGizmo){
			if(t == null){
				GameObject c = new GameObject();
				c.name = "Gizmo";
				c.transform.parent = transform;
				t =  (GUITexture)c.AddComponent("GUITexture");	
				t.texture = gizmo;
			}
			if(oldScreenWidth != Screen.width && t != null){
				t.transform.localScale = new Vector3(((float)gizmo.width) / Screen.width ,((float)gizmo.height) / Screen.height ,0.5F );
				Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
				t.transform.position = new Vector3(screenPoint.x / Screen.width, screenPoint.y / Screen.height, 10);
			}
		}
	}
	
	void OnDrawGizmos(){
		if(gizmo != null){
			Gizmos.DrawIcon(transform.position, gizmo.name);
		}
	}
	
	
}
