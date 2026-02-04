using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public FirstPersonController fpsController;
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    [SerializeField]
    private UnityEngine.UI.Image healthIndicator;
    [SerializeField]
    public Sprite[] healthSprites; 
    [SerializeField]
    private GameObject gameOverScreen;
    void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
        currentHealth = maxHealth;
        CheckHealth();
    }
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        --currentHealth;
        CheckHealth();
    }
    void Die()
    {
       SceneSwitcher.instance.LoadLevel("Level1");

    // Disable player movement
    fpsController.playerCanMove = false;

    // 🔓 UNLOCK THE CURSOR
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    Debug.Log("Player has died.");
    }
    void CheckHealth()
    {
        switch (currentHealth)
        {
            case 3:
               healthIndicator.sprite = healthSprites[0];
                break;
            case 2:
                healthIndicator.sprite = healthSprites[1];
                break;
            case 1:
                healthIndicator.sprite = healthSprites[2];
                break;
            default:
                Debug.Log("Health: Invalid");
                Die();
                break;
        }
  
    }
}
