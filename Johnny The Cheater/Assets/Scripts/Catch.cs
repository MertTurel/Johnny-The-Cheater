﻿using UnityEngine;
using System.Collections;

public class Catch : MonoBehaviour {
	public LookForCheaters lfc;
	public bool cheating;

	void OnTriggerStay(){
		Debug.Log ("In");
		if(cheating == true){
			Debug.Log ("I Get You");
			lfc.busted = true;
		}
	}
}
