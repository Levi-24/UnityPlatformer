using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject bloodDrops;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image hitIndicator;
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float fadeSmooth = 2;
    private float currentHealth;
    private bool takeDamage;

    private void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        currentHealth = maxHealth;
        takeDamage = false;
    }

    private void Update()
    {
        if (takeDamage)
        {
            hitIndicator.color = new(255, 255, 255, .8f);
        }
        else
        {
            hitIndicator.color = Color.Lerp(
                hitIndicator.color,
                new(255,255,255,0f),
                Time.deltaTime * fadeSmooth);
        }
        takeDamage = false;

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.value -= damage;
        takeDamage = true;
        Instantiate(bloodDrops, transform.position, transform.rotation);
        if (currentHealth <= 0)
        {
            MakeDead();
        }
    }

    private void MakeDead()
    {
        Destroy(gameObject);
        hitIndicator.color = new(255, 255, 255, 1f);
    }
}
