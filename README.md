# Tank Game Development: Modular Architecture

This repository contains the core logic and architectural guidelines for a top-down tank shooter developed in Unity 6, focusing on **Clean Architecture** and **Interface-driven design**.

---

## Core Architectural Principles

### Interface Contracts

Interfaces define behavior contracts without enforcing a specific implementation. This creates a flexible system where components like bullets don't need to know exactly what they are hitting, only that the target implements the required behavior.

| Interface | Method(s) | Purpose |
| --- | --- | --- |
| **IMovable** | `Move(Vector2 direction)` | Defines translation and rotation logic. |
| **IHealth** | `TakeDamage(int amount)`, `Heal(int amount)` | Manages health changes for any object. |
| **IShooter** | `Shoot()` | Handles projectile instantiation. |
| **IEnemy** | `Attack()` | Defines basic enemy offensive behavior. |

### Why Modularity Matters

Structuring logic into separate, focused scripts (Move, Shoot, Health) mimics real-world mechanical design:

* **Single Responsibility:** Each script does exactly one job (e.g., the steering wheel doesn't control the engine).
* **Reusability:** Interfaces let you apply the same logic to players, enemies, or turrets.
* **Interchangeability:** Components can be swapped or maintained without breaking the entire "God script."

---

## Technical Implementation

### 1. Movement System

The movement logic handles both forward translation and Z-axis rotation based on 2D input vectors.

```csharp
public void Move(Vector2 direction) 
{
    // Forward movement logic
    Vector3 move = transform.up * direction.y * moveSpeed * Time.deltaTime;
    transform.position += move;
    
    // Rotation logic
    float rotation = -direction.x * rotationSpeed * Time.deltaTime;
    transform.Rotate(0, 0, rotation);
}

```

### 2. The `out` Keyword in Unity

The `out` keyword indicates a parameter is passed by reference and must be assigned within the method. It is essential for "Try-patterns" like `TryGetComponent`, allowing the code to safely extract an interface from a collision.

```csharp
void OnTriggerEnter2D(Collider2D collision) 
{
    // Safely extract the IHealth interface if it exists
    if (collision.TryGetComponent(out IHealth target)) 
    {
        target.TakeDamage(10);
        Destroy(gameObject);
    }
}

```

---

## Setup Instructions

### Creating the Tank Entity

1. **Logic Hub:** Create an **Empty GameObject** named "Player" or "Enemy" to hold the scripts.
2. **Visuals:** Create a child 2D Sprite object (e.g., "PlayerVisuals"). This keeps the art modular and easy to swap without affecting the code.
3. **Muzzle:** Create an empty child object at the tip of the barrel to act as the `firePoint`. Ensure it is outside the tank's hitbox to avoid self-destruction.
4. **Physics:**
* Add a **Rigidbody2D** and set **Gravity Scale to 0**.
* Add a **BoxCollider2D**. For bullets, ensure **Is Trigger** is enabled.



### Essential Checklist

* **Component Assignment:** Attach `Move`, `Shooting`, and `Health` scripts to the parent object.
* **Targeting:** For enemies, assign the **Player Transform** to the `Target` field so the AI knows what to follow.
* **Prefabs:** Assign the Bullet prefab to the `Projectile Prefab` slot in the shooting scripts.
* **Safety:** Manually link all references in the Inspector to prevent `NullReferenceException` errors.

---

**Thank You!**

