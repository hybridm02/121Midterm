using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public GameObject player;
    public float currentDistPlayer;
    public float distPlayer;
    public float addReadinessPt;
    public float addTimePt;
    public float thisPosition;

    public Text narrativeText;
    public string narrative;

    // Start is called before the first frame update
    void Start()
    {
        //string narrative = "";
    }

    // Update is called once per framE
    void Update()
    {
        //Debug.Log(transform.localPosition);
        currentDistPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (currentDistPlayer < distPlayer){
            narrativeText.text = narrative; 
            if(Input.GetKeyDown(KeyCode.E)){
                player.SendMessage("AddTime", addTimePt);
                player.SendMessage("AddReadiness", addReadinessPt);
                //this.gameObject.SetActive(false);
            }
        } else {
            narrativeText.text = "";
        }




    }
}
