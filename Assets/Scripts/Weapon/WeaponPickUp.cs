using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    private Player player;

    [SerializeField] private Weapon weaponToGive;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player != null && !player.HasWeapon)
        {
            player.EquipWeapon(weaponToGive); // Sahnedeki pickup objesinin verdiği silah
            Destroy(gameObject);
        }
    }
}
