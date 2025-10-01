using System;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public event Action<int, int> OnScoreChanged;
    private int collectedItemNumber;
    private int score;
    public PlayerController Player { get; private set; }

    public override void Awake()
    {
        base.Awake();
        
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if (Player == null) Debug.LogError("[LevelManager] Can't find Player!");
    }

    void Start()
    {
        collectedItemNumber = 0;
        score = 0;
    }
    public void PlayerCollect(Collectable item)
    {
        collectedItemNumber++;
        score += item.Value;
        OnScoreChanged?.Invoke(score, collectedItemNumber);
    }

    protected override void OnDestroy()
    {
        OnScoreChanged = null;
    }
}
