using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PotionSpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public float spawnTime;
	public GameObject[] potions;
	public GameOverManager gom;
	public PassedManager pm;
	public PauseTheGame pause;
	public AudioSource audSource;
	public AudioClip potionSpawned;
	Scene currentScene;

	void Awake(){

		switch (currentScene.name) {
		case "Level1":
			spawnTime = 4.0f;
			break;
		case "Level2":
			spawnTime = 4.0f;
			break;
		case "Level3":
			spawnTime = 4.0f;
			break;
		case "Level4":
			spawnTime = 4.0f;
			break;
		case "Level5":
			spawnTime = 4.0f;
			break;
		case "Level6":
			spawnTime = 4.0f;
			break;
		case "Level7":
			spawnTime = 4.0f;
			break;
		case "Level8":
			spawnTime = 4.0f;
			break;
		case "Level9":
			spawnTime = 4.0f;
			break;
		case "Level10": 
			spawnTime = 4.0f;
			break;
		default:
			break;
		}

	}

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
			audSource.PlayOneShot (potionSpawned);
		}
	}
}
