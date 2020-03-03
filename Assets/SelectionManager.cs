using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public float maxRaycastDist = 1000f;
    public Material highlightMaterial;
    public Material defaultMaterial;

    //string selectableTag = "Selectable";
    private Transform _selection;

    public Text narrativeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //deselect 
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<MeshRenderer>();
            //narrativeText.text = "";
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        //select 
        Ray camRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(camRay.origin, camRay.direction * maxRaycastDist, Color.green);

        RaycastHit hitObject;
        if (Physics.Raycast(camRay, out hitObject, maxRaycastDist))
        {
            var selection = hitObject.transform;
            if (selection.CompareTag("Selectable") || selection.CompareTag("Interactable"))
            {
                var selectionRenderer = selection.GetComponent<MeshRenderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }
                if (Input.GetMouseButton(0))
                {
                    //mouse 0 text, mouse 1 interact 
                    // = keycode.E
                    if (selection.CompareTag("Selectable"))
                    {
                        selection.SendMessage("Selected");
                    }
                    if (selection.CompareTag("Interactable"))
                    {
                        selection.SendMessage("Interacted");
                        //selection.GetComponent<PlayerInteract>().narrative;
                    }
                }
                _selection = selection;
            }

        }
    }
}
