using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LookForCheaters : MonoBehaviour {

	public ImCheating student;
	public Catch ctch;
	public Transform[] points;
	public GameObject dangerIndicator;
	private int destPoint = 0;
	public GameOverManager gameMan;
	public TimeIsUp timeUp;

	public UnityEngine.AI.NavMeshAgent agent;
	public int checkForCheater = 0;

	public bool busted = false;
	public bool paused = false;
	public bool fakeCall = false;

	public Text scoreInfo;

	public AudioSource source;
	public AudioClip alert;

	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.autoBraking = false;

	
		GotoNextPoint();
	}

	void GotoNextPoint() {
		destPoint = Random.Range(0,3);

		if (points.Length == 0)
			return;

		if (checkForCheater == 0) {
			agent.destination = points[destPoint].position;
		}else if(checkForCheater == 1){
			GoTween t1 = new GoTween (dangerIndicator.transform, 0.7f, new GoTweenConfig ().scale (new Vector3 (40f,0.001f,40f)));
			GoTween t2 = new GoTween (dangerIndicator.transform, 0.7f, new GoTweenConfig ().scale (new Vector3 (0.2f,0.001f,0.2f)));
			GoTweenChain chain = new GoTweenChain ().append (t1).append (t2);
			chain.play ();
			agent.destination = points[destPoint].position;
			checkForCheater = 0;	
		}

		checkForCheater = Random.Range (0, 2);
	}

	void Update () {
		if (checkForCheater == 1 && agent.remainingDistance < 2f && paused == false && fakeCall == false) {
			if (!source.isPlaying) {
				source.PlayOneShot (alert);
			}
		}
		if (agent.remainingDistance < 0.1f){
			GotoNextPoint ();
		}
		if (student.isCheating == true) {
			ctch.cheating = true;
		} else if (student.isCheating == false) {
			ctch.cheating = false;
		}
		if (busted == true) {
			//Game Over
			gameMan.isGameOver = true;
			//Kağıttaki Değişiklikler
			scoreInfo.text = "BUSTED";
			//Busted Animasyonu Oynatılacak

		}
		if (timeUp.isTimeOver == true) {
			//Time is Up Animasyonu Oynatılacak
		}
		if (paused == true) {
			agent.Stop ();
		} else if(paused == false && busted == false) {
			agent.Resume ();
		}
		//FakeCall
		if (fakeCall == true) {
			agent.Stop ();
		} else if (fakeCall == false && busted == false && paused == false) {
			agent.Resume();
		}
	}	
}
