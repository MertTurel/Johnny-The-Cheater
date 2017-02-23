using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstaCheat: MonoBehaviour, IGvrGazeResponder {

	public GameObject lighteningImg;
	public Image useImg;
	public Image remainingImg;
	public Text quantityInfo;
	public float useValue = 0;
	public float remainingValue = 0;
	public int quantity = 0;
	public bool fill = false;
	public bool isActivated = false;
	public bool isDisabled = true;
	public PauseTheGame pause;
	public PassedManager pm;
	public GameOverManager gom;

	//Papers
	public Back backPaper;
	public Left leftPaper;
	public LeftBack leftbackPaper;
	public LeftFront leftfrontPaper;
	public Right rightpaper;
	public RightBack rightbackPaper;
	public RightFront rightfrontPaper;

	void Start () {
		useImg.fillAmount = useValue;
		remainingImg.fillAmount = remainingValue;
	}

	void Update () {

		quantityInfo.text = "x" + quantity;

		//IfUserHasMoreDontDisable
		if (quantity > 0 && isActivated == false) {
			remainingValue = 1;
		}

		//Enable/Disable
		if (quantity >= 1 && remainingValue >= 1) {
			lighteningImg.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, 1f);
			isDisabled = false;
		} else if(quantity <= 0 && remainingValue <= 0) {
			lighteningImg.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, 0.4f);
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
			quantity -= 1;
		}
		if (isActivated == true && remainingValue > 0) {
			OpenInstaCheater ();
			if (pause.isPaused == false) {
				remainingValue -= Time.deltaTime / 8;
			}
			remainingImg.fillAmount = remainingValue;

		} else {
			CloseInstaCheater ();
			remainingImg.fillAmount = remainingValue;
			isActivated = false;
		}
	}

	//End of Update

	public void OpenInstaCheater(){
		//SüresiBitene Kadar
		backPaper.instaCheat = true;
		leftPaper.instaCheat = true;
		leftbackPaper.instaCheat = true;
		leftfrontPaper.instaCheat = true;
		rightpaper.instaCheat = true;
		rightbackPaper.instaCheat = true;
		rightfrontPaper.instaCheat = true;
	}

	public void CloseInstaCheater(){
		//SüresiBitene Kadar
		backPaper.instaCheat = false;
		leftPaper.instaCheat = false;
		leftbackPaper.instaCheat = false;
		leftfrontPaper.instaCheat = false;
		rightpaper.instaCheat = false;
		rightbackPaper.instaCheat = false;
		rightfrontPaper.instaCheat = false;
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
