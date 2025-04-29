using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementData", menuName = "ScriptableObjects/MovementData", order = 1)]
public class movementData : ScriptableObject
{
    [Header("Player Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Player Combat Settings")]
    public int attackDamage = 10;
    public float attackRange = 2f;

    [Header("Player Health Settings")]
    public int maxHealth = 100;
    public int currentHealth = 100;

}
