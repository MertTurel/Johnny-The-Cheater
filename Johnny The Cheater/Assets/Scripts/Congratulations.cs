using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Congratulations : MonoBehaviour {

    public PassedManager pm;
    public GameObject img;

	// Use this for initialization
	void Start () {
        img.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (pm.isPassed == true)
        {
            img.SetActive(true);
        }
    }
}
