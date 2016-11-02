using UnityEngine;
using System.Collections;

public class LookForCheaters : MonoBehaviour {

	public ImCheating student;
	public Catch ctch;
	public Transform[] points;
	public GameObject target;
	public GameObject dangerIndicator;
	private int destPoint = 0;
	private NavMeshAgent agent;
	private int checkForCheater = 0;
	public bool busted = false;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
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
			GoTween t2 = new GoTween (dangerIndicator.transform, 0.7f, new GoTweenConfig ().scale (new Vector3 (0.5f,0.001f,0.5f)));
			GoTweenChain chain = new GoTweenChain ().append (t1).append (t2);
			chain.play ();
			checkForCheater = 0;	
		}

		checkForCheater = Random.Range (0, 2);
	}

	void Update () {
		if (checkForCheater == 1 && agent.remainingDistance < 1f) {
			//Debug.Log ("Alert Player Here");
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
			agent.Stop ();
			//gameObject.transform.LookAt (target.transform.position);
		}
	}
}
