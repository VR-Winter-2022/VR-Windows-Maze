using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeftController : MonoBehaviour
{
    public static TimeLeftController instance;
    public float timeLeft = 120f;
    private Text timeLeftText;

    public GameObject endPanel;
    void Awake()
    {
        MakeInstance();
        timeLeftText = GameObject.Find("TimeText").GetComponent<Text>();
    }

    void Update()
    {
        Countdowntimer();
    }

    void MakeInstance() {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null) {
            Destroy(gameObject);
        }
    }

    void Countdowntimer() {
        
        timeLeft -= Time.deltaTime;
        //Debug.Log("TimeLeft: " + timeLeft);
        timeLeftText.text = "Time: " + timeLeft.ToString("F0");
    }

}
