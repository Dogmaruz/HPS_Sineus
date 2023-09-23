using System;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public event Action OnPlayerDeath;
    private int m_MaxHitPoints = 100;
    private int _currentHP;

    public int NormalizedHP => _currentHP / m_MaxHitPoints;

    private void Start()
    {
        _currentHP = m_MaxHitPoints;
    }

    public void AddHealth(int value)
    {
        _currentHP += value;

        if (_currentHP > m_MaxHitPoints)
        {
            _currentHP = m_MaxHitPoints;
        }
    }

    public void RemoveHealth(int value)
    {
        _currentHP -= value;

        if (_currentHP <= 0)
        {
            _currentHP = 0;
            OnPlayerDeath?.Invoke();
        }
    }
}
