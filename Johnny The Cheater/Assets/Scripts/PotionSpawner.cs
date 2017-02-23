using UnityEngine;
using System.Collections;

public class PotionSpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public float spawnTime = 4.0f;
	public GameObject[] potions;
	public GameOverManager gom;
	public PassedManager pm;
	public PauseTheGame pause;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnPotions", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnPotions(){
		int spawnIndex = Random.Range (0, spawnPoints.Length);
		int potionIndex = Random.Range (0, potions.Length);
		if (gom.isGameOver == false && pm.isPassed == false && pause.isPaused == false) {
			Instantiate (potions [potionIndex], spawnPoints [spawnIndex].position, spawnPoints [spawnIndex].rotation);
		}
	}
}
