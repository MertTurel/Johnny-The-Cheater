using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Right : MonoBehaviour,IGvrGazeResponder {

	public bool fill = false;
	public Image img;
	public float barValue = 0;
	public ExamPaper cheatFrom;
	public ImCheating johnny;
	public bool cheatEnabled = true;
	public bool instaCheat = false;
    public StatManager sm;

	void Start(){
		img.fillAmount = barValue;
	}

	void Update(){

		Check ();

		if (fill == true && barValue >= 1.1f && cheatEnabled == true) {
			cheatFrom.right = true;
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
		} else {
			cheatFrom.right = false;
		}
	}

	void Check(){
		if (fill == true && barValue <= 1.1f && cheatEnabled == true) {
			if (instaCheat == false) {
				barValue += Time.deltaTime / sm.multiplier;
			} else if (instaCheat == true) {
				barValue += Time.deltaTime * 4;
			}			
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
