using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour, IGvrGazeResponder {

	public Image img;
	public float barValue = 0;
	public bool fill = false;

	void Start () {
		img.fillAmount = barValue;
		gameObject.SetActive (false);
	}

	void Update () {

		ReturnMain ();

		if (fill == true && barValue <= 1.1f) {
			barValue += Time.deltaTime;
			img.fillAmount = barValue;
		} else {
			barValue = 0;
			img.fillAmount = barValue;
			fill = false;
		}
	}

	void ReturnMain(){
		if(fill == true && barValue >= 1.1f){
			SceneManager.LoadScene("MainMenuScene");
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
