using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    protected static int damage;

    public int Damage { get { return damage; } }

    public abstract void Attack();
}
