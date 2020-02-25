using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndControll : MonoBehaviour
{
    public GameObject player;
    public float currentDistPlayer;
    public float distPlayer;
    public Text timeText;
    public Text narrativeText;

    public float timeToSchool;
    //private static float finalTimeScore;
    //private static float finalReadinessScore;

    // Start is called before the first frame update
    void Start()
    {
        //blackBG.enabled = false;
        timeToSchool = Random.Range(60f, 1080f) + 1800f; //fixed 30 min train travel + random waiting 

    }

    // Update is called once per frame
    void Update()
    {
        //finalTimeScore = TimeScore.timePt;
        //finalReadinessScore = ReadinessBar.readinessPt;

        currentDistPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(currentDistPlayer < distPlayer){
            narrativeText.text = "press E to test luck";
            if (Input.GetKeyDown(KeyCode.E)){

                player.SendMessage("AddTime", timeToSchool);
                //Debug.Log("finaltimerscore:" + finalTimeScore);

                SceneManager.LoadScene(1);
                //EndCheck();
            }
        } else {
            narrativeText.text = "";
        }
    }
    
}
