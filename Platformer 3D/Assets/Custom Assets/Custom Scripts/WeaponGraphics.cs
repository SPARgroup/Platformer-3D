using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGraphics : MonoBehaviour {

    public GameObject muzzleFlash;
    public Transform shootPoint;

	// Use this for initialization
	void Start () {
		if(shootPoint == null)
        {
            Debug.LogWarning("Please specify the Muzzle Flash Gameobject in the Weapon Graphics script!");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void implementMuzzleFlash()
    {
        Instantiate(muzzleFlash, shootPoint.transform.position, shootPoint.transform.rotation);
    }
}
