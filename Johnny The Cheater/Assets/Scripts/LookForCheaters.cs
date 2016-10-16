using UnityEngine;
using System.Collections;

public class LookForCheaters : MonoBehaviour {

	public ImCheating student;

	void Update () {
		if (student.isCheating == true) {
			Debug.Log ("CHEATING !!!");
		}
	}
}
