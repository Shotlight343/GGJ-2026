    using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Mask : MonoBehaviour
{   
    [SerializeField]
    private GameObject maskSprite;

    public bool isMaskActive = false;
    public GameObject[] maskObjects;
    public GameObject[] noMaskObjects;
    public Color transparentColor = new Color(1f, 1f, 1f, 0f);
    public float delay = 0.01f;

    void Start()
    {
        maskSprite = GameObject.FindWithTag("MaskAnim");
        
        maskObjects =GameObject.FindGameObjectsWithTag("Mask");
        noMaskObjects =GameObject.FindGameObjectsWithTag("NoMask");

        foreach (GameObject mask in maskObjects)
        {
            mask.SetActive(false);
            maskSprite.SetActive(false);
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
        StartCoroutine(FlashMask());
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
        StartCoroutine(FlashMask());


    }
    IEnumerator FlashMask()
    {
         maskSprite.SetActive(true);
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        maskSprite.SetActive(false);

    }
}
