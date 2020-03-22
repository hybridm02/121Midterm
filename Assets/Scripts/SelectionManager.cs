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

    public AudioSource selectionManager;
    public AudioSource audioManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        //deselect 
        if (_selection != null)
        {
            if (_selection.CompareTag("Selectable") || _selection.CompareTag("Interactable"))
            {
                var selectionRenderer = _selection.GetComponent<MeshRenderer>();
                narrativeText.text = "";
                //selectionRenderer.material = defaultMaterial;
                selectionRenderer.material = _selection.GetComponent<PlayerInteract>().defaultMaterial;
                _selection = null;
            } else if (_selection.CompareTag("Posters"))
            {
                var selectionRenderer = _selection.GetComponent<MeshRenderer>();
                narrativeText.text = "";
                //turn off specular highlights for posters
                selectionRenderer.material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");
                selectionRenderer.material.SetFloat("_SpecularHighlights", 0f);
                _selection = null;
            }


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
                //Debug.Log("mouse over this");
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
                        if(hitObject.collider.gameObject.name == "interactable8(airpods)")
                        {
                            selectionManager.Play();
                            audioManager.volume = 0.12f;
                        }
                    }
                }
                _selection = selection;
            } else if (selection.CompareTag("Posters"))
            {
                var selectionRenderer = selection.GetComponent<MeshRenderer>();
                if(selectionRenderer != null)
                {
                    //turn on specular highlights for posters
                    selectionRenderer.material.DisableKeyword("_SPECULARHIGHLIGHTS_OFF");
                    selectionRenderer.material.SetFloat("_SpecularHighlights", 1f);

                    selection.SendMessage("Narrative");
                }
                _selection = selection;
            }

        }
    }
}
