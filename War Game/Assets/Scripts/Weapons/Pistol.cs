using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField]
    float shootingRechargeTime = .3f;

    [SerializeField]
    int clipAmount = 7;

    [SerializeField]
    int ammoAmount = 55;

    bool canShoot = true;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Shoot()
    {

    }

    IEnumerator RechargeShooting()
    {
        yield return new WaitForSeconds(shootingRechargeTime);
    }
}
