﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Button : MonoBehaviour, IGvrGazeResponder {

	public Image circle;
	public Image unlockedLevel;
	public Image lockedLevel;
    public Image starToFill1;
    public Image starToFill2;
    public Image starToFill3;
    public Image starToFill4;
    public Image star1;
    public Image star2;
    public Image star3;
    public Image star4;
    public Text info;
	public float barValue = 0;
	public bool fill = false;
	public bool isLocked = false;
	public LevelMap map; 
	const int starNeedToUnlock = 150;

	void Start () {
		if (map.stars >= starNeedToUnlock) {
			lockedLevel.enabled = false;
			unlockedLevel.enabled = true;
			circle.enabled = true;
			info.enabled = false;
			circle.fillAmount = barValue;
			isLocked = false;
            starToFill1.enabled = true;
            starToFill2.enabled = true;
            starToFill3.enabled = true;
            starToFill4.enabled = true;
        } else {
			info.enabled = false;
			info.text = map.stars + " / " + starNeedToUnlock;
			isLocked = true;
			circle.enabled = false;
			unlockedLevel.enabled = false;
			lockedLevel.enabled = true;
            starToFill1.enabled = false;
            starToFill2.enabled = false;
            starToFill3.enabled = false;
            starToFill4.enabled = false;
        }
	}

	void Update () {

		if (map.stars >= starNeedToUnlock) {
			lockedLevel.enabled = false;
			unlockedLevel.enabled = true;
			circle.enabled = true;
			info.enabled = false;
			isLocked = false;
            starToFill1.enabled = true;
            starToFill2.enabled = true;
            starToFill3.enabled = true;
            starToFill4.enabled = true;
        }
        else {
			isLocked = true;
			circle.enabled = false;
			unlockedLevel.enabled = false;
			lockedLevel.enabled = true;
            starToFill1.enabled = false;
            starToFill2.enabled = false;
            starToFill3.enabled = false;
            starToFill4.enabled = false;
        }

		LoadLevel2 ();

        CheckStars ();

		if (fill == true && barValue <= 1.1f) {
			barValue += Time.deltaTime;
			circle.fillAmount = barValue;
		} else {
			barValue = 0;
			circle.fillAmount = barValue;
			fill = false;
		}
	}

    void CheckStars() {
        if (PlayerPrefs.GetString("Level2PassedWith") == "Level2D" || PlayerPrefs.GetString("Level2PassedWith") == "Level2DD")
        {
            star1.enabled = true;
        }
        else if (PlayerPrefs.GetString("Level2PassedWith") == "Level2C" || PlayerPrefs.GetString("Level2PassedWith") == "Level2CC")
        {
            star1.enabled = true;
            star2.enabled = true;
        }
        else if (PlayerPrefs.GetString("Level2PassedWith") == "Level2B" || PlayerPrefs.GetString("Level2PassedWith") == "Level2BB" || PlayerPrefs.GetString("Level2PassedWith") == "Level2A")
        {
            star1.enabled = true;
            star2.enabled = true;
            star3.enabled = true;
        }
        else if (PlayerPrefs.GetString("Level2PassedWith") == "Level2AA")
        {
            star1.enabled = true;
            star2.enabled = true;
            star3.enabled = true;
            star4.enabled = true;
        }
        else {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
            star4.enabled = false;
        }
    }

	void LoadLevel2(){
		if(fill == true && barValue >= 1.1f){
			SceneManager.LoadScene("Level2");
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
