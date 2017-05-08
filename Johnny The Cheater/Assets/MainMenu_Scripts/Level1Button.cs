using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Button : MonoBehaviour, IGvrGazeResponder {

	public Image img;
	public float barValue = 0;
	public bool fill = false;

	void Start () {
		img.fillAmount = barValue;
	}

	void Update () {

		LoadLevel1 ();

		if (fill == true && barValue <= 1.1f) {
			barValue += Time.deltaTime;
			img.fillAmount = barValue;
		} else {
			barValue = 0;
			img.fillAmount = barValue;
			fill = false;
		}
	}

	void LoadLevel1(){
		if(fill == true && barValue >= 1.1f){
			SceneManager.LoadScene("Level1");
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
