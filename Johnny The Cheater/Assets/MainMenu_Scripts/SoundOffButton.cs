using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOffButton : MonoBehaviour,IGvrGazeResponder {

    public Image img;
    public AudioSource backGroundMusic;
    public GameObject soundOnButton;
    public float barValue = 0;
    public bool fill = false;

    void Start()
    {
        img.fillAmount = barValue;
    }

    void Update()
    {
        SoundOff();

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

    void SoundOff()
    {
        if (fill == true && barValue >= 1.1f)
        {
            backGroundMusic.Stop();
            gameObject.SetActive(false);
            soundOnButton.SetActive(true);
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
