using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherAnimations : MonoBehaviour {

    public Animator anim;
    public PassedManager pm;
    public GameOverManager gom;
    public LookForCheaters lfc;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (lfc.paused == true)
        {
            anim.SetBool("IsPaused", true);
        }
        else {
            anim.SetBool("IsPaused", false);
        }

        if (pm.isWinning == true && pm.isOnGameOverPoint == true)
        {
            anim.SetBool("IsWinning", pm.isWinning);
        }
        else if (gom.isBusted == true && gom.isOnGameOverPoint == true) {
            anim.SetBool("IsBusted", gom.isBusted);
        }

        if (lfc.fakeCall == true)
        {
            anim.SetBool("IsCalled", true);
            anim.SetBool("CallFinished", false);
        }
        else {
            anim.SetBool("IsCalled", false);
            anim.SetBool("CallFinished", true);
        }
    }
}
