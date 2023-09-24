using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Weapon Manager for main player
public class GameManager : Singleton<GameManager>
{
    public WeaponType weaponChosen;

    protected override void Awake()
    {
        base.Awake();
    }

    public List<WeaponType> GetAllWeaponNames()
    {
        return WeaponInventory.GetInstance().GetAll();
    }

    public void SelectWeaponForGame(WeaponType weapon)
    {
        weaponChosen = weapon;
        SceneManager.LoadScene("MainScene");
    }
}
