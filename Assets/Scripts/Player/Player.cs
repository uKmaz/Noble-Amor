using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool HasWeapon;
    public bool attacking;
    PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        if (playerAttack.currentWeapon != null)
        {
            Debug.Log("Already have a weapon!");
            return;
        }

        Weapon spawnedWeapon = Instantiate(newWeapon, transform); 
        spawnedWeapon.transform.localPosition = Vector3.zero;

        playerAttack.currentWeapon = spawnedWeapon;
    }

}
