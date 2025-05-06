using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 3)]
public class WeaponData : ScriptableObject
{
    public WeaponType weaponType;
    public float damage;
    public float speed;
    public float range;
    public float cooldown;
    public float health;
}
