using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public bool isGameOver = false;

	//Kağıtlar
	public LeftFront leftFPaper;
	public Left leftPaper;
	public LeftBack leftBPaper;
	public Back backPaper;
	public RightFront rightFPaper;
	public Right rightPaper;
	public RightBack rightBPaper;

	//Butonlar
	public GameObject resume;
	public GameObject pause;
	public GameObject main;
	public GameObject restart;

	//Sesler
	public AudioSource audSource;
	public AudioClip gameOver;
	bool soundplayed = false;

	//Süre
	public TimeIsUp time;

	//Kağıt
	public Image scoreCircle;

	//Johnny
	public GameObject target;

	//Öğretmen
	public GameObject teacherObj;
	public LookForCheaters teacher;
	public Transform gameOverPoint;
    public bool isBusted = false;

	void Update () {
		if (isGameOver == true) {
			//Kağıtlar Cheat Disabled
			leftFPaper.cheatEnabled = false;
			leftPaper.cheatEnabled = false;
			leftBPaper.cheatEnabled = false;
			backPaper.cheatEnabled = false;
			rightFPaper.cheatEnabled = false;
			rightPaper.cheatEnabled = false;
			rightBPaper.cheatEnabled = false;

			//Süre Durur
			time.pauseTime = true;

			//Öğretmen Durur Oyuncuya Bakar
			teacher.checkForCheater = 0;
			teacher.agent.destination = gameOverPoint.transform.position;
			if(teacher.agent.remainingDistance <= 0.5f){
				teacherObj.transform.LookAt (target.transform.position);
				teacher.agent.Stop ();
                isBusted = true;
            }

            //Restart ve Main Menu Butonları aktifleşir
            resume.SetActive (false);
			pause.SetActive (false);
			main.SetActive (true);
			restart.SetActive (true);

			//Kağıttaki Değişiklikler
			scoreCircle.fillAmount = .0f;

			//Oyuncu Mağaza Parası Kazanamaz
			PlayerPrefs.SetInt("PointBag", 0);
			PlayerPrefs.SetInt ("ShopPointsToSet", 0);

			//Ses 
			if (!soundplayed) {
				audSource.PlayOneShot (gameOver);
				soundplayed = true;
			}
		}
	}
}
