using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StopTimeSkill : MonoBehaviour, IGvrGazeResponder {

	public GameObject timeImg;
	public Image useImg;
	public Image remainingImg;
	public Text quantityInfo;
	public float useValue = 0;
	public float remainingValue = 0;
	public bool fill = false;
	public bool isActivated = false;
	public bool isDisabled = true;
	public PauseTheGame pause;
	public PassedManager pm;
	public GameOverManager gom;
	public TimeIsUp tm;

	void Start () {
		useImg.fillAmount = useValue;
		remainingImg.fillAmount = remainingValue;
	}

	void Update () {

		quantityInfo.text = "x" + PlayerPrefs.GetInt("TimePot");

		//IfUserHasMoreDontDisable
		if (PlayerPrefs.GetInt("TimePot") > 0 && isActivated == false) {
			remainingValue = 1;
		}

		//Enable/Disable
		if (PlayerPrefs.GetInt("TimePot") >= 1 && remainingValue >= 1) {
			timeImg.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, 1f);
			isDisabled = false;
		} else if(PlayerPrefs.GetInt("TimePot") <= 0 && remainingValue <= 0) {
			timeImg.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, 0.4f);
			isDisabled = true;
		}

		//GazeToUse
		if (fill == true && useValue <= 1.1f) {
			useValue += Time.deltaTime;
			useImg.fillAmount = useValue;
		} else {
			useValue = 0;
			useImg.fillAmount = useValue;
			fill = false;
		}

		//OnUseUntilFinished
		if (fill == true && useValue >= 1.1f) {
			isActivated = true;	
			PlayerPrefs.SetInt ("TimePot", PlayerPrefs.GetInt ("TimePot") - 1);
		}
		if (isActivated == true && remainingValue > 0) {
			StopTimeNow ();
			if (pause.isPaused == false) {
				remainingValue -= Time.deltaTime / 8;
			}
			remainingImg.fillAmount = remainingValue;

		} else {
			//Sonsuza Kadar Resume Çalıştırma 
			if(pause.isPaused == false){
				ResumeTime ();
			}
			remainingImg.fillAmount = remainingValue;
			isActivated = false;
		}
	}

	//End of Update

	public void StopTimeNow(){
		tm.pauseTime = true;
	}

	public void ResumeTime(){
		tm.pauseTime = false;
	}

	public void OnGazeEnter(){
		if (isActivated == false && isDisabled == false && pause.isPaused == false && pm.isPassed == false && gom.isGameOver == false) {
			fill = true;
		}
	}

	public void OnGazeExit(){
		fill = false;
	}

	public void OnGazeTrigger(){

	}
}
