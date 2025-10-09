using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public Animator anim;

    //PlayerMovement player = GetComponent<PlayerMovement>();
    void Start()
    {
        anim = GetComponent<Animator>();
        curHealth = maxHealth;
    }
    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
        Debug.Log(curHealth);

        if (curHealth <= 0)
        {
            playerKillStart(damage);
            //Debug.Log("gvfbsdvbhi");
            //anim.SetBool("isDead", true);

        }

    }

    public void playerKillStart(int damage)
    {
        Debug.Log("gvfbsdvbhi");
        anim.SetBool("isDead", true);
    }

    public void playerKillEnd()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        anim.SetBool("isDead", true);
    }

    public void HealPlayer(int damage)
    {
        curHealth += damage;
        healthBar.SetHealth(curHealth);
    }
}
