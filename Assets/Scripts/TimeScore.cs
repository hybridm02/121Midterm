using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    public Text timeText;
    public static float timePt = 31500f; //8:30AM, 8 * 60 * 60 + 30 * 60 = 30600s 

    // Start is called before the first frame update
    void Start()
    {
        UpdateTimerPt();
    }

    // Update is called once per frame
    void UpdateTimerPt()
    {
        //int seconds = (int)(timeMin % 60);
        int minutes = (int)(timePt / 60) % 60;
        int hours = (int)(timePt / 3600) % 24;
        string timePtString = string.Format("{0:0}:{1:00}", hours, minutes);
        timeText.text = timePtString + " AM";
    }

    void AddTime(float addTimePt)
    {
        timePt += addTimePt;
        UpdateTimerPt();

    }
}
