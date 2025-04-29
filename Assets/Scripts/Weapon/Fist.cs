using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : Weapon
{

    private int attackRange;
    Player player;
    private void Awake()
    {
        damage = weaponData.fistDamage;
    }

    private void Start()
    { 
        player = GetComponent<Player>();
    }

    private void Update()
    {

    }

    public override void Attack()
    {
        Debug.Log("Punching with fist! Damage: " + damage);
        player.attacking = false;
    }


}
