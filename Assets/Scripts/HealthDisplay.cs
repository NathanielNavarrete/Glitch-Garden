using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;


    float health = 1;
    Text healthText;

    void Start()
    {
        health = baseLives - PlayerPrefsController.GetMasterDifficulty();
        healthText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("Difficulty setting currently is " + PlayerPrefsController.GetMasterDifficulty());
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public void DepleteHealth()
    {
        health -= 1;
        UpdateDisplay();
        if (health <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
