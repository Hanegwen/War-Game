using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    CapsuleCollider capsuleCollider;

    [SerializeField]
    bool canAttack = true;

    [SerializeField]
    float AttackRecharge = .1f;
	// Use this for initialization
	void Start ()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Attack();
	}

    void Attack()
    {
        if(canAttack)
        {
            capsuleCollider.enabled = false;
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(AttackRecharge);
        capsuleCollider.enabled = true;
        canAttack = true;
    }
}
