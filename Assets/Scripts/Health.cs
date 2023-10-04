using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;

    private int currentHealth;

    public UnityEvent<int> onTakeDamage;
    public UnityEvent<int> onGainHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        onGainHealth?.Invoke(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        onTakeDamage?.Invoke(currentHealth);
    }

    public void GainHealth(int amount)
    {
        currentHealth += amount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        onGainHealth?.Invoke(currentHealth);
    }
}
