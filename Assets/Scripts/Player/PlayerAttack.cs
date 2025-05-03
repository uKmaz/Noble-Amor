using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Player player;
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        player.currentWeapon = transform.GetComponentInChildren<Weapon>();
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && player.currentWeapon != null) 
        {
            Vector2 attackDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position).normalized;
            player.currentWeapon.Attack(attackDirection);
            player.attacking = true;
        }
    }

}
