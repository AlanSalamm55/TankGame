using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IHealth target;
        if (collision.TryGetComponent(out target))
        {
            target.TakeDamage(10);

        }
        Destroy(gameObject);
    }
}
