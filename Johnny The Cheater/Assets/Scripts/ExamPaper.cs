using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExamPaper : MonoBehaviour {

	//ScoreElements
	public Image scoreCircle;
	public Text scoreInfo;
	public int score = 0;
	public TimeIsUp tm;
	public PassedManager pass;

	//AnswersRemaining
	public int remainingLeftF = 2;
	public int remainingLeft = 4;
    public int remainingLeftB = 2;
    public int remainingBack = 4;
    public int remainingRightB = 2;
    public int remainingRight = 4;
    public int remainingRightF = 2;

	//Papers
	public LeftFront leftFPaper;
	public Left leftPaper;
	public LeftBack leftBPaper;
	public Back backPaper;
	public RightFront rightFPaper;
	public Right rightPaper;
	public RightBack rightBPaper;

	//IsCheatSuccessful
	public bool leftFront = false;
	public bool left = false;
	public bool leftBack = false;
	public bool back = false;
	public bool rightFront = false;
	public bool right = false;
	public bool rightBack = false;
    public AudioSource audSource;
    public AudioClip successfulCheat;

    void Start(){
		scoreCircle.fillAmount = score;
	}

	void Update () {
		if (leftFront == true && score < 100) {
			score += 5;
			PlayerPrefs.SetInt ("PointBag", PlayerPrefs.GetInt ("PointBag") + 10);
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingLeftF -= 1;
            audSource.PlayOneShot(successfulCheat);
			if (remainingLeftF == 0) {             
				leftFront = false;
				leftFPaper.cheatEnabled = false;
            }
		}

		if (left == true && score < 100) {
			score += 5;
			PlayerPrefs.SetInt ("PointBag", PlayerPrefs.GetInt ("PointBag") + 10);
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingLeft -= 1;
            audSource.PlayOneShot(successfulCheat);
            if (remainingLeft == 0) {
				left = false;
				leftPaper.cheatEnabled = false;
            }
        }

		if (leftBack == true && score < 100) {
			score += 5;
			PlayerPrefs.SetInt ("PointBag", PlayerPrefs.GetInt ("PointBag") + 20);
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingLeftB -= 1;
            audSource.PlayOneShot(successfulCheat);
            if (remainingLeftB == 0) {
				leftBack = false;
				leftBPaper.cheatEnabled = false;
            }
		}

		if (back == true && score < 100) {
			score += 5;
			PlayerPrefs.SetInt ("PointBag", PlayerPrefs.GetInt ("PointBag") + 30);
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingBack -= 1;
            audSource.PlayOneShot(successfulCheat);
            if (remainingBack == 0) {
				back = false;
				backPaper.cheatEnabled = false;
            }
		}

		if (rightFront == true && score < 100) {
			score += 5;
			PlayerPrefs.SetInt ("PointBag", PlayerPrefs.GetInt ("PointBag") + 10);
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingRightF -= 1;
            audSource.PlayOneShot(successfulCheat);
            if (remainingRightF == 0) {
				rightFront = false;
				rightFPaper.cheatEnabled = false;
            }
		} 

		if (right == true && score < 100) {
			score += 5;
			PlayerPrefs.SetInt ("PointBag", PlayerPrefs.GetInt ("PointBag") + 10);
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingRight -= 1;
            audSource.PlayOneShot(successfulCheat);
            if (remainingRight == 0) {
				right = false;
				rightPaper.cheatEnabled = false;
            }
		} 

		if (rightBack == true && score < 100) {
			score += 5;
			PlayerPrefs.SetInt ("PointBag", PlayerPrefs.GetInt ("PointBag") + 20);
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingRightB -= 1;
            audSource.PlayOneShot(successfulCheat);
            if (remainingRightB == 0) {
				rightBack = false;
				rightBPaper.cheatEnabled = false;
            }
		}
       
		if (score >= 60 && score < 65 && tm.isTimeOver == true){
			//D
			pass.passD = true;
		}
		if (score >= 65 && score < 70 && tm.isTimeOver == true) {
			//D+
			pass.passDD = true;
		}
		if (score >= 70 && score < 75 && tm.isTimeOver == true) {
			//C
			pass.passC = true;
		}
		if (score >= 75 && score < 80 && tm.isTimeOver == true) {
			//C+
			pass.passCC = true;
		}
		if (score >= 80 && score < 85 && tm.isTimeOver == true) {
			//B
			pass.passB = true;
		}
		if (score >= 85 && score < 90 && tm.isTimeOver == true) {
			//B+
			pass.passBB = true;
		}
		if (score >= 90 && score < 100 && tm.isTimeOver == true) {
			//A
			pass.passA = true;
		}
		if (score == 100) {
			//A+
			pass.passAA = true;
		}
		//End Of Update
	}
}
