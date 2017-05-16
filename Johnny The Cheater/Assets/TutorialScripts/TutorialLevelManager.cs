using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialLevelManager : MonoBehaviour {

    public Text infoTutorial;
    public PassedManager pm;
    public GameOverManager gom;
    public LookForCheaters lfc;

	// Use this for initialization
	void Start () {
        infoTutorial.text = "NOW START PLAYING TRY TO GET AT LEAST 60 POINTS !";
	}
	
	// Update is called once per frame
	void Update () {
        if (pm.isPassed == true)
        {
            infoTutorial.text = "YOU PASSED TUTORIAL !";
        }

        if (pm.isOnGameOverPoint == true)
        {
            
        }
       
        if (gom.isBusted == true)
        {
            infoTutorial.color = Color.red;
            infoTutorial.text = "YOU GET CAUGHT !";
        }
    }
}
