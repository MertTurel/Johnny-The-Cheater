using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetStopTimeSkill : MonoBehaviour, IGvrGazeResponder {

	public PauseTheGame ps;
	public StopTimeSkill sts;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0,Time.deltaTime * 50, 0));
	}

	public void OnGazeEnter(){
		if (ps.isPaused == false) {
			sts.quantity += 1;
			gameObject.SetActive (false);
			//SES ÇAL
		}
	}

	public void OnGazeExit(){
	
	}

	public void OnGazeTrigger(){
	 //
	}
}
