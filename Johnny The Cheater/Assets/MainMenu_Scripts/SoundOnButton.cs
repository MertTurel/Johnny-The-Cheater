using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnButton : MonoBehaviour, IGvrGazeResponder {

    public Image img;
    public AudioSource backGroundMusic;
    public GameObject soundOffButton;
    public float barValue = 0;
    public bool fill = false;

    void Start()
    {
        img.fillAmount = barValue;
        gameObject.SetActive(false);
    }

    void Update()
    {
        SoundOn();

        if (fill == true && barValue <= 1.1f)
        {
            barValue += Time.deltaTime;
            img.fillAmount = barValue;
        }
        else {
            barValue = 0;
            img.fillAmount = barValue;
            fill = false;
        }
    }

    void SoundOn()
    {
        if (fill == true && barValue >= 1.1f)
        {
            backGroundMusic.Play();
            gameObject.SetActive(false);
            soundOffButton.SetActive(true);
        }
    }

    public void OnGazeEnter()
    {
        fill = true;
    }

    public void OnGazeExit()
    {
        fill = false;
    }

    public void OnGazeTrigger()
    {

    }
}
