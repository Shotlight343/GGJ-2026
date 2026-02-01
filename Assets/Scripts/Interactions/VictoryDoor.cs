using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryDoor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private String nextLvl;
    public bool activeDoor = true;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(activeDoor)
            SceneSwitcher.instance.LoadLevel(nextLvl);
        }
    }
}
