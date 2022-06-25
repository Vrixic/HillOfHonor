using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private Transform weaponSpawnLocation;

    public Weapon CurrentWeapon { get; private set; }

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        CurrentWeapon = Instantiate(WeaponPrefabContainer.Instance.GetWeaponPrefab(WeaponID.Bat), weaponSpawnLocation);
    }

    public void OnAttack()
    {
        if(playerMovement.IsDucking)
        {
            playerMovement.ForceStopDucking();
        }

        CurrentWeapon.Attack();
    }
    
    public void OnAnimationEvent(string eventName)
    {
        CurrentWeapon.OnAnimationEvent(eventName);
    }
}
