using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject weaponObject; // Prefab’a el ile atanacak

    private float damage, speed, range, cooldown, health, currentHealth;

    void Start()
    {
        Weapon weapon = weaponObject.GetComponent<Weapon>();
        if (weapon == null)
        {
            Debug.LogError("No Weapon component found on weapon object!");
            return;
        }

        WeaponType type = weapon.WeaponType;

        WeaponData data = WeaponDatabase.Instance.GetDataByType(type);
        if (data == null)
        {
            Debug.LogError("No WeaponData found for type: " + type);
            return;
        }

        damage = data.damage;
        speed = data.speed;
        range = data.range;
        cooldown = data.cooldown;
        health = data.health;
        currentHealth = health;
    }



        public virtual void TakeDamage(float amount)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
        }

        public void Attack()
        {
            Debug.Log($"{gameObject.name} attacks for {damage} damage!");
        }
}
