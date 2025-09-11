using System;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public event Action<int, int> OnScoreChanged;
    private int collectedItemNumber;
    private int score;

    void Start()
    {
        collectedItemNumber = 0;
        score = 0;
    }
    public void PlayerCollect(Collectable item)
    {
        collectedItemNumber++;
        score += item.score;
        OnScoreChanged?.Invoke(score, collectedItemNumber);
    }

    protected override void OnDestroy()
    {
        OnScoreChanged = null;
    }
}
