using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatManager: MonoBehaviour {

    public float multiplier;

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            multiplier = 0.8f;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            multiplier = 0.9f;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            multiplier = 1.0375f;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            multiplier = 1.15f;
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            multiplier = 1.275f;
        }
        else if (SceneManager.GetActiveScene().name == "Level6")
        {
            multiplier = 1.39f;
        }
        else if (SceneManager.GetActiveScene().name == "Level7")
        {
            multiplier = 1.5125f;
        }
        else if (SceneManager.GetActiveScene().name == "Level8")
        {
            multiplier = 1.56f;
        }
        else if (SceneManager.GetActiveScene().name == "Level9")
        {
            multiplier = 1.62f;
        }
        else if (SceneManager.GetActiveScene().name == "Level10")
        {
            multiplier = 1.75f;
        }
 
    }
}
