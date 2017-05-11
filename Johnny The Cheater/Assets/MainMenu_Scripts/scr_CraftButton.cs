using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scr_CraftButton : MonoBehaviour, IGvrGazeResponder {

	public Image img;
	public float barValue = 0;
	public bool fill = false;
	public GameObject settings;
	public GameObject levelMap;
	public GameObject cam;
	public Transform target;

	// Use this for initialization
	void Start () {
		img.fillAmount = barValue;
	}

	// Update is called once per frame
	void Update () {

		if (fill == true && barValue >= 1.1f) {
			Go.to(cam.transform, 1f, new GoTweenConfig().position(new Vector3(target.transform.position.x,target.transform.position.y,target.transform.position.z)));
			levelMap.SetActive(true);
			settings.SetActive (true);
			gameObject.SetActive (false);
		}

		if (fill == true && barValue <= 1.1f) {
			barValue += Time.deltaTime;
			img.fillAmount = barValue;
		} else {
			barValue = 0;
			img.fillAmount = barValue;
			fill = false;
		}
	}

	public void OnGazeEnter(){
		fill = true;
	}

	public void OnGazeTrigger(){

	}

	public void OnGazeExit(){
		fill = false;
	}
}
