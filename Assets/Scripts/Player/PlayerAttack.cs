using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon currentWeapon;
    Player player;
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        currentWeapon = transform.GetComponentInChildren<Weapon>();
        player.currentWeapon = this.currentWeapon;
        if (Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.Mouse0))
        {
            currentWeapon.Attack();
            player.attacking = true;
        }
    }

}
