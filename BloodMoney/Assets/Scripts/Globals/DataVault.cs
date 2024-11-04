using UnityEngine;

public class DataVault : MonoBehaviour
{
    private static DataVault _instance;
    public static DataVault Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("DataVault is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField]
    private Weapon[] GunData;

    [SerializeField]
    private Weapon[] ThrowablesData;

    [SerializeField]
    private Weapon[] SpecialData;

    [SerializeField]
    private Weapon[] CurrentDataArray; //?

    public int index;


    private void Start()
    {
        UIEvents.Instance.ShopMoveLeftClicked += MoveIndexLeft;
        UIEvents.Instance.ShopMoveRightClicked += MoveIndexRight;

        UIEvents.Instance.ShopWeaponsClicked += SetToWeaponsArray;
        UIEvents.Instance.ShopThrowablesClicked += SetToThrowablesArray;
        UIEvents.Instance.ShopSpecialsClicked += SetToSpecialsArray;

        SetToWeaponsArray();

    }
    public Weapon[] GetCurrentDataArray()
    {
        if (CurrentDataArray != null || CurrentDataArray.Length != 0)
            return CurrentDataArray;
        else
            return null;
    }
    public Weapon GetCurrentItem()
    {
        if (CurrentDataArray.Length != 0)
            return CurrentDataArray[index];
        else
        {
            Debug.LogError("DataVault GetCurrentItem returns null");
            return null;
        }

    }
    public void MoveIndexRight()
    {
        if (CurrentDataArray.Length != 0)
        {


            if (index == CurrentDataArray.Length - 1)
            {
                index = 0;
            }
            else
                index++;
        }
        else
            Debug.LogWarning("Current data array is empty");

    }
    public void MoveIndexLeft()
    {
        if (CurrentDataArray.Length != 0)
        {
            if (index == 0)
            {
                index = CurrentDataArray.Length - 1;
            }
            else
                index--;
        }
        else
            Debug.LogWarning("Current data array is empty");

    }
    private void SetToWeaponsArray()
    {
        CurrentDataArray = GunData;
        index = 0;
        Debug.Log("CurrentDataArray -> GunData");
    }
    private void SetToThrowablesArray()
    {
        CurrentDataArray = ThrowablesData;
        index = 0;
        Debug.Log("CurrentDataArray -> ThrowablesData");
    }
    private void SetToSpecialsArray()
    {
        CurrentDataArray = SpecialData;
        index = 0;
        Debug.Log("CurrentDataArray -> SpecialsData");
    }
    public void SetAllUnequiped(Weapon toNotUnequip)
    {
        switch (toNotUnequip.weaponClass)
        {
            case WeaponClass.None:
                break;

            case WeaponClass.Gun:
                EquipBooleanSwitch(GunData);
                break;

            case WeaponClass.Throwable:
                EquipBooleanSwitch(ThrowablesData);
                break;

            case WeaponClass.Special:
                EquipBooleanSwitch(SpecialData);
                break;

        }
    }
    private void EquipBooleanSwitch(Weapon[] dataArray)
    {
        foreach (Weapon weapon in dataArray)
        {
            weapon.isEquiped = false;

        }
    }
}
