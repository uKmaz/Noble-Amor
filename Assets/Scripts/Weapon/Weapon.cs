using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    protected float cooldownTime;
    protected float lastAttackTime = -999f;
    protected static int damage;
    public int Damage { get { return damage; } }
    public abstract void Attack(Vector2 direction);

    protected bool CanAttack()
    {
        return Time.time >= lastAttackTime + cooldownTime;
    }
    protected void ResetAttackCooldown()
    {
        lastAttackTime = Time.time;
    }
}
