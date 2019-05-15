using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI RoundText;

    [SerializeField]
    Slider healthSlider;

    PlayerHealth playerHealth;

    float currentPlayerHealth;
    float maxPlayerHealth;
	// Use this for initialization
	void Start ()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
