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
    public string name;
    public float speed;
    public float range;
    public int damage;
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
        weapons[WeaponType.WEAPON_1] = new WeaponAttributes { name = "Weapon X", speed = 3f, range = 2f, damage = 15 };
        weapons[WeaponType.WEAPON_2] = new WeaponAttributes { name = "Weapon Y", speed = 5f, range = 5f, damage = 10 };
        weapons[WeaponType.WEAPON_3] = new WeaponAttributes { name = "Weapon Z", speed = 10f, range = 10f, damage = 5 };
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

    public WeaponAttributes GetEnemyWeaponAttributes()
    {
        return new WeaponAttributes { name = "Enemy Weapon", speed = 3.5f, range = 5f, damage = 5 };
    }
}
