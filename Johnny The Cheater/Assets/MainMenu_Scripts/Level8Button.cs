using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level8Button : MonoBehaviour, IGvrGazeResponder {

	public Image circle;
	public Image unlockedLevel;
	public Image lockedLevel;
	public Text info;
	public float barValue = 0;
	public bool fill = false;
	public bool isLocked = false;
	public LevelMap map; 
	const int starNeedToUnlock = 1950;

	void Start () {
		if (map.stars >= starNeedToUnlock) {
			lockedLevel.enabled = false;
			unlockedLevel.enabled = true;
			circle.enabled = true;
			info.enabled = false;
			circle.fillAmount = barValue;
			isLocked = false;
		} else {
			info.enabled = false;
			info.text = map.stars + " / " + starNeedToUnlock;
			isLocked = true;
			circle.enabled = false;
			unlockedLevel.enabled = false;
			lockedLevel.enabled = true;
		}
	}

	void Update () {

		if (map.stars >= starNeedToUnlock) {
			lockedLevel.enabled = false;
			unlockedLevel.enabled = true;
			circle.enabled = true;
			info.enabled = false;
			isLocked = false;
		} else {
			isLocked = true;
			circle.enabled = false;
			unlockedLevel.enabled = false;
			lockedLevel.enabled = true;
		}

		LoadLevel8 ();

		if (fill == true && barValue <= 1.1f) {
			barValue += Time.deltaTime;
			circle.fillAmount = barValue;
		} else {
			barValue = 0;
			circle.fillAmount = barValue;
			fill = false;
		}
	}

	void LoadLevel8(){
		if(fill == true && barValue >= 1.1f){
			SceneManager.LoadScene("Level8");
		}
	}

	public void OnGazeEnter(){
		if (isLocked == false) {
			fill = true;
		} else {
			info.enabled = true;
			info.text = map.stars + " / " + starNeedToUnlock;
		}
	}

	public void OnGazeExit(){
		fill = false;
		info.enabled = false;
	}

	public void OnGazeTrigger(){

	}
}
