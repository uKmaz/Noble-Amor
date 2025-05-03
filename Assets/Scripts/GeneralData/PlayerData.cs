using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("Player Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Player Combat Settings")]
    public int attackDamage = 10;
    public float attackRange = 2f;

    [Header("Player Health Settings")]
    public int maxHealth = 100;

}
