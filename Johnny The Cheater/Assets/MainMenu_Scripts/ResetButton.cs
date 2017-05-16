using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour, IGvrGazeResponder {

	public Image img;
	public float barValue = 0;
	public bool fill = false;
    public GameObject resetMenuButton;
    public GameObject cancelButton;

	void Start () {
        gameObject.SetActive(false);
		img.fillAmount = barValue;
	}

	void Update () {

		ResetGame ();

		if (fill == true && barValue <= 1.1f) {
			barValue += Time.deltaTime;
			img.fillAmount = barValue;
		} else {
			barValue = 0;
			img.fillAmount = barValue;
			fill = false;
		}
	}

	void ResetGame(){
		if(fill == true && barValue >= 1.1f){
			PlayerPrefs.DeleteAll ();
            PlayerPrefs.SetString("isTutorialPlayed", "true");
            gameObject.SetActive(false);
            cancelButton.SetActive(false);
            resetMenuButton.SetActive(true);
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
