using UnityEngine;
using System.Collections;

public class ExamPaper : MonoBehaviour {

	public bool leftFront = false;
	public bool left = false;
	public bool leftBack = false;
	public bool back = false;
	public bool rightFront = false;
	public bool right = false;
	public bool rightBack = false;

	void Update () {
		if (leftFront == true) {
			Debug.Log ("leftFront");
		} else if (left == true) {
			Debug.Log ("left");
		} else if (leftBack == true) {
			Debug.Log ("leftback");
		} else if (back == true) {
			Debug.Log ("back");
		} else if (rightFront == true) {
			Debug.Log ("rightfront");
		} else if (right == true) {
			Debug.Log ("right");
		} else if (rightBack == true) {
			Debug.Log ("rightback");
		}
	}
}
