using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Player player;
    public Slider healthSlider;

    void Start()
    {
        healthSlider.maxValue = player.maxHealth;
        healthSlider.value = player.health;

        player.OnHealthChanged += UpdateHealthBar;
    }

    void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void OnDestroy()
    {
        player.OnHealthChanged -= UpdateHealthBar;
    }
}