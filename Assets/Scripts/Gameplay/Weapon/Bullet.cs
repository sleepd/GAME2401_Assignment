using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float lifetime = 3f;

    float _lifeRemaining;

    void Start()
    {
        _lifeRemaining = lifetime;
    }

    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);

        _lifeRemaining -= Time.deltaTime;
        if (_lifeRemaining <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
