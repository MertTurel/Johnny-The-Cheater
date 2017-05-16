using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    //Teacher
    public GameObject teacher;

    //Students and Papers
    public GameObject rightFrontPaper;
    public GameObject rightFrontCircle;
    public GameObject rightFrontStudent;
    public GameObject rightPaper;
    public GameObject rightCircle;
    public GameObject rightStudent;
    public GameObject rightBackPaper;
    public GameObject rightBackCircle;
    public GameObject rightBackStudent;
    public GameObject backPaper;
    public GameObject backCircle;
    public GameObject backStudent;
    public GameObject leftFrontPaper;
    public GameObject leftFrontCircle;
    public GameObject leftFrontStudent;
    public GameObject leftPaper;
    public GameObject leftCircle;
    public GameObject leftStudent;
    public GameObject leftBackPaper;
    public GameObject leftBackCircle;
    public GameObject leftBackStudent;

    //Time
    public GameObject clock;

    //MyExamPaper and Dependencies
    public ExamPaper exPap;
    public GameOverManager gom;
    public PassedManager pm;
    public GameObject potionSpawner;

    //Information Text
    public Text infoText;

    //TutorialSteps
    public bool step1 = true;
    public bool step2 = false;
    public bool step3 = false;
    public bool step4 = false;
    public bool step5 = false;
    public bool step6 = false;
    public bool step7 = false;
    public bool step8 = false;

    //Sounds
    public AudioSource audSource;
    public AudioClip potionSpawned;
    public bool isBluePlayed;
    public bool isRedPlayed;
    public bool isGreenPlayed;

    //Potion
    public GameObject bluePot;
    public GameObject redPot;
    public GameObject greenPot;
    public BluePotTutorial bluePotionTutorial;
    public RedPotTutorial redPotionTutorial;
    public GreenPotTutorial greenPotionTutorial;
    public FakeCall fc;
    public InstaCheat insCheat;
    public StopTimeSkill sts;

    //Papers
    public LeftFront leftFPaperScript;
    public Left leftPaperScript;
    public LeftBack leftBPaperScript;
    public Back backPaperScript;
    public RightFront rightFPaperScript;
    public Right rightPaperScript;
    public RightBack rightBPaperScript;

    // Use this for initialization
    void Start () {
        //Teacher Deactive
        teacher.SetActive(false);

        //Students And Papers Deactive
        rightFrontPaper.SetActive(false);
        rightFrontCircle.SetActive(false);
        rightFrontStudent.SetActive(false);
        rightBackPaper.SetActive(false);
        rightBackCircle.SetActive(false);
        rightBackStudent.SetActive(false);
        backPaper.SetActive(false);
        backCircle.SetActive(false);
        backStudent.SetActive(false);
        leftFrontPaper.SetActive(false);
        leftFrontCircle.SetActive(false);
        leftFrontStudent.SetActive(false);
        leftPaper.SetActive(false);
        leftCircle.SetActive(false);
        leftStudent.SetActive(false);
        leftBackPaper.SetActive(false);
        leftBackCircle.SetActive(false);
        leftBackStudent.SetActive(false);

        //Time Deactive
        clock.SetActive(false);

        //Potions
        bluePot.SetActive(false);
        redPot.SetActive(false);
        greenPot.SetActive(false);
        potionSpawner.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (step1 == true)
        {
            if (exPap.score == 0)
            {
                infoText.text = "MOVE THE RED DOT ON THE EXAM PAPER OF THE STUDENT AT RIGHT AND WAIT UNTIL THE GREEN BAR IS FULL";
            }
            if (exPap.score == 5)
            {
                rightPaper.SetActive(false);
                rightStudent.SetActive(false);
                rightCircle.SetActive(false);
                step1 = false;
                step2 = true;
            }
        }

        else if (step2 == true)
        {
            teacher.SetActive(true);
            infoText.text = "NOW TEACHER IS ACTIVE, WHEN YOU HEAR THE ALERT SOUND GIVE UP CHEATING IMMEDIATELY";
            rightFrontStudent.SetActive(true);
            rightFrontPaper.SetActive(true);
            rightFrontCircle.SetActive(true);

            if (gom.isBusted == true)
            {
                infoText.color = Color.red;
                infoText.text = "YOU GET CAUGHT !";
            }
            else if (exPap.score == 10)
            {
                step2 = false;
                step3 = true;
            }
        }

        else if (step3 == true)
        {
            rightFrontStudent.SetActive(false);
            rightFrontPaper.SetActive(false);
            rightFrontCircle.SetActive(false);

            if (isBluePlayed == false)
            {
                audSource.PlayOneShot(potionSpawned);
                isBluePlayed = true;
            }

            infoText.text = "WHEN YOU HEAR THIS SOUND LOOK AROUND TO FIND POTION SPAWNED";
            bluePot.SetActive(true);

            if (bluePotionTutorial.isGone == true)
            {
                infoText.text = "NOW MOVE THE RED DOT ON THE PHONE ICON AT YOUR PAPER TO ACTIVATE THE SKILL";
                bluePot.SetActive(false);
                if (fc.isActivated == true)
                {
                    infoText.text = "NOW THE TEACHER IS DEALING WITH A FAKE CALL, HE CAN'T SEE YOU ARE CHEATING";
                    if (fc.remainingValue <= 0.05f && fc.remainingValue > 0f)
                    {
                        infoText.text = "NOW THE TIME IS ACTIVATED YOU HAVE 60 SECONDS FOR THE EXAM";
                        step3 = false;
                        step4 = true;
                    }
                }
            }

        }

        else if (step4 == true)
        {
            teacher.SetActive(false);
            clock.SetActive(true);

            if (isGreenPlayed == false)
            {
                audSource.PlayOneShot(potionSpawned);
                isGreenPlayed = true;
            }

            greenPot.SetActive(true);

            if (greenPotionTutorial.isGone == true)
            {
                infoText.text = "NOW MOVE THE RED DOT ON THE CLOCK ICON AT YOUR PAPER TO ACTIVATE THE SKILL";
                greenPot.SetActive(false);
                if (sts.isActivated == true)
                {
                    infoText.text = "NOW THE TIME HAS STOPPED";
                    if (sts.remainingValue <= 0.05f && sts.remainingValue > 0f)
                    {
                        infoText.text = "USE THAT RED POTION TO CHEAT INSTANTLY !";
                        step4 = false;
                        step5 = true;
                    }
                }
            }
        }

        else if (step5 == true)
        {
            clock.SetActive(false);

            if (isRedPlayed == false)
            {
                audSource.PlayOneShot(potionSpawned);
                isRedPlayed = true;
            }

            redPot.SetActive(true);

            if (redPotionTutorial.isGone == true)
            {
                redPot.SetActive(false);
                infoText.text = "NOW MOVE THE RED DOT ON THE LIGHTNING ICON AT YOUR PAPER TO ACTIVATE THE SKILL";

                if (insCheat.isActivated == true)
                {
                    infoText.text = "NOW YOU CAN CHEAT INSTANTLY !";
                    rightFrontStudent.SetActive(true);
                    rightFrontPaper.SetActive(true);
                    rightFrontCircle.SetActive(true);
                    if (exPap.score == 15)
                    {
                        infoText.text = "NOW LOOK AT THE EXAM PAPER OF THE STUDENT AT LEFT FRONT";
                        step5 = false;
                        step6 = true;
                    }
                }
            }

        }

        else if (step6 == true)
        {
            rightFrontStudent.SetActive(false);
            rightFrontPaper.SetActive(false);
            rightFrontCircle.SetActive(false);

            leftFrontStudent.SetActive(true);
            leftFrontCircle.SetActive(true);
            leftFrontPaper.SetActive(true);
            if (exPap.score == 20)
            {
                infoText.text = "LOOK ONE MORE TIME !";
            }
            if (exPap.score == 25)
            {
                infoText.text = "YOUR FRIEND IS ANGRY TRY ANOTHER STUDENT NOW !";
                step6 = false;
                step7 = true;
            }
        }

        else if (step7 == true)
        {
            leftStudent.SetActive(true);
            leftCircle.SetActive(true);
            leftPaper.SetActive(true);

            if (exPap.score == 30)
            {
                infoText.text = "NOW START PLAYING TRY TO GET AT LEAST 60 POINTS !";
                leftFrontStudent.SetActive(false);
                leftFrontCircle.SetActive(false);
                leftFrontPaper.SetActive(false);

                leftStudent.SetActive(false);
                leftCircle.SetActive(false);
                leftPaper.SetActive(false);

                exPap.score = 0;
                exPap.scoreInfo.text = "Score = " + exPap.score;
                exPap.scoreCircle.fillAmount = exPap.score;

                exPap.remainingRightF = 2;
                exPap.remainingRightB = 2;
                exPap.remainingRight = 4;
                exPap.remainingLeftF = 2;
                exPap.remainingLeftB = 2;
                exPap.remainingLeft = 4;
                exPap.remainingBack = 4;

                rightFPaperScript.cheatEnabled = true;
                rightBPaperScript.cheatEnabled = true;
                rightPaperScript.cheatEnabled = true;
                leftFPaperScript.cheatEnabled = true;
                leftBPaperScript.cheatEnabled = true;
                leftPaperScript.cheatEnabled = true;
                backPaperScript.cheatEnabled = true;

                step7 = false;
                step8 = true;
            }
        }

        else if (step8 == true)
        {

            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("TutorialSceneContinue");

        }
    }
}
