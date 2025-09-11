using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] int _score;
    public int score { get => _score; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        LevelManager.Instance.PlayerCollect(this);
        Destroy(gameObject);
    }
}
