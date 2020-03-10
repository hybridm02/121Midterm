using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmptyCollider : MonoBehaviour
{
    public Text narrativeText;
    //[TextArea(15, 20)]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        narrativeText.text = "I wouldn't go this way";
    }
}
