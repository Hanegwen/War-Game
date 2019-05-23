using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField]
    float shootingRechargeTime = .3f;

    [Tooltip("This is the amount of ammo a clip can hold")]
    [SerializeField]
    public static int clipSize = 7;

    [Tooltip("This is how much ammo left NOT in the clip")]
    [SerializeField]
    public int ammoAmount = 55;

    [SerializeField]
    Bullet bullet;

    [Tooltip("This is the amount of Bullets in the current clip")]
    [HideInInspector]
    public int clipAmount;

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
                var localBullet = Instantiate(bullet,this.transform,false);
                //localBullet.transform.Rotate(Vector3.left * -90);
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
