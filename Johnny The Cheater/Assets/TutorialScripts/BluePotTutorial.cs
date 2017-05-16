using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BluePotTutorial : MonoBehaviour, IGvrGazeResponder {

    public PauseTheGame pause;
    public GameOverManager gom;
    public PassedManager pm;
    public bool isGone = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, Time.deltaTime * 50, 0));
    }

    public void OnGazeEnter() {
        if (pause.GetComponent<PauseTheGame>().isPaused == false && gom.GetComponent<GameOverManager>().isGameOver == false && pm.GetComponent<PassedManager>().isPassed == false)
        {
            PlayerPrefs.SetInt("CallPot", PlayerPrefs.GetInt("CallPot") + 1);
            gameObject.SetActive(false);
            isGone = true;
        }
    }

    public void OnGazeExit() {

    }

    public void OnGazeTrigger() {

    }
}
