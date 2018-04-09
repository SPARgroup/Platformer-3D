using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Gun : MonoBehaviour
{

    public float damage = 20f;
    public float range = 100f;
    public float impactForce = 50f;
    public float fireRate = 1f;
    public float reloadTime = 2f; //reload time for gun in seconds

    public bool sprintCancelsReload = true;
    public bool isReloading = false;

    public WeaponGraphics weapongraphics;
    public FirstPersonController fpsController;

    public int magSize = 8;
    public int maxAmmo = 104;

    [SerializeField] private int currentMagSize = 8;
    [SerializeField] private int ammoNotInMag = 96;

    public Camera Cam;

    private float nextTimeToFire = 0f;

    private Coroutine reloadCoroutine;

    

    //public Animator shotgunAnim;

    private void Start()
    {
        weapongraphics = this.GetComponent<WeaponGraphics>();
        //shotgunAnim = GetComponent<Animator>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        fpsController = player.GetComponent<FirstPersonController>();
    }

    void Update()
    {

        if (currentMagSize == 0)
        {
            reloadCoroutine = StartCoroutine(Reload(reloadTime));

            //play Animation
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            reloadCoroutine = StartCoroutine(Reload(reloadTime));

            //play Animation
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentMagSize != 0)
        {
            nextTimeToFire = Time.time + (1f / fireRate);
            Shoot();
            weapongraphics.PlayMuzzleFlash();
        }

        // If true, cancels reload everytime you sprint while reloading
        if (sprintCancelsReload == true)
        {
            if (Input.GetKey(KeyCode.LeftShift) && isReloading == true)
            {
                StopCoroutine(reloadCoroutine);
                isReloading = false;
                Debug.Log("Reload cancelled due to sprinting");
            }
        }
    }


    //Reload system
    IEnumerator Reload(float time)
    {
        Debug.Log("Reloading"); //aise hi

        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

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
        Debug.Log("Reloaded"); //Mauj AA gayi
        isReloading = false;
    }

    //Shoot System
    void Shoot()
    {
        //rduce the current ammo in magazine
        currentMagSize--;
       // shotgunAnim.Play("Shotgun_Shoot", -1, 0f);
        //raycast shooting system
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
        {
            Debug.DrawRay(Cam.transform.position, Cam.transform.forward, Color.red, Mathf.Infinity);
            Debug.Log(hit.transform.name);
            
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
//Copyright SPAR Group