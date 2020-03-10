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

    public Material defaultMaterial;

    public Text narrativeText;
    [TextArea(15, 20)]
    public string narrative;

    // Start is called before the first frame update
    void Start()
    {
        defaultMaterial = GetComponent<MeshRenderer>().material;
        this.gameObject.SetActive(true);
        //string narrative = "";
    }

    // Update is called once per framE
    void Update()
    {

    }

    public void Narrative()
    {
            narrativeText.text = narrative;

    }

    public void Interacted()
    {
        //narrativeText.text = narrative;
        //Debug.Log(narrative);

        player.SendMessage("AddTime", addTimePt);
        player.SendMessage("AddReadiness", addReadinessPt);
        this.gameObject.SetActive(false);
    }

}
