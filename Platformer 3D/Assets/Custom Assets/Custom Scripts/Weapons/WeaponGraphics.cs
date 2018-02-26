using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGraphics : MonoBehaviour
{

    public ParticleSystem muzzleFlash;
    public Transform shootPoint;

    // Use this for initialization
    void Start()
    {
        if (shootPoint == null)
        {
            Debug.LogWarning("Please specify ShootPoint");
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            muzzleFlash.Play();
        }
        */
    }

    public void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

} 
