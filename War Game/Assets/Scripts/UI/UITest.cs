using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI RoundText, ClipText, AmmoText, ActiveGun, HealthText;

    [SerializeField]
    Slider healthSlider;

    PlayerHealth playerHealth;
    PlayerShooting playerShooting;
    Pistol activeGun;

    float currentPlayerHealth;
    float maxPlayerHealth;

    string currentGun;
    int currentClipAmmo;
    int totalClipSize;
    int totalAmmo;

    
	// Use this for initialization
	void Start ()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerShooting = FindObjectOfType<PlayerShooting>();
        activeGun = playerShooting.ActiveWeapon;

        healthSlider.maxValue = maxPlayerHealth;
        healthSlider.value = currentPlayerHealth;
        healthSlider.minValue = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Event Handler for when Health Bar Changes

        currentClipAmmo = activeGun.clipAmount;
        totalClipSize = Pistol.clipSize;
        totalAmmo = activeGun.ammoAmount;

        ClipText.text = currentClipAmmo + "/" + totalClipSize;
        AmmoText.text = totalAmmo.ToString();
        currentGun = activeGun.name;

        currentPlayerHealth = playerHealth.currentHealth;
        maxPlayerHealth = playerHealth.maxHealth;

        healthSlider.maxValue = maxPlayerHealth;
        healthSlider.value = currentPlayerHealth;
        HealthText.text = currentPlayerHealth.ToString() + "/" + maxPlayerHealth.ToString();

        
	}

    void HealthChanged()
    {

    }

}
