using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    protected static int damage;
    Player player;
    public int Damage { get { return damage; } }

    public abstract void Attack();
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {

            if (Input.GetKey(KeyCode.Q))
            {
                player.ThrowWeapon();
            }
        
    }
}
