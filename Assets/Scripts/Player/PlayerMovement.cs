using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;

    /* Ducking Functionality member fields */

    private bool playerWantsToDuck = false;
    public bool IsDucking { get { return isDucking; } }
    private bool isDucking = false;

    private float targetDuckLayerWeight = 0f;

    /* Weapon for reading state */
    ActiveWeapon activeWeapon;

    private void Start()
    {
        activeWeapon = GetComponent<ActiveWeapon>();
        animator = GetComponent<Animator>();
    }

    public void OnDuck()
    {
        playerWantsToDuck = !playerWantsToDuck;

        if (playerWantsToDuck)
        {
            if (activeWeapon.CurrentWeapon.IsAttacking())
                return;

            targetDuckLayerWeight = 1f;
        }
        else
        {
            targetDuckLayerWeight = 0f;
        }

        if (!isDucking)
        {
            StartCoroutine(Duck());
        }
    }

    public void ForceStopDucking()
    {
        animator.SetLayerWeight(1, 0f);
        targetDuckLayerWeight = 0f;
    }

    IEnumerator Duck()
    {
        isDucking = true;

        float currentDuckWeight = animator.GetLayerWeight(1);

        while (true)
        {
            currentDuckWeight = Mathf.Lerp(currentDuckWeight, targetDuckLayerWeight, 5f * Time.deltaTime);

            animator.SetLayerWeight(1, currentDuckWeight);

            if ((playerWantsToDuck && currentDuckWeight > 0.999f) || currentDuckWeight < 0.001f)
                break;

            yield return null;
        }

        isDucking = false;
    }
}
