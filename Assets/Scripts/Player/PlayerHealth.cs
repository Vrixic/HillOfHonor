using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health gained every second")]
    [SerializeField] private float healthRegenAmount = 1f;

    /* Debug Field -> Only for visuals */
    [Header("Time it takes to regenarate 1 health in seconds -> (1f / healthRegenAmount)")]
    [SerializeField] private float healthRegenTime = 0f;

    public bool PlayerDied { get; set; } = false;

    private float health = 100f;

    private bool isHealthRegenerating = false;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /* Player Damage and Health Regeneration stuff */

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; 
        UpdateHealthUI();

        if (health < 1f)
        {
            PlayerDied = true;
            Debug.Log("Player has died!");
        }

        if (!isHealthRegenerating && health < 100f)
            StartCoroutine(RegenerateHealth());
    }

    private IEnumerator RegenerateHealth()
    {
        isHealthRegenerating = true;
        while (health < 100f)
        {
            float time = 1f;
            float targetHealth = Mathf.Clamp(health + healthRegenAmount, 0f, 100f);

            for (;time > 0f;)
            {
                time -= Time.deltaTime;
                health += (targetHealth - health) - (healthRegenAmount * time);

                UpdateHealthUI();
                yield return null;
            }
        }

        isHealthRegenerating = false;
    }

    public void OnAttack()
    {
        Debug.Log("Attack");
        animator.Play("Bash");
    }

    /* Health UI Stuff */

    private void UpdateHealthUI()
    {

    }

    private void OnValidate()
    {
        healthRegenTime = 1f / healthRegenAmount;
    }
}
