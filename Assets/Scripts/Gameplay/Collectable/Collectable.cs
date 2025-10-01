using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] GemSettings _gemSettings;
    public int Value { get => _gemSettings.Value; }

    public void Collect(PlayerController player)
    {

    }

    public void Move()
    {
        
    }
}