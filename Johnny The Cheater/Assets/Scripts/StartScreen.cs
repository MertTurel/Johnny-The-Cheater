using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    public AudioSource audSource;
    public Image logo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        logo.CrossFadeAlpha(0f, 4f, false);
        if (audSource.isPlaying == false) {
            if (PlayerPrefs.GetString("isTutorialPlayed") != "true")
            {
                SceneManager.LoadScene("TutorialLevel");
            }
            else
            {
                SceneManager.LoadScene("MainMenuScene");    
            }
        }
    }
}
