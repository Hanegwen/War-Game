using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    Pistol ActiveWeapon;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.R))
        {
            ReloadActiveWeapon();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireActiveWeapon();
        }
	}

    void FireActiveWeapon()
    {
        ActiveWeapon.Shoot();
    }

    void ReloadActiveWeapon()
    {
        ActiveWeapon.Reload();
    }

    void SwitchActiveWeapon()
    {

    }
}
