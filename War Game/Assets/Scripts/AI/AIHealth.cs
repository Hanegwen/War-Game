using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100;

    [SerializeField]
    float currentHealth;

    [SerializeField]
    bool hasRechargeHealthAbility = false;

    [SerializeField]
    float healthRechargeDelay = 1.5f;

    [SerializeField]
    float healthRechargeAmountInPercent = 1;

    bool rechargeHealth =  true;
	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hasRechargeHealthAbility)
        {
            if (rechargeHealth)
            {
                RechargeHealth();
            }
        }
	}

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        print("AI hit by BUllet");

        rechargeHealth = false;
        StopAllCoroutines();
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            RechargeHealthCooldown();
        }
    }

    void Die()
    {
        print(this.gameObject.name + " Should Die");
    }

    void RechargeHealth()
    {
        if(currentHealth / maxHealth <= healthRechargeAmountInPercent)
        {
            currentHealth += maxHealth * healthRechargeAmountInPercent;
        }
        else
        {
            currentHealth = maxHealth;
        }
    }

    IEnumerator RechargeHealthCooldown()
    {
        yield return new WaitForSeconds(healthRechargeDelay);
        rechargeHealth = true;
        

    }
}
