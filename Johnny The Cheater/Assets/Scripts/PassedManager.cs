using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PassedManager : MonoBehaviour {

	Scene myScene;

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

	void Start(){
	
		myScene = SceneManager.GetActiveScene ();

	}

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
			if (PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "D" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "DD" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "C" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "CC" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "B" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "BB" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "A" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "AA") {
				PlayerPrefs.SetInt ("LevelStars", 50);
				PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "D");

				PlayerPrefs.SetInt ("ShopPointsToSet", PlayerPrefs.GetInt ("PointBag"));
				PlayerPrefs.SetInt ("PointBag", 0);
			
			}
		} else if (passDD == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "D+";
			if (PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "DD" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "C" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "CC" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "B" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "BB" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "A" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "AA") {

				PlayerPrefs.SetInt ("ShopPointsToSet", PlayerPrefs.GetInt ("PointBag"));
				PlayerPrefs.SetInt ("PointBag", 0);

				if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "D") {
					PlayerPrefs.SetInt ("LevelStars", 50);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "DD");

				} else {
					PlayerPrefs.SetInt ("LevelStars", 100);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "DD");
				}
			}
		} else if (passC == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "C";
			if (PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "C" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "CC" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "B" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "BB" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "A" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "AA") {

				PlayerPrefs.SetInt ("ShopPointsToSet", PlayerPrefs.GetInt ("PointBag"));
				PlayerPrefs.SetInt ("PointBag", 0);

				if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "D") {
					PlayerPrefs.SetInt ("LevelStars", 100);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "C");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "DD") {
					PlayerPrefs.SetInt ("LevelStars", 50);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "C");

				} else {
					PlayerPrefs.SetInt ("LevelStars", 150);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "C");
				}
			}
		} else if (passCC == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "C+";
			if (PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "CC" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "B" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "BB" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "A" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "AA") {

				PlayerPrefs.SetInt ("ShopPointsToSet", PlayerPrefs.GetInt ("PointBag"));
				PlayerPrefs.SetInt ("PointBag", 0);

				if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "D") {
					PlayerPrefs.SetInt ("LevelStars", 150);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "CC");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "DD") {
					PlayerPrefs.SetInt ("LevelStars", 100);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "CC");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "C") {
					PlayerPrefs.SetInt ("LevelStars", 50);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "CC");

				} else {
					PlayerPrefs.SetInt ("LevelStars", 200);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "CC");
				}
			}
		} else if (passB == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "B";
			if (PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "B" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "BB" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "A" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "AA") {

				PlayerPrefs.SetInt ("ShopPointsToSet", PlayerPrefs.GetInt ("PointBag"));
				PlayerPrefs.SetInt ("PointBag", 0);

				if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "D") {
					PlayerPrefs.SetInt ("LevelStars", 200);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "B");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "DD") {
					PlayerPrefs.SetInt ("LevelStars", 150);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "B");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "C") {
					PlayerPrefs.SetInt ("LevelStars", 100);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "B");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "CC") {
					PlayerPrefs.SetInt ("LevelStars", 50);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "B");

				} else {
					PlayerPrefs.SetInt ("LevelStars", 250);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "B");
				}
			}
		} else if (passBB == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "B+";
			if (PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "BB" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "A" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "AA") {

				PlayerPrefs.SetInt ("ShopPointsToSet", PlayerPrefs.GetInt ("PointBag"));				
				PlayerPrefs.SetInt ("PointBag", 0);

				if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "D") {
					PlayerPrefs.SetInt ("LevelStars", 250);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "BB");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "DD") {
					PlayerPrefs.SetInt ("LevelStars", 200);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "BB");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "C") {
					PlayerPrefs.SetInt ("LevelStars", 150);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "BB");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "CC") {
					PlayerPrefs.SetInt ("LevelStars", 100);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "BB");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "B") {
					PlayerPrefs.SetInt ("LevelStars", 50);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "BB");

				} else {
					PlayerPrefs.SetInt ("LevelStars", 300);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "BB");
				}
			}
		} else if (passA == true) {
			isPassed = true;
			DisablePapers ();
			SetButtons ();
			TeacherMovement ();
			PlayWinnerSound ();
			scoreCircle.fillAmount = .0f;
			scoreInfo.text = "A";
			if (PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "A" && PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "AA") {

				PlayerPrefs.SetInt ("ShopPointsToSet", PlayerPrefs.GetInt ("PointBag"));
				PlayerPrefs.SetInt ("PointBag", 0);

				if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "D") {
					PlayerPrefs.SetInt ("LevelStars", 300);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "A");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "DD") {
					PlayerPrefs.SetInt ("LevelStars", 250);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "A");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "C") {
					PlayerPrefs.SetInt ("LevelStars", 200);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "A");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "CC") {
					PlayerPrefs.SetInt ("LevelStars", 150);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "A");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "B") {
					PlayerPrefs.SetInt ("LevelStars", 100);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "A");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "BB") {
					PlayerPrefs.SetInt ("LevelStars", 50);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "A");

				} else {
					PlayerPrefs.SetInt ("LevelStars", 350);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "A");
				}
			}
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
			if (PlayerPrefs.GetString (myScene.name + "PassedWith") != myScene.name + "AA") {

				PlayerPrefs.SetInt ("ShopPointsToSet", PlayerPrefs.GetInt ("PointBag"));
				PlayerPrefs.SetInt ("PointBag", 0);

				if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "D") {
					PlayerPrefs.SetInt ("LevelStars", 350);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "AA");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "DD") {
					PlayerPrefs.SetInt ("LevelStars", 300);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "AA");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "C") {
					PlayerPrefs.SetInt ("LevelStars", 250);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "AA");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "CC") {
					PlayerPrefs.SetInt ("LevelStars", 200);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "AA");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "B") {
					PlayerPrefs.SetInt ("LevelStars", 150);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "AA");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "BB") {
					PlayerPrefs.SetInt ("LevelStars", 100);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "AA");

				} else if (PlayerPrefs.GetString (myScene.name + "PassedWith") == myScene.name + "A") {
					PlayerPrefs.SetInt ("LevelStars", 50);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "AA");

				} else {
					PlayerPrefs.SetInt ("LevelStars", 400);
					PlayerPrefs.SetString (myScene.name + "PassedWith", myScene.name + "AA");
				}
			}
		}
	}
}
