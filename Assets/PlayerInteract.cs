using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public GameObject player;
    public GameObject basin;
    public float currentDistPlayer;
    public float distPlayer;
    public float addReadinessPt;
    public float addTimePt;
    public float thisPosition;

    public Text narrativeText;
    [TextArea(15, 20)]
    public string narrative;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        //string narrative = "";
    }

    // Update is called once per framE
    void Update()
    {

    }

    public void Selected()
    {
        //Debug.Log("Raycast selection works");
        //currentDistPlayer = Vector3.Distance(player.transform.position, transform.position);

            narrativeText.text = narrative;
        //else
        //{
        //    narrativeText.text = "";
        //}

    }

    public void Interacted()
    {
        narrativeText.text = narrative;
        //Debug.Log(narrative);

        player.SendMessage("AddTime", addTimePt);
        player.SendMessage("AddReadiness", addReadinessPt);
        this.gameObject.SetActive(false);
    }
}
