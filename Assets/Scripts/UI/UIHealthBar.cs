using System;
using UnityEngine;
using UnityEngine.UI;
public class UIHealthBar : MonoBehaviour
{
    private Image _healthBar;
    private PlayerController _player;

    void Awake()
    {
        _healthBar = GetComponent<Image>();
        _player = FindFirstObjectByType<PlayerController>();
        _player.OnHealthChanged += UpdateHealthBar;
    }

    private void UpdateHealthBar(int health, int maxHealth)
    {
        if (_healthBar == null || maxHealth <= 0)
            return;

        _healthBar.fillAmount = Mathf.Clamp01((float)health / maxHealth);
    }

    void OnDisable()
    {
        _player.OnHealthChanged -= UpdateHealthBar;
    }
}