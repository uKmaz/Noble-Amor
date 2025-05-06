using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponData weaponData;  // WeaponData üzerinden silahın verileri
    protected float cooldownTime;
    protected float lastAttackTime = -999f;
    protected float damage;
    protected float range;

    public abstract WeaponType WeaponType { get; }
    public float Damage { get { return damage; } }

    // Silahın türüne göre farklı verileri alır
    protected virtual void Start()
    {
        if (weaponData != null)
        {
            cooldownTime = weaponData.cooldown;
            damage = weaponData.damage;
            range = weaponData.range;
        }
        else
        {
            Debug.LogError("WeaponData is not assigned!");
        }
    }

    public abstract void Attack(Vector2 direction);

    // Silahın saldırı yapıp yapamayacağını kontrol etme
    protected bool CanAttack()
    {
        return Time.time >= lastAttackTime + cooldownTime;
    }

    // Saldırı zamanını sıfırlama
    protected void ResetAttackCooldown()
    {
        lastAttackTime = Time.time;
    }
}
