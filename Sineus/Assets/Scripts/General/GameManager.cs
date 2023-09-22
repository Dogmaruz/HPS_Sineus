using System;
using UnityEngine;

public class GameManager
{
    public Action<int> OnReworked;

    public Action<int> OnLevelCompleted;

    private int _reworked;

    public void ReworkedTrash()
    {
        _reworked += 1;

        OnReworked?.Invoke(_reworked);
    }

    public void LevelCompleted()
    {
        OnLevelCompleted?.Invoke(_reworked);
    }
}
