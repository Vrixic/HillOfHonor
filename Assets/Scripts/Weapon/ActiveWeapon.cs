using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private Transform weaponSpawnLocation;

    public Weapon CurrentWeapon { get; private set; }

    private void Start()
    {
        CurrentWeapon = Instantiate(WeaponPrefabContainer.Instance.GetWeaponPrefab(WeaponID.Bat), weaponSpawnLocation);      
    }

    public void OnAttack()
    {
        CurrentWeapon.Attack();
    }

    public void OnAnimationEvent(string eventName)
    {
        CurrentWeapon.OnAnimationEvent(eventName);
    }
}
