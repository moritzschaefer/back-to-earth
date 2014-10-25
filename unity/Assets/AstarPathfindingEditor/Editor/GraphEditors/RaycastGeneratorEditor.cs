using UnityEngine;
using UnityEditor;
using System.Collections;
using Pathfinding;

[CustomGraphEditor (typeof(RaycastGenerator),"Raycast Generator")]
public class RaycastGeneratorEditor : GridGraphEditor {
	
	public override void OnInspectorGUI (NavGraph target) {
		
		RaycastGenerator graph = target as RaycastGenerator;
		//GameObject go = obj as GameObject;
		
		base.OnInspectorGUI(target);
		graph.myParent = editor.script.gameObject;
		graph.showDebugNotes = EditorGUILayout.Toggle ("Show Debug Notes",graph.showDebugNotes);
	}
}
