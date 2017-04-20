using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMap: MonoBehaviour {

	public int stars;
	public Text starInfo;

	void Start () {
		PlayerPrefs.SetInt("MyStars", PlayerPrefs.GetInt("MyStars") + PlayerPrefs.GetInt ("LevelStars"));
		PlayerPrefs.SetInt ("LevelStars", 0);
		PlayerPrefs.Save ();
	}
	
	// Update is called once per frame
	void Update () {
		stars = PlayerPrefs.GetInt ("MyStars");
		starInfo.text = "Star = " + PlayerPrefs.GetInt ("MyStars");
	}
}
