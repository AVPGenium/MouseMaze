using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;

public class LevelHandler : MonoBehaviour {
	XmlDocument levelDoc;
	XmlNodeList levelList;
	List<string> levelArray;
	List<List<string>> loadLevels;

	// Use this for initialization
	void Start () {
		levelArray = new List<string> ();
		loadLevels = new List<List<string>> ();
		levelDoc = new XmlDocument ();
		TextAsset xmlFile = Resources.Load ("levels", typeof(TextAsset)) as TextAsset;
		levelDoc.LoadXml(xmlFile.text);
		levelList = levelDoc.GetElementsByTagName ("level");
		foreach (XmlNode levelData in levelList) {
			XmlNodeList levelInfo = levelData.ChildNodes;
			levelArray = new List<string> ();
			foreach(XmlNode data in levelInfo){
				if(data.Name == "row"){
					Debug.LogWarning(data.InnerText);
					levelArray.Add(data.InnerText);
					//break;
				}
			}
			loadLevels.Add(levelArray);
		}
	}

	public void loadLevel(int nr){
		levelArray = loadLevels [nr - 1];
		Debug.LogWarning(levelArray.ToString());
		int j = 0, i = 0;
		int count = 1;
		foreach (string str in levelArray) {
			foreach(char c in str){
				if(c == '1'){
					GameObject tempGObj = Instantiate(Resources.Load("SimpleWall", typeof(GameObject))) as GameObject;
					tempGObj.transform.position = new Vector3(j * 1.5f - 3, i * -1.5f + 3, 0);
					tempGObj.transform.localEulerAngles = new Vector3 (0, 0, 0);
					tempGObj.name = count.ToString();
				}
				count++;
				j++;
			}
			j = 0;
			i++;
			/*GameObject tempGObj = Instantiate(Resources.Load("SimpleWall", typeof(GameObject))) as GameObject;
			tempGObj.transform.position = new Vector3(j * 1.5f - 3, i * -1.5f + 3, 0);
			tempGObj.transform.localEulerAngles = new Vector3 (0, 0, 0);
			tempGObj.name = count.ToString();
			count++;
			string[] rowString = str.Split (',');
			foreach (string brick in rowString) {
				GameObject.Find(brick).GetComponent<lightSwitch>().change();
			}*/
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
