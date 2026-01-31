using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EInteractable :Interactable
{
    void Interactable.Interact()
    {
        ButtonManager.instance.LightCandle();
        
    }
    void Dissapear()
    {
        Destroy(gameObject);
    }
}
