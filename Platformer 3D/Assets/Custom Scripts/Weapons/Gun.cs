using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 20f;
    public float range = 100f;
    public float impactForce = 50f;
    public float fireRate = 1f;

    public Camera Cam;

    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Fire1") && Time.time>=nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1f / fireRate);
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}