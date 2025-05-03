using UnityEngine;

public class FistEnemy : Enemy
{
    private float moveSpeed;
    private float attackRange;
    private float attackCooldown;
    private int attackDamage;

    private float cooldownTimer;
    private Transform player;

    protected override void Start()
    {
        moveSpeed = enemyData.fist_moveSpeed;
        attackRange = enemyData.fist_attackRange;
        attackCooldown = enemyData.fist_attackRange;
        attackDamage = enemyData.fist_attackDamage;
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Move()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > attackRange)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            transform.position += (Vector3)(dir * moveSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        Move();

        cooldownTimer -= Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= attackRange && cooldownTimer <= 0f)
        {
            Attack();
            cooldownTimer = attackCooldown;
        }
    }

    private void Attack()
    {
        Debug.Log($"{gameObject.name} punches the player for {attackDamage} damage!");

        // Burada Player'a hasar verecek bir sistem ekleyebilirsin
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
             playerScript.TakeDamage(attackDamage); 
        }
    }
}
