using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    float damage = 1;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.gameObject.transform.position += this.gameObject.transform.right * speed * Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<AIHealth>() != null)
        {
            other.GetComponent<AIHealth>().TakeDamage(damage);
        }
    }
}
