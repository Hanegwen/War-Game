using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField]
    float shootingRechargeTime = .3f;

    [SerializeField]
    static int clipSize = 7;

    [SerializeField]
    int ammoAmount = 55;

    [SerializeField]
    Bullet bullet;

    int clipAmount;

    bool canShoot = true;

	// Use this for initialization
	void Start ()
    {
        clipAmount = clipSize;
        ammoAmount -= clipAmount;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Reload()
    {
        ammoAmount += clipAmount;
        clipAmount = 0;
        if(ammoAmount >= clipSize)
        {
            clipAmount = clipSize;
            ammoAmount -= clipAmount;
        }
        else
        {
            clipAmount = ammoAmount;
            ammoAmount = 0;
        }

    }

    public void Shoot()
    {
        if(clipAmount >= 1)
        {
            if (canShoot)
            {
                canShoot = false;
                clipAmount--;
                var localBullet = Instantiate(bullet);
                localBullet.transform.parent = null;
                StartCoroutine(RechargeShooting());
            }
        }
    }

    IEnumerator RechargeShooting()
    {
        yield return new WaitForSeconds(shootingRechargeTime);
        canShoot = true;
    }
}
