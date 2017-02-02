using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetSpeedPoiton: MonoBehaviour, IGvrGazeResponder {

	public InstaCheat ins;
	public PauseTheGame pause;

	void Start () {

	}

	void Update () {
		transform.Rotate (new Vector3 (0,Time.deltaTime * 50, 0));
	}

	public void OnGazeEnter(){
		if (pause.isPaused == false) {
			ins.quantity += 1;
			gameObject.SetActive (false);
			//SES ÇAL
		}
	}

	public void OnGazeExit(){
		
	}

	public void OnGazeTrigger(){

	}
}
