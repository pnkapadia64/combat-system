using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponChooser : MonoBehaviour
{
    [SerializeField]
    public GameObject buttonPrefab;

    void Start()
    {
        List<WeaponType> weaponNames = GameManager.Instance.GetAllWeaponNames();
        //Debug.Log("[w-chooser] " + weaponNames);
        for (int i=0; i< weaponNames.Count; i++ )
        {
            WeaponType weapon = weaponNames[i];
            GameObject newButton = Instantiate(buttonPrefab, gameObject.transform);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = weapon.ToString();
            newButton.GetComponent<Button>().onClick.AddListener(() => {
                GameManager.Instance.SelectWeaponForGame(weapon);
            });
        }
    }
}
