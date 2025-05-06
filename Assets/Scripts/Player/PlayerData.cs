using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("Player Movement Settings")]
    public float moveSpeed;

    [Header("Player Combat Settings")]
    public int attackDamage;

    [Header("Player Health Settings")]
    public int maxHealth;

}
