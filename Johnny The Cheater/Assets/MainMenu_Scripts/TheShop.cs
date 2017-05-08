using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheShop : MonoBehaviour {

	public int timePotionPrice = 220; //1 adet
	public int speedPotionPrice = 240; //1 adet
	public int callPotionPrice = 260; //1 adet
	public int levelStarPrice = 300; //50 adet
	public Text coinInfo;
	public Text speedPotInfo;
	public Text callPotInfo;
	public Text timePotInfo;
	public Text starInfo;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("ShopPoint", PlayerPrefs.GetInt("ShopPoint") + PlayerPrefs.GetInt("ShopPointsToSet"));
		PlayerPrefs.SetInt ("ShopPointsToSet", 0);
		PlayerPrefs.SetInt ("PointBag", 0);
		PlayerPrefs.Save ();
	}
	
	// Update is called once per frame
	void Update () {

		coinInfo.text = "Coin = " + PlayerPrefs.GetInt ("ShopPoint");
		callPotInfo.text = "Call x" + PlayerPrefs.GetInt ("CallPot");
		timePotInfo.text = "Time x" + PlayerPrefs.GetInt ("TimePot");
		speedPotInfo.text = "Speed x" + PlayerPrefs.GetInt ("SpeedPot");
		starInfo.text = "Star x" + PlayerPrefs.GetInt ("MyStars");

	}
}
