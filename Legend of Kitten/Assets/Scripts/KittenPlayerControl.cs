using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenPlayerControl : MonoBehaviour {
	public float MaxSpeed = 1f;
	public int Direction = 0;
	Rigidbody rb;

	void Start () {
		rb = GetComponent <Rigidbody> ();
	}
	
	void Update () {
		var haxis = Input.GetAxis ("Horizontal");
		var vaxis = Input.GetAxis ("Vertical");
		transform.Translate (haxis * MaxSpeed * Time.deltaTime, vaxis * MaxSpeed * Time.deltaTime, 0);
		Direction = DirectionDetection (haxis, vaxis);
	}

	int DirectionDetection (float haxis, float vaxis){
		if (haxis > 0.25f) {
			if (vaxis > 0.25f) {
				return 1;
			} else if (vaxis < -0.25f) {
				return 3;
			} else {
				return 2;
			}
		} else if (haxis < -0.25f) {
			if (vaxis > 0.25f) {
				return 7;
			} else if (vaxis < -0.25f) {
				return 5;
			} else {
				return 6;
			}
		} else {
			if (vaxis > 0.25f) {
				return 8;
			} else if (vaxis < -0.25f) {
				return 4;
			} else {
				return 0;
			}
		}
	}
	//0 = still
	//1 = up-right
	//2 = right
	//3 = down-right
	//4 = down
	//5 = down-left
	//6 = left
	//7 = up-left
	//8 = up

	public void Report (string Message){
		print (Message);
	}
}
