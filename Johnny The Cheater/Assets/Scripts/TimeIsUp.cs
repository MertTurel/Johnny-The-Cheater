using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeIsUp : MonoBehaviour {

	public float seconds = 0f;
	public float minutes = 1f;
	public AudioSource audSource;
	public AudioClip lowTime;
	public bool pauseTime = false;
	public Text scoreInfo;
	public GameOverManager gameMan;
	public bool isTimeOver = false;

	void Update () {
		if (seconds <= 0f) {
			seconds = 59f;
			if (minutes >= 1f) {
				minutes -= 1f;
			} else {
				seconds = 0f;
				minutes = 0f;

				gameMan.isGameOver = true;
				scoreInfo.text = "TIME UP";

				isTimeOver = true;
			}
		} else if (minutes == 0f && seconds <= 10f) {
			Debug.Log ("Low Time Sesi Çalınacak");
		} else if(pauseTime == false) {
				seconds -= Time.deltaTime;
		}
	}
}
