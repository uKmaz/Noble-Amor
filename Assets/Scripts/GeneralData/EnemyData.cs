using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 3)]
public class EnemyData : ScriptableObject
{
    [Header("fistEnemy Movement Settings")]
    public float fist_moveSpeed = 5f;

    [Header("fistEnemy Combat Settings")]
    public int fist_attackDamage = 10;
    public float fist_attackRange = 3.5f;
    public float fist_cooldownTimer = 1.5f;

    [Header("fistEnemy Health Settings")]
    public int fist_maxHealth = 100;

}
