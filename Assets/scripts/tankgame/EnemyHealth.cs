using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    public int health = 50;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log($"Enemy took {amount} damage. Remaining: {health}");
        if (health <= 0) Die();
    }

    public void Heal(int amount)
    {
        health += amount;
    }

    private void Die()
    {
        Debug.Log("Enemy destroyed");
        Destroy(gameObject);
    }
}
