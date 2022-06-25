using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrefabContainer : MonoBehaviour
{
    private static WeaponPrefabContainer instance;
    public static WeaponPrefabContainer Instance { get { return instance; } }

    [SerializeField] private List<WeaponBlock> weapons;
    private Dictionary<WeaponID, Weapon> weaponsDict = new Dictionary<WeaponID, Weapon>();

    private void Awake()
    {
        if (instance == null)
            instance = this;

        foreach (WeaponBlock w in weapons)
        {
            weaponsDict.Add(w.weaponID, w.weapon);
        }
        weapons.Clear();
    }

    public Weapon GetWeaponPrefab(WeaponID id)
    {
        return weaponsDict[id];
    }

    [System.Serializable]
    private class WeaponBlock
    {
        public WeaponID weaponID;
        public Weapon weapon;
    }
}
