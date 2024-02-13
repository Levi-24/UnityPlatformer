using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject bloodDrops;
    [SerializeField] private float maxHealth = 10f;
    private float currentHealth;

    //PlayerController controller;

    private void Start()
    {
        currentHealth = maxHealth;
        //controller = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
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
