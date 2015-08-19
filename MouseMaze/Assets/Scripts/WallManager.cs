using UnityEngine;
using System.Collections;

public class WallManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		/*int count = 1;
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < 10; j++) {
				GameObject tempGObj = Instantiate(Resources.Load("SimpleWall", typeof(GameObject))) as GameObject;
				tempGObj.transform.position = new Vector3(j * 1.5f - 3, i * -1.5f + 3, 0);
				tempGObj.transform.localEulerAngles = new Vector3 (0, 0, 0);
				tempGObj.name = count.ToString();
				count++;
			}
		}*/
		this.gameObject.GetComponent<LevelHandler> ().loadLevel (1);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
