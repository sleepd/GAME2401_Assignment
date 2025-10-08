using System;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public event Action<int, int> OnScoreChanged;
    private int _collectedItemNumber;
    private int _score;
    public PlayerController Player { get; private set; }

    public override void Awake()
    {
        base.Awake();
        
        Player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        if (Player == null) Debug.LogError("[LevelManager] Can't find Player!");
    }

    void Start()
    {
        _collectedItemNumber = 0;
        _score = 0;
    }
    public void UpdateScore(int amount)
    {
        _collectedItemNumber++;
        _score = amount;
        OnScoreChanged?.Invoke(_score, _collectedItemNumber);
    }

    protected override void OnDestroy()
    {
        OnScoreChanged = null;
    }
}
