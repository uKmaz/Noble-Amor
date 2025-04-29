using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{

    private int attackRange;
    Player player;


    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        damage = weaponData.knifeDamage;
    }

    private void Update()
    {

    }

    public override void Attack()
    {
        Debug.Log("Punching with knife! Damage: " + damage);
        player.attacking = false;
    }
    


}
