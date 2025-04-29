using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : Weapon
{

    private int attackRange;
    Player player;
    

    private void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        damage = weaponData.fistDamage;
    }

    private void Update()
    {

    }

    public override void Attack()
    {
        if (!player.HasWeapon)
        {
            Debug.Log("Punching with fist! Damage: " + damage);
            player.attacking = false;
        }

    }


}
