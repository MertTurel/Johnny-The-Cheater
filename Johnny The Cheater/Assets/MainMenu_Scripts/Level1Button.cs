using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Button : MonoBehaviour, IGvrGazeResponder {

	public Image img;
    public Image star1;
    public Image star2;
    public Image star3;
    public Image star4;

    public float barValue = 0;
	public bool fill = false;

	void Start () {
		img.fillAmount = barValue;
        star1.enabled = false;
        star2.enabled = false;
        star3.enabled = false;
        star4.enabled = false;
	}

	void Update () {

		LoadLevel1 ();

        CheckStars ();

		if (fill == true && barValue <= 1.1f) {
			barValue += Time.deltaTime;
			img.fillAmount = barValue;
		} else {
			barValue = 0;
			img.fillAmount = barValue;
			fill = false;
		}
    }

    void CheckStars() {
        if (PlayerPrefs.GetString("Level1PassedWith") == "Level1D" || PlayerPrefs.GetString("Level1PassedWith") == "Level1DD")
        {
            star1.enabled = true;
        }
        else if (PlayerPrefs.GetString("Level1PassedWith") == "Level1C" || PlayerPrefs.GetString("Level1PassedWith") == "Level1CC")
        {
            star1.enabled = true;
            star2.enabled = true;
        }
        else if (PlayerPrefs.GetString("Level1PassedWith") == "Level1B" || PlayerPrefs.GetString("Level1PassedWith") == "Level1BB" || PlayerPrefs.GetString("Level1PassedWith") == "Level1A")
        {
            star1.enabled = true;
            star2.enabled = true;
            star3.enabled = true;
        }
        else if (PlayerPrefs.GetString("Level1PassedWith") == "Level1AA")
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
