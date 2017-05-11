using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetSpeedPoiton: MonoBehaviour, IGvrGazeResponder {

	public float destroyTime = 3.0f;
	GameObject pause;
	GameObject gom;
	GameObject pm;

	void Start () {
		pause = GameObject.FindWithTag("PauseGame");
		gom = GameObject.FindWithTag("GameOverZehra");
		pm = GameObject.FindWithTag("PassedManager");
		Destroy (gameObject, destroyTime);
	}

	void Update () {
		transform.Rotate (new Vector3 (0,Time.deltaTime * 50, 0));
	}

	public void OnGazeEnter(){
		if (pause.GetComponent<PauseTheGame>().isPaused == false && gom.GetComponent<GameOverManager>().isGameOver == false && pm.GetComponent<PassedManager>().isPassed == false) {
			PlayerPrefs.SetInt ("SpeedPot", PlayerPrefs.GetInt ("SpeedPot") + 1);
			gameObject.SetActive (false);
			//SES ÇAL
		}
	}

	public void OnGazeExit(){
		
	}

	public void OnGazeTrigger(){

	}
}
