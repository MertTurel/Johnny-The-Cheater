using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FakeCall: MonoBehaviour, IGvrGazeResponder {

	public GameObject callImg;
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
	public GameObject cellphone;
	public LookForCheaters lfc;

	void Start () {
		useImg.fillAmount = useValue;
		remainingImg.fillAmount = remainingValue;
		cellphone.SetActive (false);
	}

	void Update () {

		quantityInfo.text = "x" + PlayerPrefs.GetInt("CallPot");

		//IfUserHasMoreDontDisable
		if (PlayerPrefs.GetInt("CallPot") > 0 && isActivated == false) {
			remainingValue = 1;
		}

		//Enable/Disable
		if (PlayerPrefs.GetInt("CallPot") >= 1 && remainingValue >= 1) {
			callImg.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, 1f);
			isDisabled = false;
		} else if(PlayerPrefs.GetInt("CallPot") <= 0 && remainingValue <= 0) {
			callImg.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, 0.4f);
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
			PlayerPrefs.SetInt ("CallPot", PlayerPrefs.GetInt ("CallPot") - 1);
		}
		if (isActivated == true && remainingValue > 0) {
			OpenFakeCall ();
			if (pause.isPaused == false) {
				remainingValue -= Time.deltaTime / 8;
			}
			remainingImg.fillAmount = remainingValue;

		} else {
			CloseFakeCall ();
			remainingImg.fillAmount = remainingValue;
			isActivated = false;
		}
	}

	//End of Update

	public void OpenFakeCall(){
		//SüresiBitene Kadar
		lfc.fakeCall = true;
		cellphone.SetActive (true);
		//Telefon Sesi Çalınacak
	}

	public void CloseFakeCall(){
		//SüresiBitene Kadar
		lfc.fakeCall = false;
		cellphone.SetActive (false);
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
