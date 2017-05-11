using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherAnimations : MonoBehaviour {

    public Animator anim;
    public PassedManager pm;
    public GameOverManager gom;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (pm.isWinning == true)
        {
            anim.SetBool("IsWinning", pm.isWinning);
        }
        else if (gom.isBusted == true) {
            anim.SetBool("IsBusted", gom.isBusted);
        }
    }
}
