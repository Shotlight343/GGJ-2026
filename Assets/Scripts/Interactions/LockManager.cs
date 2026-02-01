using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public static LockManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField]  
    private int keyCount = 3;
    private int keysCollected = 0;
    GameObject[] doorLocks;
    public GameObject Door;
    void Start()
    {
        doorLocks = GameObject.FindGameObjectsWithTag("DoorLocks");
        foreach (GameObject padlock in doorLocks)
        {
            padlock.SetActive(true);
        }
    }
    public void RemoveLock()
    {
        if (keysCollected < keyCount)
        {
            doorLocks[keysCollected].SetActive(false);
            keysCollected++;
            CheckKeys();
        }
    }
    void CheckKeys()
    {
        if (keysCollected >= keyCount)
        {
            Door.GetComponent<VictoryDoor>().enabled = true;
        }
    }
}
