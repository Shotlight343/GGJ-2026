using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelWatcher : MonoBehaviour
{
    [SerializeField]
    private Camera mCam;
    public GameObject angel;

    [SerializeField] private float watchDistance = 15f;

    void Start()
    {
        mCam = Camera.main;
    }

    void Update()
    {
        GameObject nearest = Watch();
        if(nearest == angel)
        {
            WeepingAngelAIScript.instance.Freeze();
            Debug.Log("Freeze Angel");
        }
        else
        {
            WeepingAngelAIScript.instance.Chase();
        }
    }

    private GameObject Watch()
    {
        GameObject result = null;
        var ray = mCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray ,out var hit, watchDistance)){
        result = hit.transform.gameObject;}

        Debug.Log("watching: " + result);
        
        return result;
    }
}
