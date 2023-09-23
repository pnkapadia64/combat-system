using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public WeaponType weaponChosen;

    protected override void Awake()
    {
        base.Awake();
    }

    public string GetBulletStr()
    {
        return weaponChosen.ToString();
    }

    public List<WeaponType> GetAllWeaponNames()
    {
        //Debug.Log("[GM] get all ");
        return WeaponInventory.GetInstance().GetAll();
    }

    public void SelectWeaponForGame(WeaponType weapon)
    {
        weaponChosen = weapon;
        //Debug.Log("weapon chosen " + weapon);
        SceneManager.LoadScene("MainScene");
    }
}
