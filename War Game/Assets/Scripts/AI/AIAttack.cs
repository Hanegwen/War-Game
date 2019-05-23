using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    //CapsuleCollider capsuleCollider;

    [SerializeField]
    bool canAttack = true;

    [SerializeField]
    float AttackRecharge = .1f;

    [SerializeField]
    public float AttackRange = 3;
	// Use this for initialization
	void Start ()
    {
        //capsuleCollider = GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Attack();
	}

    public void Attack(float distance)
    {
        if(canAttack)
        {
            print("AI is Attacking and ISNOT playing Animation");

            canAttack = false;
            //capsuleCollider.enabled = false;
            StartCoroutine(AttackCooldown());
        }
        else
        {
            print("AI Attack cooldown");
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(AttackRecharge);
       // capsuleCollider.enabled = true;
        canAttack = true;
    }
}
