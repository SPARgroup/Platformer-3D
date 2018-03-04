using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 20f;
    public float range = 100f;
    public float impactForce = 50f;
    public float fireRate = 1f;

    public WeaponGraphics weapongraphics;


    public float reloadTime = 1f; //this will be used as time in seconds

    public int magSize = 8;
    public int maxAmmo = 104;

    [SerializeField] private int currentMagSize = 8;
    [SerializeField] private int ammoNotInMag = 96;

    public Camera Cam;

    private float nextTimeToFire = 0f;

    private void Start()
    {
        weapongraphics = this.GetComponent<WeaponGraphics>();
    }

    void Update()
    {

        if (currentMagSize == 0)
        {
            Reload();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentMagSize != 0)
        {
            nextTimeToFire = Time.time + (1f / fireRate);
            Shoot();
            weapongraphics.PlayMuzzleFlash();
        }
    }

    void Reload()
    {
        int reduceAmount = magSize - currentMagSize;

        if (ammoNotInMag<= reduceAmount)
        {
            currentMagSize += ammoNotInMag;
            ammoNotInMag = 0;
        }
        else
        {
            currentMagSize += reduceAmount;
            ammoNotInMag -= reduceAmount;
        }

    }

    void Shoot()
    {

        //raycast shooting system
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);
            currentMagSize--;

            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }


    }
}