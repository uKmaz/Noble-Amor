using System.Collections;
using UnityEngine;

public class Fist : Weapon
{
    private int attackRange; // Yakın mesafe için 1 birim yeterli
    private Player player;
    [SerializeField] public LayerMask enemyLayer;

    private void Start()
    {
        cooldownTime = weaponData.fist_Cooldown;
        attackRange = weaponData.fist_AttackRange;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        damage = weaponData.fistDamage;
    }

    // ÇALIŞMIYOR
    public override void Attack(Vector2 direction)
    {
        if (!CanAttack()) return;
        ResetAttackCooldown();

        Vector2 origin = player.transform.position + (Vector3)(direction * 0.5f); // biraz önden başlasın

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, attackRange, enemyLayer);

        if (hit.collider != null)
        {
            Debug.Log("Fist hit: " + hit.collider.name);

            // Düşmana damage ver
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        else
        {
            Debug.Log("Punch missed");
        }

        player.attacking = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (player == null) return;

        Vector2 origin = player.transform.position;
        Vector2 direction = player.transform.right; // örnek yön, düzenleyebilirsin

        Gizmos.color = Color.green;
        Gizmos.DrawLine(origin, origin + direction.normalized * attackRange);
    }

}
