using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour, IGvrGazeResponder {

	public Image img;
	public float barValue = 0;
	public bool fill = false;
	public GameObject mainmenu;
	public GameObject pauseButton;
	public LookForCheaters teacher;
	public TimeIsUp timeMan;

	//Papers
	public LeftFront leftFPaper;
	public Left leftPaper;
	public LeftBack leftBPaper;
	public Back backPaper;
	public RightFront rightFPaper;
	public Right rightPaper;
	public RightBack rightBPaper;

	void Start () {
		img.fillAmount = barValue;
		gameObject.SetActive (false);
	}

	void Update () {

		Resume ();

		if (fill == true && barValue <= 1.1f) {
			barValue += Time.deltaTime;
			img.fillAmount = barValue;
		} else {
			barValue = 0;
			img.fillAmount = barValue;
			fill = false;
		}
	}

	void Resume(){
		if(fill == true && barValue >= 1.1f){
			//Resume ve Main Menu butonları kaybolur pause butonu görünür ve oyun devam eder.
			gameObject.SetActive (false);
			mainmenu.SetActive (false);
			pauseButton.SetActive (true);
			//Kopya Çekme Enabled
			leftFPaper.cheatEnabled = true;
			leftPaper.cheatEnabled = true;
			leftBPaper.cheatEnabled = true;
			backPaper.cheatEnabled = true;
			rightFPaper.cheatEnabled = true;
			rightPaper.cheatEnabled = true;
			rightBPaper.cheatEnabled = true;
			//Hoca ve Süre tekrar başlatılacak.
			teacher.paused = false;
			timeMan.pauseTime = false;
		}
	}

	public void OnGazeEnter(){
		fill = true;
	}

	public void OnGazeExit(){
		fill = false;
	}

	public void OnGazeTrigger(){

	}
}

