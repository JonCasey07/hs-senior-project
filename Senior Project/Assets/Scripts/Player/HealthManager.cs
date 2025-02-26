using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthBar;
    private int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        //testDamage();
    }

    /*
    void testDamage()
    {
        if (Input.GetKeyDown("h"))
        {
            TakeDamage(10); // Adjust damage value as needed
        }
    }
    */

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
    }
}
