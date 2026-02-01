using System.Collections;
using System.Collections.Generic;
using Polyperfect.Universal;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private FirstPersonController fpsController;

        void Start()
    {
           fpsController = GetComponent<FirstPersonController>();
           StartCoroutine(PauseDelay());
    }    
    IEnumerator PauseDelay()
    {
        fpsController.playerCanMove = false;
        yield return new WaitForSeconds(3.5f);
        fpsController.playerCanMove = true;
    }
    
}
