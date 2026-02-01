using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
[SerializeField]
    private Camera mCam;
    public GameObject[] interactables;

    [SerializeField] private float watchDistance = 4f;

    void Start()
    {
        mCam = Camera.main;
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
    }

    void Update()
    {
        GameObject nearest = Visualize();
        foreach (GameObject interactable in interactables)
        {
            if (nearest == interactable)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.GetComponent<Interactable>().Interact();
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Backspace)){// 🔓 UNLOCK THE CURSOR
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
SceneSwitcher.instance.LoadLevel("MainMenuScene");}
    }

    private GameObject Visualize()
    {
        GameObject result = null;
        var ray = mCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray ,out var hit, watchDistance)){
        result = hit.transform.gameObject;}

        Debug.Log("watching: " + result);
        
        return result;
    }
    
}
