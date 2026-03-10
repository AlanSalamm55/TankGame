# Tank Game Development: Modular Unity Architecture

This documentation outlines the core scripts and architectural guidelines for a top-down tank shooter in Unity 6, focusing on **Clean Architecture** and **Interface-driven design**.

---

## Core Architectural Principles

### Interface Contracts

Interfaces define behavior contracts without enforcing a specific implementation, making systems like bullets highly flexible. Bullets only need to know that a target implements `IHealth` to interact with it.

| Interface | Method(s) | Purpose |
| --- | --- | --- |
| **`IMovable`** | `Move(Vector2 direction)` | Defines translation and rotation logic.

 |
| **`IHealth`** | `TakeDamage(int amount)`, `Heal(int amount)` | Manages health changes for any object.

 |
| **`IShooter`** | `Shoot()` | Handles projectile instantiation.

 |
| **`IEnemy`** | `Attack()` | Defines basic enemy offensive behavior.

 |

### Why Modularity Matters

Structuring logic into separate scripts (Move, Shoot, Health) provides several benefits:

* 
**Single Responsibility:** Each script does exactly one job.


* 
**Reusability:** Interfaces let you apply the same logic to players, enemies, or turrets.


* 
**Maintenance:** Components are interchangeable and maintained separately.



---

## Implementation Details

### 1. Movement System

The player script uses `Input.GetAxis` to drive the `Move` method, handling both forward position and Z-axis rotation.

```csharp
public void Move(Vector2 direction) {
    // Moves the tank forward/backward based on Y input
    Vector3 move = transform.up * direction.y * moveSpeed * Time.deltaTime;
    [cite_start]transform.position += move; [cite: 72]
    
    // Rotates the tank based on X input
    float rotation = -direction.x * rotationSpeed * Time.deltaTime;
    [cite_start]transform.Rotate(0, 0, rotation); [cite: 73]
}

```

### 2. Bullet Logic & the `out` Keyword

The `out` keyword is used to return multiple values or extract components. In the bullet system, `TryGetComponent` uses `out` to safely check for the `IHealth` interface before applying damage.

```csharp
void OnTriggerEnter2D(Collider2D collision) {
    // Safely attempts to find the IHealth interface on the target
    [cite_start]if (collision.TryGetComponent(out IHealth target)) { [cite: 35]
        [cite_start]target.TakeDamage(10); [cite: 37]
        [cite_start]Destroy(gameObject); [cite: 38]
    }
}

```

---

## Setup Instructions

### Player & Enemy Configuration

1. 
**Logic Hub:** Create an **Empty GameObject** named "Player" or "Enemy".


2. 
**Visuals:** Create a child 2D Sprite object (e.g., "PlayerVisuals") to keep logic and art separate.


3. 
**Muzzle:** Create an empty child object at the barrel tip to serve as the `firePoint`. Ensure it is outside the tank's hitbox to prevent self-destruction.


4. 
**Physics:** * Add a **Rigidbody2D** and set **Gravity Scale to 0** so the tank doesn't fall.


* Add a **BoxCollider2D**. For bullets, ensure **Is Trigger** is checked.





### Essential Checklist

* 
**Modular Scripts:** Attach `Move`, `Shooting`, and `Health` scripts to the parent object.


* 
**Reference Targets:** For enemies, assign the **Player Transform** to the `Target` field so they know what to follow.


* 
**Bullet Prefabs:** Assign the Bullet prefab to the `Projectile Prefab` slot in the shooting scripts.


* 
**Safety:** Assign all references in the Inspector to avoid `NullReferenceException`.
