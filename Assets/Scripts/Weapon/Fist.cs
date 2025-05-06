using UnityEngine;

public class Fist : Weapon
{
    [SerializeField] private Transform attackerTransform;
    [SerializeField] private LayerMask enemyLayer;
    public override WeaponType WeaponType => WeaponType.Fist;

    protected override void Start()
    {
        base.Start();
    }

    public override void Attack(Vector2 direction)
    {
        if (!CanAttack()) return;
        ResetAttackCooldown();

        Vector2 origin = (Vector2)attackerTransform.position + direction * 0.5f;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, range, enemyLayer);
        if (hit.collider != null)
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }        Debug.Log("Punching with fist!");
    }
    public void SetAttacker(Transform attacker)
    {
        attackerTransform = attacker;
    }
}



