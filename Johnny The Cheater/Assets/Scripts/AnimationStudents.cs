using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStudents : MonoBehaviour {

    //Animators
    Animator animRF;
    Animator animR;
    Animator animRB;
    Animator animLF;
    Animator animL;
    Animator animLB;
    Animator animB;
    
    //Dependencies
    public ExamPaper exPap;
    public PassedManager pm;
    public bool isPlayedRF = false;
    public bool isPlayedR = false;
    public bool isPlayedRB = false;
    public bool isPlayedLF = false;
    public bool isPlayedL = false;
    public bool isPlayedLB = false;
    public bool isPlayedB = false;

    //Students 
    public GameObject rightFrontStudent;
    public GameObject rightStudent;
    public GameObject rightBackStudent;
    public GameObject leftFrontStudent;
    public GameObject leftStudent;
    public GameObject leftBackStudent;
    public GameObject backStudent;

    // Use this for initialization
    void Start () {
        animRF = rightFrontStudent.GetComponent<Animator>();
        animR = rightStudent.GetComponent<Animator>();
        animRB = rightBackStudent.GetComponent<Animator>();
        animLF = leftFrontStudent.GetComponent<Animator>();
        animL = leftStudent.GetComponent<Animator>();
        animLB = leftBackStudent.GetComponent<Animator>();
        animB = backStudent.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (exPap.remainingRightF == 0 && isPlayedRF == false)
        {
            animRF.SetBool("isAngry", true);
            isPlayedRF = true;
        }
        else {
            animRF.SetBool("isAngry", false);
        }

        if (exPap.remainingRight == 0 && isPlayedR == false)
        {
            animR.SetBool("isAngry", true);
            isPlayedR = true;
        }
        else {
            animR.SetBool("isAngry", false);
        }

        if (exPap.remainingRightB == 0 && isPlayedRB == false)
        {
            animRB.SetBool("isAngry", true);
            isPlayedRB = true;
        }
        else {
            animRB.SetBool("isAngry", false);
        }

        if (exPap.remainingLeftF == 0 && isPlayedLF == false)
        {
            animLF.SetBool("isAngry", true);
            isPlayedLF = true;
        }
        else {
            animLF.SetBool("isAngry", false);
        }

        if (exPap.remainingLeft == 0 && isPlayedL == false)
        {
            animL.SetBool("isAngry", true);
            isPlayedL = true;
        }
        else {
            animL.SetBool("isAngry", false);
        }

        if (exPap.remainingLeftB == 0 && isPlayedLB == false)
        {
            animLB.SetBool("isAngry", true);
            isPlayedLB = true;
        }
        else {
            animLB.SetBool("isAngry", false);
        }

        if (exPap.remainingBack == 0 && isPlayedB == false)
        {
            animB.SetBool("isAngry", true);
            isPlayedB = true;
        }
        else {
            animB.SetBool("isAngry", false);
        }

        if (pm.isPassed == true) {
            animRF.SetBool("IsWinning", true);
            animR.SetBool("IsWinning", true);
            animRB.SetBool("IsWinning", true);
            animLF.SetBool("IsWinning", true);
            animL.SetBool("IsWinning", true);
            animLB.SetBool("IsWinning", true);
            animB.SetBool("IsWinning", true);
        }

    }
}
