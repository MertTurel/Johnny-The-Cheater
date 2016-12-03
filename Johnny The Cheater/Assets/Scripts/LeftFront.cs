using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeftFront : MonoBehaviour,IGvrGazeResponder {

	public bool fill = false;
	public Image img;
	public float barValue = 0;
	public ExamPaper cheatFrom;
	public ImCheating johnny;
	public bool cheatEnabled = true;

	void Start(){
		img.fillAmount = barValue;
	}

	void Update(){

		Check ();

		if (fill == true && barValue >= 1.1f && cheatEnabled == true) {
			cheatFrom.leftFront = true;
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
		} else {
			cheatFrom.leftFront = false;
		}
	}

	void Check(){
		if (fill == true && barValue <= 1.1f && cheatEnabled == true) {
			barValue += Time.deltaTime;
			img.fillAmount = barValue;
		} else {
			barValue = 0;
			img.fillAmount = barValue;
			fill = false;
		}
	}

	public void OnGazeEnter(){
		if (cheatEnabled == true) {
			gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			johnny.isCheating = true;
			fill = true;
		} else {
			gameObject.GetComponent<Renderer> ().material.color = Color.gray;
			johnny.isCheating = false;
			fill = false;
		}
	}

	public void OnGazeExit(){
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
		johnny.isCheating = false;
		fill = false;
	}

	public void OnGazeTrigger(){

	}
}