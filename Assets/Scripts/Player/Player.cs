using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool HasWeapon=false;
    public bool attacking;
    public Weapon currentWeapon;
    PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        Debug.Log(playerAttack.currentWeapon);
    }
    public void EquipWeapon(Weapon newWeapon)
    {
        HasWeapon = true;
        if (playerAttack.currentWeapon != transform.GetComponentInChildren<Fist>())
        {
            Debug.Log("Already have a weapon!");
            return;
        }
        playerAttack.currentWeapon = newWeapon;
        Weapon spawnedWeapon = Instantiate(newWeapon, transform); 
        spawnedWeapon.transform.localPosition = Vector3.zero;

    }
    public void ThrowWeapon()
    {
        HasWeapon=false;
        playerAttack.currentWeapon = transform.GetComponentInChildren<Fist>();
        EquipWeapon(playerAttack.currentWeapon);
    }

}
