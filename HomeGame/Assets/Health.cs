using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public HealthBar healthBar;
    private Animator anim;
    public static event Action OnPlayerDeath;
    void Start()
    {
        curHealth = maxHealth;
    }
    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);

        if (curHealth <= 0)
        {
            OnPlayerDeath.Invoke();
        }
    }

    public void HealPlayer(int damage)
    {
        curHealth += damage;
        healthBar.SetHealth(curHealth);
    }
}
