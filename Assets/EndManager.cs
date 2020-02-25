using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    public Text endText;

    //public float timeToSchool;
    private static float finalTimeScore;
    private static float finalReadinessScore;

    // Start is called before the first frame update
    void Start()
    {
        //timeToSchool = Random.Range(60f, 1080f) + 1800f; //fixed 30 min train travel + random waiting 
    }

    // Update is called once per frame
    void Update()
    {
        finalTimeScore = TimeScore.timePt;
        int minutes = (int)(finalTimeScore / 60) % 60;
        int hours = (int)(finalTimeScore / 3600) % 24;
        string timePtString = string.Format("{0:0}:{1:00}", hours, minutes) + "AM";

        finalReadinessScore = ReadinessBar.readinessPt;

        //SendMessage("AddTime", timeToSchool);

        if (finalTimeScore > 36000f)
        {
            if (finalReadinessScore > 80)
            {
                endText.text = "It's now " + timePtString + "\nYou Are LATE" + "\nBUT" + "\nYou Are Ready!";
            }
            else
            {
                endText.text = "It's now " + timePtString + "\nYou Are LATE" + "\nAND" + "\nYou Are NOT Ready!";
            }
        }
        else
        {
            if (finalReadinessScore > 80)
            {
                endText.text = "It's now " + timePtString + "\nYou Are On Time" + "\nAND" + "\nYou Are Ready!";
            }
            else
            {
                endText.text = "It's now " + timePtString + "\nYou Are On Time" + "\nBUT" + "\nYou Are NOT Ready!";
            }

        }
    }
}
