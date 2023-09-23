using System;
using UnityEngine;
using Zenject;

public class LevelController : MonoBehaviour
{
    public Action<bool> OnLevelFinished;

    [SerializeField] private int m_TrashWinCount;
    public int TrashWinCount => m_TrashWinCount;

    private GameManager _gameManager;
    private PlayerHP _playerHP;

    [Inject]
    public void Construct(IEntityFactory entityFactory, GameManager gameManager, PlayerHP playerHP)
    {
        _gameManager = gameManager;
        _playerHP = playerHP;
    }

    private void Awake()
    {
        _gameManager.OnReworked += CheckWin;
        _playerHP.OnPlayerDeath += LoseLevel;
    }

    private void CheckWin(int score)
    {
        if (score >= m_TrashWinCount)
        {
           OnLevelFinished?.Invoke(true);
        }
    }

    private void LoseLevel()
    {
        OnLevelFinished?.Invoke(false);
    }
}
