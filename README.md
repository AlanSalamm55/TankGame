# Tank Game Development: Modular Unity Architecture

This documentation outlines the core scripts and architectural guidelines for a top-down tank shooter in Unity 6, focusing on **Clean Architecture** and **Interface-driven design**.

---

## Core Architectural Principles

### Interface Contracts

Interfaces define behavior contracts without enforcing a specific implementation, making systems like bullets highly flexible. Bullets only need to know that a target implements `IHealth` to interact with it.

Interface,Method(s),Purpose
IMovable,Move(Vector2 direction),Defines translation and rotation logic.+1
IHealth,"TakeDamage(int amount), Heal(int amount)",Manages health changes for any object.+1
IShooter,Shoot(),Handles projectile instantiation.+1
IEnemy,Attack(),Defines basic enemy offensive behavior.+1
