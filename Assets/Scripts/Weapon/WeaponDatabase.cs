using UnityEngine;
using System.Collections.Generic;

public class WeaponDatabase : MonoBehaviour
{
    public List<WeaponData> weaponDataList;
    private Dictionary<WeaponType, WeaponData> weaponDataDict;

    private void Awake()
    {
        weaponDataDict = new Dictionary<WeaponType, WeaponData>();
        foreach (var data in weaponDataList)
        {
            weaponDataDict[data.weaponType] = data;
        }
    }

    public WeaponData GetDataByType(WeaponType type)
    {
        return weaponDataDict.TryGetValue(type, out var data) ? data : null;
    }

    public static WeaponDatabase Instance { get; private set; }

    private void OnEnable()
    {
        Instance = this;
    }
}
