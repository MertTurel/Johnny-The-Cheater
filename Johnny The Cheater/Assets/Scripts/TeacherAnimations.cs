using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherAnimations : MonoBehaviour {

    public Animator anim;
    public PassedManager pm;
    public GameOverManager gom;
    public LookForCheaters lfc;
    public AudioSource audSource;
    public AudioClip history_anger;
    public AudioClip phys_anger;
    public AudioClip liter_anger;
    public AudioClip chem_anger;
    public AudioClip history_call;
    public AudioClip phys_call;
    public AudioClip liter_call;
    public AudioClip chem_call;

    //isPlayed Booleans
    bool histPlayed = false;
    bool physPlayed = false;
    bool litPlayed = false;
    bool chemPlayed = false;
    bool histCallPlayed = false;
    bool physCallPlayed = false;
    bool litCallPlayed = false;
    bool chemCallPlayed = false;

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
            if (gameObject.tag == "HistoryTeacher" && histPlayed == false)
            {
                audSource.PlayOneShot(history_anger);
                histPlayed = true;
            }
            else if (gameObject.tag == "LiteratureTeacher" && litPlayed == false)
            {
                audSource.PlayOneShot(liter_anger);
                litPlayed = true;
            }
            else if (gameObject.tag == "ChemistryTeacher" && chemPlayed == false)
            {
                audSource.PlayOneShot(chem_anger);
                chemPlayed = true;
            }
            else if (gameObject.tag == "PhysicsTeacher" && physPlayed == false)
            {
                audSource.PlayOneShot(phys_anger);
                physPlayed = true;
            }
        }

        if (lfc.fakeCall == true)
        {
            anim.SetBool("IsCalled", true);
            anim.SetBool("CallFinished", false);

            if (gameObject.tag == "HistoryTeacher" && histCallPlayed == false)
            {
                audSource.PlayOneShot(history_call);
                histCallPlayed = true;
            }
            else if (gameObject.tag == "LiteratureTeacher" && litCallPlayed == false)
            {
                audSource.PlayOneShot(liter_call);
                litCallPlayed = true;
            }
            else if (gameObject.tag == "ChemistryTeacher" && chemCallPlayed == false)
            {
                audSource.PlayOneShot(chem_call);
                chemCallPlayed = true;
            }
            else if (gameObject.tag == "PhysicsTeacher" && physCallPlayed == false)
            {
                audSource.PlayOneShot(phys_call);
                physCallPlayed = true;
            }
        }
        else {
            anim.SetBool("IsCalled", false);
            anim.SetBool("CallFinished", true);
        }
    }
}
