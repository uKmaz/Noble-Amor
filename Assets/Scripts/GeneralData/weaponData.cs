using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MovementData", menuName = "ScriptableObjects/WeaponData", order = 2)]
public class WeaponData : ScriptableObject
{
    public int fistDamage = 10;
    public float fistDelay = 0.5f;

}
