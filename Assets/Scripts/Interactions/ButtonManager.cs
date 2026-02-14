using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
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
    private int buttonCount = 5;
    private int buttonsPressed = 0;
    GameObject[] litCandles;
     public GameObject Door;
    void Start()
    {   
        

        litCandles = GameObject.FindGameObjectsWithTag("Candles");
        foreach (GameObject candle in litCandles)
        {
            candle.SetActive(false);
        }
        Door.GetComponent<VictoryDoor>().activeDoor =   false;
    }
    public void LightCandle()
    {
        if (buttonsPressed < buttonCount)
        {
            litCandles[buttonsPressed].SetActive(true);
            ++buttonsPressed;
            CheckButtons();
        }
    }
    void CheckButtons()
    {
        if (buttonsPressed >= buttonCount)
        {
            Door.GetComponent<VictoryDoor>().activeDoor = true;
        }
    }
}
