using UnityEngine;

[CreateAssetMenu(fileName = "GemSettings", menuName = "Scriptable Objects/GemSettings")]
public class GemSettings : ScriptableObject
{
    public GameObject GemPrefab;
    public int Value;
}