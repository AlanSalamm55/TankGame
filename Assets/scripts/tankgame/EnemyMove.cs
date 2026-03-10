using UnityEngine;

public class EnemyMove : MonoBehaviour, IMovable
{
    public float speed = 3f;
    public Transform target;

    void Update()
    {
        if (target == null) return;
        Move((target.position - transform.position).normalized);

    }

    public void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}
