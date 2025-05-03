using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] private Weapon weaponToGive;
    public bool pickupEnabled = true;
    Player player;
    
    void Start()
    {
        if (weaponToGive == null)
        {
            weaponToGive = GetComponent<Weapon>();
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!pickupEnabled) return;

            if (!player.hasWeapon)
            {
                pickupEnabled = false;
                player.EquipWeapon(weaponToGive);
                Destroy(gameObject);
            }
        }

    }

    public IEnumerator EnablePickupAfterDelay(float delay)
    {
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        gameObject.GetComponent <BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        pickupEnabled = true;
    }

}
