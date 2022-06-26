using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Image healthFill;
    public Gradient gradient;

    public void UpdateHealthBar()
    {
        // Updates Slider value to represent the players current health
        healthSlider.value = GameManager.Instance.PlayerHealth.GetPlayerCurrentHealth();
        //Debug.Log("Slider value = " + slider.value);
        healthFill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }

    public void SetHealthBarMax()
    {
        // Sets Slider max health to be whatever the players max health is
        healthSlider.maxValue = GameManager.Instance.PlayerHealth.GetPlayerCurrentHealth();

        healthFill.color = gradient.Evaluate(1f);
    }


}

