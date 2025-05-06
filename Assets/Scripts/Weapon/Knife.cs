using UnityEngine;

public class Knife : Weapon
{
    private float attackRange;
    private Transform attackerTransform;
    public override WeaponType WeaponType => WeaponType.Knife;

    protected override void Start()
    {
        base.Start();
        attackRange = weaponData.range;
    }

    public override void Attack(Vector2 direction)
    {
        if (!CanAttack()) return;
        ResetAttackCooldown();

        Vector2 origin = (Vector2)attackerTransform.position + direction * 0.5f;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, range);
        if (hit.collider != null)
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Knife hit: " + hit.collider.name);
            }
        }
        else
        {
            Debug.Log("Knife attack missed");
        }
    }

    public void SetAttacker(Transform attacker)
    {
        attackerTransform = attacker;
    }
}
