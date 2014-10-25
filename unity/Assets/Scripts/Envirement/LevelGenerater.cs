using UnityEngine;
using System.Collections;

public class LevelGenerater : MonoBehaviour {

	public GameObject[] objs;


	public int[,] level = new int[,]{
		{0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,1,1,1,1,1,1,1,1,1,1},
		{0,1,2,2,2,2,1,2,2,2,2,1},
		{0,1,2,2,2,2,1,2,2,2,2,1},
		{1,2,3,3,3,3,3,3,3,3,2,1},
		{0,1,2,2,2,2,1,2,2,2,2,1},
		{0,0,1,2,2,2,1,2,2,2,2,1},
		{0,0,0,1,1,1,1,1,1,1,1,1},
		{0,0,0,0,0,0,0,0,0,0,0,0}

	};

	void Awake () {

		for (int y = 0; y < level.GetLength(0); y++) {
			for (int x = 0; x < level.GetLength(1); x++) {
				if(level[y,x] > 0){
					GameObject current = (GameObject)GameObject.Instantiate(objs[level[y,x] - 1], transform.position +  new Vector3(x,y,0), Quaternion.identity);
					current.transform.parent = transform;
				}
			}
		}
	}

}
