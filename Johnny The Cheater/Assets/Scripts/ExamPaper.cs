using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExamPaper : MonoBehaviour {

	//ScoreElements
	public Image scoreCircle;
	public Text scoreInfo;
	public int score = 0;

	//AnswersRemaining
	int remainingLeftF = 2;
	int remainingLeft = 4;
	int remainingLeftB = 2;
	int remainingBack = 4;
	int remainingRightB = 2;
	int remainingRight = 4;
	int remainingRightF = 2;

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

	void Start(){
		scoreCircle.fillAmount = score;
	}

	void Update () {
		if (leftFront == true && score < 100) {
			score += 5;
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingLeftF -= 1;
			if (remainingLeftF == 0) {
				leftFront = false;
				leftFPaper.cheatEnabled = false;
			}
		}
		if (left == true && score < 100) {
			score += 5;
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingLeft -= 1;
			if (remainingLeft == 0) {
				left = false;
				leftPaper.cheatEnabled = false;
			}
		}
		if (leftBack == true && score < 100) {
			score += 5;
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingLeftB -= 1;
			if (remainingLeftB == 0) {
				leftBack = false;
				leftBPaper.cheatEnabled = false;
			}
		}
		if (back == true && score < 100) {
			score += 5;
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingBack -= 1;
			if (remainingBack == 0) {
				back = false;
				backPaper.cheatEnabled = false;
			}
		}
		if (rightFront == true && score < 100) {
			score += 5;
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingRightF -= 1;
			if (remainingRightF == 0) {
				rightFront = false;
				rightFPaper.cheatEnabled = false;
			}
		} 
		if (right == true && score < 100) {
			score += 5;
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingRight -= 1;
			if (remainingRight == 0) {
				right = false;
				rightPaper.cheatEnabled = false;
			}
		} 
		if (rightBack == true && score < 100) {
			score += 5;
			scoreInfo.text = "Score = " + score;
			scoreCircle.fillAmount += 0.05f;
			remainingRightB -= 1;
			if (remainingRightB == 0) {
				rightBack = false;
				rightBPaper.cheatEnabled = false;
			}
		}
		//End Of Update
	}
}
