using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopDataController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private TextMeshProUGUI GunName, GunDamage, GunPrice, GunFirerate;

    public void ChangeData(Weapon weaponData)
    {
        GunName.text = weaponData.GunName;
        GunDamage.text = "Damage: " + weaponData.GunDamage.ToString();
        GunPrice.text = "Price: " + weaponData.GunPrice.ToString();
        GunFirerate.text = "Firerate: " + weaponData.GunFirerate.ToString();
    }
}
