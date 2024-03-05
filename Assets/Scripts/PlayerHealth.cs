using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject bloodDrops;
    [SerializeField] private Slider healthBar;
    [SerializeField] private float maxHealth = 10f;
    private float currentHealth;

    //PlayerController controller;

    private void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        currentHealth = maxHealth;
        //controller = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value -= damage;
        Instantiate(bloodDrops, transform.position, transform.rotation);
        if (currentHealth <= 0)
        {
            MakeDead();
        }
    }

    private void MakeDead()
    {
        Destroy(gameObject);
    }
}
