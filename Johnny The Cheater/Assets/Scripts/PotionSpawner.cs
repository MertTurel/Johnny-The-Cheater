using UnityEngine;
using UnityEditor;
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

	void Awake(){
        
        if (SceneManager.GetActiveScene().name == "Level1")
        { 
            spawnTime = 8.5f;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            spawnTime = 8.6f;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            spawnTime = 9.0f;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            spawnTime = 11.3f;
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            spawnTime = 11.4f;
        }
        else if (SceneManager.GetActiveScene().name == "Level6")
        {
            spawnTime = 11.5f;
        }
        else if (SceneManager.GetActiveScene().name == "Level7")
        {
            spawnTime = 14.5f;
        }
        else if (SceneManager.GetActiveScene().name == "Level8")
        {
            spawnTime = 15.0f;
        }
        else if (SceneManager.GetActiveScene().name == "Level9")
        {
            spawnTime = 15.2f;
        }
        else if (SceneManager.GetActiveScene().name == "Level10")
        {
            spawnTime = 20.0f;
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
