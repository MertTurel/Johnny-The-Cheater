using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PassedManager : MonoBehaviour {

	//Is Passed Game?
	public bool isPassed = false;

	//Puanlama 
	public bool passD = false;
	public bool passDD = false;
	public bool passC = false;
	public bool passCC = false;
	public bool passB = false;
	public bool passBB = false;
	public bool passA = false;
	public bool passAA = false;

	//Kağıtlar
	public LeftFront leftFPaper;
	public Left leftPaper;
	public LeftBack leftBPaper;
	public Back backPaper;
	public RightFront rightFPaper;
	public Right rightPaper;
	public RightBack rightBPaper;

	//Kağıt
	public Image scoreCircle;
	public Text scoreInfo;

	//Butonlar
	public GameObject resume;
	public GameObject pause;
	public GameObject main;
	public GameObject restart;

	//Öğretmen
	public GameObject teacherObj;
	public LookForCheaters teacher;
	public Transform gameOverPoint;

	//Johnny
	public GameObject target;

	//Sesler
	public AudioSource audSource;
	public AudioClip gameWin;
	public AudioClip gameWinAA;
	bool soundplayed = false;

	//Süre
	public TimeIsUp tm;

	void DisablePapers(){
		leftFPaper.cheatEnabled = false;
		leftPaper.cheatEnabled = false;
		leftBPaper.cheatEnabled = false;
		backPaper.cheatEnabled = false;
		rightFPaper.cheatEnabled = false;
		rightPaper.cheatEnabled = false;
		rightBPaper.cheatEnabled = false;
	}

	void PlayWinnerSound(){
		if (!soundplayed) {
			audSource.PlayOneShot (gameWin);
			soundplayed = true;
		}
	}

	void SetButtons(){
		resume.SetActive (false);
		pause.SetActive (false);
		main.SetActive (true);
		restart.SetActive (true);
	}

	void TeacherMovement(){
		teacher.checkForCheater = 0;
		teacher.agent.destination = gameOverPoint.transform.position;
		if(teacher.agent.remainingDistance <= 0.5f){
			teacherObj.transform.LookAt (target.transform.position);
			teacher.agent.Stop ();
		}
	}

	void Update () {
		if (passD == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "D";
		} else if (passDD == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "D+";
		} else if (passC == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "C";
		} else if (passCC == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "C+";
		} else if (passB == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "B";
		} else if (passBB == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "B+";
		} else if (passA == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "A";
		} else if (passAA == true) {
			isPassed = true;
			tm.pauseTime = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			if (!soundplayed) {
				audSource.PlayOneShot (gameWinAA);
				soundplayed = true;
			}
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "A+";
		}
	}
}
