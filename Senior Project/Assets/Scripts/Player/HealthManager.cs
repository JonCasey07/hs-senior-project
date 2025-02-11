using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public RectTransform healthBar;
    private int maxHealth = 100;
    private int currentHealth;
    private int posDead = 1920;
    private int posFullHealth = 1520;
    private int posChange;

    void Start()
    {
        currentHealth = maxHealth;
        posChange = posFullHealth-posDead;
    }

    void Update()
    {
        //testDamage();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10); 
        }
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
        float healthPercentageLost = 1-((float)currentHealth / maxHealth);
        healthBar.anchoredPosition = new Vector2(0, 1005);
        healthBar.anchoredPosition += new Vector2(healthPercentageLost*(posChange), 0);;
    }
}
