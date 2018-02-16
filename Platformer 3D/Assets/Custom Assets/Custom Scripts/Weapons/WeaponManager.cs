
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public int selectedWeapon = 1;

    public Transform[] weapons = new Transform[4];

    // Use this for initialization
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        int previouSelectedWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapons[previouSelectedWeapon].gameObject.SetActive(false);
            weapons[0].gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapons[previouSelectedWeapon].gameObject.SetActive(false);
            weapons[1].gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapons[previouSelectedWeapon].gameObject.SetActive(false);
            weapons[2].gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weapons[previouSelectedWeapon].gameObject.SetActive(false);
            weapons[3].gameObject.SetActive(true);
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
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
        if (previouSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
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
