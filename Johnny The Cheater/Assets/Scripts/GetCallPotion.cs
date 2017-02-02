using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetCallPotion: MonoBehaviour, IGvrGazeResponder {

	public FakeCall fc;
	public PauseTheGame pause;

	void Start () {

	}

	void Update () {
		transform.Rotate (new Vector3 (0,Time.deltaTime * 50, 0));
	}

	public void OnGazeEnter(){
		if (pause.isPaused == false) {
			fc.quantity += 1;
			gameObject.SetActive (false);
			//SES ÇAL
		}
	}

	public void OnGazeExit(){

	}

	public void OnGazeTrigger(){

	}
}
