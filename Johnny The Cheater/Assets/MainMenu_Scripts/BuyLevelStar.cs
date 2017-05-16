using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyLevelStar : MonoBehaviour, IGvrGazeResponder {

	public Image circle;
	public GameObject starImage;
	public Text priceInfo;
	public float barValue = 0;
	public bool isDisabled = false;
	public bool fill = false;
	public TheShop shop;
    public AudioSource audSource;
    public AudioClip buyItemSound;

	// Use this for initialization
	void Start () {
		circle.fillAmount = barValue;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt("ShopPoint") >= shop.levelStarPrice) {
			starImage.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, 1f);
			priceInfo.color = Color.black;
			isDisabled = false;
		} else {
			starImage.GetComponent<SpriteRenderer> ().material.color = new Color (1f, 1f, 1f, 0.4f);
			priceInfo.color = Color.red;
			isDisabled = true;
		}

		if(fill == true && barValue >= 1.1f){
			PlayerPrefs.SetInt ("ShopPoint", PlayerPrefs.GetInt ("ShopPoint") - shop.levelStarPrice);
			PlayerPrefs.SetInt ("MyStars", PlayerPrefs.GetInt ("MyStars") + 50);
            audSource.PlayOneShot(buyItemSound);
		}

		if (fill == true && barValue <= 1.1f) {
			barValue += Time.deltaTime;
			circle.fillAmount = barValue;
		} else {
			barValue = 0;
			circle.fillAmount = barValue;
			fill = false;
		}
	}

	public void OnGazeEnter(){
		if (isDisabled == false) {
			fill = true;
		}
	}

	public void OnGazeExit(){
		fill = false;
	}

	public void OnGazeTrigger(){

	}
}
