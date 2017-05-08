using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseTheGame : MonoBehaviour, IGvrGazeResponder {

	public Image img;
	public float barValue = 0;
	public bool fill = false;
	public bool isPaused = false;
	public GameObject resume;
	public GameObject mainmenu;
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
	}

	void Update () {

		Pause ();

		if (fill == true && barValue <= 1.1f) {
			barValue += Time.deltaTime;
			img.fillAmount = barValue;
		} else {
			barValue = 0;
			img.fillAmount = barValue;
			fill = false;
		}
	}

	void Pause(){
		if(fill == true && barValue >= 1.1f){
			//Pause butonu kaybolur resume ve mainmenu butonları aktifleşir
			gameObject.SetActive (false);
			resume.SetActive (true);
			mainmenu.SetActive (true);
			//Kopya çekme disabled
			leftFPaper.cheatEnabled = false;
			leftPaper.cheatEnabled = false;
			leftBPaper.cheatEnabled = false;
			backPaper.cheatEnabled = false;
			rightFPaper.cheatEnabled = false;
			rightPaper.cheatEnabled = false;
			rightBPaper.cheatEnabled = false;
			//Hoca ve Süre durdurulacak
			teacher.paused = true;
			timeMan.pauseTime = true;
			isPaused = true;
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
