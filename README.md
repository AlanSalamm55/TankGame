# Tank Game Development: Modular Unity Architecture

This repository contains the core scripts and architectural guidelines for developing a top-down tank shooter in Unity 6, focusing on **Clean Architecture**, **Interface-driven design**, and **Modular components**.

---

## ## Core Architectural Principles

### ### Interface Contracts

Instead of tight coupling, this project uses interfaces to define behavior. This allows systems like the `Bullet` to interact with any object that has health without needing to know specifically what that object is.

| Interface | Method(s) | Purpose |
| --- | --- | --- |
| `IMovable` | `Move(Vector2 direction)` | Defines how an entity translates and rotates.

 |
| `IHealth` | `TakeDamage(int amount)`, `Heal(int amount)` | Manages damage processing and recovery.

 |
| `IShooter` | `Shoot()` | Handles projectile instantiation logic.

 |
| `IEnemy` | `Attack()` | Defines basic enemy offensive behavior.

 |

### ### Why Modularity Matters

By separating logic into specific scripts (`Move`, `Health`, `Shooting`), we achieve:

* 
**Reusability:** Apply the same health or movement logic to players and enemies alike.


* 
**Maintainability:** Each script has one job (Single Responsibility Principle), making debugging easier.


* 
**Interchangeability:** Swap out a player's visual sprite without breaking the underlying movement logic.



---

## ## Implementation Details

### ### 1. Movement System

Both Player and Enemy implement `IMovable`. The Player uses input axes, while the Enemy calculates a direction based on a target Transform.

**Player Movement Logic:**

```csharp
public void Move(Vector2 direction) {
    Vector3 move = transform.up * direction.y * moveSpeed * Time.deltaTime;
    transform.position += move;
    float rotation = -direction.x * rotationSpeed * Time.deltaTime;
    transform.Rotate(0, 0, rotation);
}

```



### ### 2. Health & Damage (The `out` Keyword)

The `Bullet` script utilizes the C# `out` keyword with `TryGetComponent` to safely extract and damage a target if it implements `IHealth`.

```csharp
void OnTriggerEnter2D(Collider2D collision) {
    if (collision.TryGetComponent(out IHealth target)) {
        target.TakeDamage(10);
        Destroy(gameObject);
    }
}

```



---

## ## Setup Instructions

### ### Player/Enemy Configuration

1. 
**Logic Hub:** Create an Empty GameObject (e.g., "Player").


2. **Visuals:** Create a child GameObject for the Sprite. This keeps the logic detached from the art.


3. **Muzzle:** Create an empty child object positioned at the barrel tip. This serves as the `firePoint`.


4. **Physics:** * Add a `Rigidbody2D` and set **Gravity Scale to 0** to prevent the tank from falling.


* Add a `BoxCollider2D`. For bullets, ensure **Is Trigger** is checked.





### ### Essential Components Checklist

* [ ] `PlayerMove` / `EnemyMove` 


* [ ] `PlayerShooting` / `EnemyShooting` 


* [ ] `PlayerHealth` / `EnemyHealth` 


* [ ] Reference Assignment: Ensure all prefabs (Bullets) and Transforms (Muzzle/Target) are assigned in the Inspector to avoid `NullReferenceException`.



---

*Developed as part of SE404: Game Design and Development.* 

Would you like me to generate the full C# code for a specific script mentioned above, such as the `EnemyMove` or `IHealth` interface?
