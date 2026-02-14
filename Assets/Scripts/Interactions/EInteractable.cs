using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EInteractable :MonoBehaviour, Interactable
{
    void Interactable.Interact()
    {   if(ButtonManager.instance != null){
        ButtonManager.instance.LightCandle();
        Destroy(gameObject);}
        if(LockManager.instance != null){
        LockManager.instance.RemoveLock();
        Destroy(gameObject);}
    }

}
