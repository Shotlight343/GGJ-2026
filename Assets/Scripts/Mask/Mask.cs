using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public bool isMaskActive = false;
    public GameObject[] maskObjects;
    public GameObject[] noMaskObjects;

    void Start()
    {
        maskObjects =GameObject.FindGameObjectsWithTag("Mask");
        noMaskObjects =GameObject.FindGameObjectsWithTag("NoMask");

        foreach (GameObject mask in maskObjects)
        {
            mask.SetActive(false);
        }
    }

    void Update()
    {
        UseMask();
    }

    void UseMask()
    {
        if (Input.GetMouseButtonDown(1) && !isMaskActive)
        {
            EquipMask();
        }
        else if (Input.GetMouseButtonDown(1) && isMaskActive)
        {
            RemoveMask();
        }
    }

    void EquipMask()
    {
        isMaskActive = true;

        foreach (GameObject mask in maskObjects)
        {
            mask.SetActive(true);
        }

        foreach (GameObject noMask in noMaskObjects)
        {
            noMask.SetActive(false);
        }
    }

    void RemoveMask()
    {
        isMaskActive = false;


        foreach (GameObject mask in maskObjects)
        {
            mask.SetActive(false);
        }

        foreach (GameObject noMask in noMaskObjects)
        {
            noMask.SetActive(true);
        }
    }
}
