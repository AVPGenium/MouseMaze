using UnityEngine;
using System;

public class Move : MonoBehaviour {
	public float speed=0f;
	const float MAX_SPEED=10f; 
	const float deltaSPEED=0.3f; 
	const int deltaangle=30; 
	int angle=0;
	int stop=0;
	public float X;
	public float Y;
	float angleleft = -30f;
	float angleright = 30f;
	Vector3 Tposition;
	Texture2D[] textures={};
	// Use this for initialization
	void Start () {
	
	}


	void move(){
		X =float.Parse(Convert.ToString(speed * Math.Sin (-1f * angle * Math.PI / 180)));
		Y= float.Parse(Convert.ToString(speed * Math.Cos (angle * Math.PI / 180)));
		GetComponent<Rigidbody2D>().velocity  = new Vector2 (X, Y);
	}
	// Update is called once per frame
	void Update () {
		move ();



		if (Tposition == transform.position && speed != 0)
			stop++;
		else
			stop = 0;
		if (stop == 5)
			speed = 0;
		if (Input.GetKeyDown (KeyCode.DownArrow)&& speed>-1f) {
			speed=speed-deltaSPEED;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)&& speed<MAX_SPEED) {
			speed=speed+deltaSPEED;
		}
		angle = (int)transform.rotation.eulerAngles.z;
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D>().angularVelocity = angleleft;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D>().angularVelocity = angleright;
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D>().angularVelocity = 0f;
		}
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D>().angularVelocity = 0f;
		}
		Tposition = transform.position;
	}
}
	