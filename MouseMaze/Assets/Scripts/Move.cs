using UnityEngine;
using System;

public class Move : MonoBehaviour {
	public float speed=0f;
	const float MAX_SPEED=10f; 
	int angle=0;
	public float X;
	public float Y;
	Texture2D[] textures={};
	// Use this for initialization
	void Start () {
	
	}

	void flip(){
		/*transform.rotation.eulerAngles =
			new Vector3 (transform.rotation.eulerAngles.x, 
			             transform.rotation.eulerAngles.y,
			             transform.rotation.eulerAngles.z + 45f);*/
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
	void move(){
		 X =float.Parse(Convert.ToString( transform.position.x - speed * Math.Sin (angle * Math.PI / 180)));
		Y=float.Parse(Convert.ToString (transform.position.y + speed * Math.Cos (angle * Math.PI / 180)));
		transform.position = new Vector3 (X, Y, transform.position.z);
	}
	// Update is called once per frame
	void Update () {
		move ();
		if (Input.GetKeyDown (KeyCode.DownArrow)&& speed>-1f) {
			speed=speed-0.1f;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)&& speed<MAX_SPEED) {
			speed=speed+0.1f;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			angle = (angle -45+360) % 360;
			flip();
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			angle = (angle + 45) % 360;
			flip();
		}

	}

}
	