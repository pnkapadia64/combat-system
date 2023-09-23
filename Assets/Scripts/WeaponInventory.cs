using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    WEAPON_1,
    WEAPON_2,
    WEAPON_3,
}

public class WeaponAttributes
{
    public float speed;
    public float range;
    public float damage;
}

public class WeaponInventory
{
    private static WeaponInventory Instance;

    private Dictionary<WeaponType, WeaponAttributes> weapons = new Dictionary<WeaponType, WeaponAttributes>();

    // Singleton
    public static WeaponInventory GetInstance()
    {
        if (Instance == null)
        {
            Instance = new WeaponInventory();
        }
        return Instance;
    }

    public WeaponInventory()
    {
        weapons[WeaponType.WEAPON_1] = new WeaponAttributes { speed = 1f, range = 2f, damage = 3 };
        weapons[WeaponType.WEAPON_2] = new WeaponAttributes { speed = 5f, range = 5f, damage = 2 };
        weapons[WeaponType.WEAPON_3] = new WeaponAttributes { speed = 10f, range = 10f, damage = 1 };
    }

    public WeaponAttributes GetWeaponAttributes(WeaponType weaponType)
    {
        if (weapons.ContainsKey(weaponType))
        {
            return weapons[weaponType];
        }
        return null;
    }

    public List<WeaponType> GetAll()
    {
        //Debug.Log("[w-inv] get all");
        return new List<WeaponType>(weapons.Keys);
    }

}
