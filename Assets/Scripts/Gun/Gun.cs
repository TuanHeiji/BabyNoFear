using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float shootDelay = 1.5f;
    private float nextShoot;
    [SerializeField] private int maxAmmo = 10;
    public int currentAmmo;
    private int facingDirection = 1; // 1 = phải, -1 = trái

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        FlipGun();
        Shoot();
        ReloadBullet();
    }



    private void FlipGun()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput > 0)
        {
            facingDirection = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            facingDirection = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.S) && Time.time > nextShoot && currentAmmo > 0)
        {
            nextShoot = Time.time + shootDelay;
            GameObject bullet = Instantiate(bulletPrefabs, firePos.position, firePos.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.SetDirection(facingDirection);
            currentAmmo--;
        }
    }

    void ReloadBullet()
    {
        if (currentAmmo == 0 && Input.GetKeyDown(KeyCode.R))
        {
            currentAmmo = maxAmmo;
        }
    }
}
