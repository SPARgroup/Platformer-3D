using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public int selectedWeapon = 1;
   
    public GameObject [] weapons = new GameObject [4];

	// Use this for initialization
	void Start () {
        SelectWeapon();
	}
	
	// Update is called once per frame
	void Update () {

        int previouSelectedWeapon = selectedWeapon;

       if(Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon == transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }

        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon == 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }

        }
        if(previouSelectedWeapon != selectedWeapon)
        {
             SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (GameObject weapon in transform)
        {
            weapons[i] = weapon;
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
