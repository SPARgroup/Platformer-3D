using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    public Weapon weapon;
    [SerializeField]
    private Camera Cam;
    [SerializeField]
    private LayerMask mask;
    // Use this for initialization
    void Start() {
        if (Cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced");
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1"))
            {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, weapon.range, mask))
        {
            Debug.Log(hit.collider.name);
        }
    }
}