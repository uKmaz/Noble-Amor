using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{

    private int attackRange;
    Player player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        damage = weaponData.knifeDamage;
    }


    public override void Attack(Vector2 direction)
    {
        Debug.Log("Punching with knife! Damage: " + damage);
        player.attacking = false;
    }
    


}
