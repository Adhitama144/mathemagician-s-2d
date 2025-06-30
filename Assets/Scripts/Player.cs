using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

    public event Action<int, int> OnHealthChanged;

    void Start()
    {
        NotifyHealthChange();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            SceneManager.LoadScene("Death", LoadSceneMode.Additive);
        }
        NotifyHealthChange();
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
        NotifyHealthChange();
    }

    void NotifyHealthChange()
    {
        OnHealthChanged?.Invoke(health, maxHealth);
    }
}