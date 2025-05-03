using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float throwForce = 50f;// SCRIPTABLE'A TAŞI
    public Transform handPoint;

    public bool attacking = false;
    public bool hasWeapon = false;
    private bool isFist;

    public Weapon currentWeapon;
    public Weapon fistPrefab;

    private Vector3 currentWeapon_Scale;

    private bool Armed = true;
    [SerializeField] private int currentHealth = 0;

    private void Start()
    {
        currentHealth = playerData.maxHealth;
        EquipWeapon(fistPrefab); 
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ThrowWeapon();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            unArm();
        }
    }

    public void EquipWeapon(Weapon newWeaponPrefab)
    {
        currentWeapon_Scale = newWeaponPrefab.transform.localScale;
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }

        // Yeni silahı elde oluştur ve child yap
        Weapon newWeaponInstance = Instantiate(newWeaponPrefab, handPoint);
        newWeaponInstance.transform.localPosition = Vector3.zero;
        newWeaponInstance.transform.localRotation = Quaternion.identity;
        newWeaponInstance.GetComponent<BoxCollider2D>().isTrigger = false;

        Rigidbody2D rb = newWeaponInstance.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
        }

        currentWeapon = newWeaponInstance;
        isFist = currentWeapon.GetType().Name == fistPrefab.GetType().Name;
        currentWeapon.gameObject.layer = LayerMask.NameToLayer("Weapon");
        if (!isFist)
        {
            hasWeapon = true;
        }
    }

    public void ThrowWeapon()
    {
        if (currentWeapon == null|| isFist) return;
        currentWeapon.gameObject.layer = LayerMask.NameToLayer("Default");
        // Mouse pozisyonunu world pozisyonuna çevir
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = (mouseWorldPos - transform.position).normalized;

        // Elde tutulan silahı childlıktan çıkar
        currentWeapon.transform.parent = null;

        // Rigidbody2D yoksa ekle
        Rigidbody2D rb = currentWeapon.GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        

       
        currentWeapon.transform.localScale = currentWeapon_Scale;
        rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);

        // Collider varsa trigger olmaktan çıkar
        Collider2D col = currentWeapon.GetComponent<Collider2D>();
        if (col != null)
            col.isTrigger = false;

        // Silah yeniden alınabilsin
        WeaponPickUp pickUp = currentWeapon.GetComponent<WeaponPickUp>();
        if (pickUp != null)
            pickUp.StartCoroutine(pickUp.EnablePickupAfterDelay(0.5f));

        // Silahı bırak
        currentWeapon = null;
        hasWeapon = false;
        EquipWeapon(fistPrefab);
    }

    // FIX
    private void unArm()
    {
        Armed = !Armed;
        currentWeapon.gameObject.SetActive(Armed);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Take Damage animation
    }
}
