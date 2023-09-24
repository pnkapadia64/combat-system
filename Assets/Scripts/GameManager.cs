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

    // UI
    public List<WeaponType> GetAllWeaponNames()
    {
        return WeaponInventory.GetInstance().GetAll();
    }
    // UI
    public void SelectWeaponForGame(WeaponType weapon)
    {
        weaponChosen = weapon;
        SceneManager.LoadScene("MainScene");
    }
}
