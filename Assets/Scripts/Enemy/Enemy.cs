using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public EnemyData enemyData;
    private Weapon currentWeapon;
    protected int currentHealth;

    protected virtual void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
        currentWeapon.GetComponent<Rigidbody2D>().isKinematic = true;
        currentHealth = enemyData.fist_maxHealth;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage. Remaining HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        Destroy(gameObject);
    }

    public abstract void Move(); // her düşman kendine göre override edecek
}
