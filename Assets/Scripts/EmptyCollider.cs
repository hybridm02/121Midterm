using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyCollider : MonoBehaviour
{
    public Text narrativeText;
    public GameObject player; 
    //[TextArea(15, 20)]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("player hits Empty wall!!!");
    //        narrativeText.text = "I wouldn't go this way";
    //    }

    //}
    // void OnCollisionExit(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
    //        narrativeText.text = "";
    //    }
    //}
    public void OnTriggerEnter(Collider other)
    {
        narrativeText.text = "I wouldn't go this way";
    }


}
