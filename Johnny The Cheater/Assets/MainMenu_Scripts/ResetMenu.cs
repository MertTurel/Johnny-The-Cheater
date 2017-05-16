using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetMenu : MonoBehaviour, IGvrGazeResponder {

    public Image img;
    public float barValue = 0;
    public bool fill = false;
    public GameObject cancelButton;
    public GameObject resetButton;

    // Use this for initialization
    void Start () {
        img.fillAmount = barValue;
    }

    // Update is called once per frame
    void Update () {
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

        if (fill == true && barValue >= 1.1f)
        {
            gameObject.SetActive(false);
            resetButton.SetActive(true);
            cancelButton.SetActive(true);
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
