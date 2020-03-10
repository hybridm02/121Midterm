using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public float maxRaycastDist = 1000f;
    public Material highlightMaterial;
    //public Material defaultMaterial;

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
            narrativeText.text = "";
            //selectionRenderer.material = defaultMaterial;
            selectionRenderer.material = _selection.GetComponent<PlayerInteract>().defaultMaterial;
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
                Debug.Log("mouse over this");
                var selectionRenderer = selection.GetComponent<MeshRenderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;

                    selection.SendMessage("Narrative");
                }

                if (Input.GetMouseButton(0))
                {
                    if (selection.CompareTag("Interactable"))
                    {
                        selection.SendMessage("Interacted");
                    }
                }
                _selection = selection;
            }

        }
    }
}
