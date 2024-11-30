# List of docs

- [Project log](./project-log.md)
- [Guilherme's learnings](./guilherme-learnings.md)
- [Mario's learnings](./mario-learnings.md)
- [Venicio's learnings](./venicio-learnings.md)

# General Code Guide for the Project

## Table of Contents
<!-- TABLE OF CONTENTS -->
<p align="center">
  <a href="#general-principles">General Principles</a> •
  <a href="#variables">Variables</a> •
  <a href="#methods">Methods</a> •
  <a href="#constructors">Constructors</a> •
  <a href="#comments-and-documentation">Comments and Documentation</a> •
  <a href="#error-handling">Error Handling</a> •
  <a href="#project-structure-and-organization">Project Structure and Organization</a> •
</p>

---

## General Principles

1. **Consistency**:
   - Consistent naming conventions for variables, methods, and files help maintain clarity.

2. **Readability**:
   - Code should be self-explanatory whenever possible, with meaningful names and a clear structure.

3. **Documentation**:
   - Use XML comments and inline comments to explain complex logic or behavior.

4. **Object-Oriented Design**:
   - Follow OOP principles like encapsulation, inheritance, and polymorphism.
   - Prioritize reusable and maintainable code.

<details>
  <summary><b>Encapsulation</b></summary>


Keep variables private and expose them through properties or methods if external access is required.
**Example**:
```csharp
    private int speed;

public int Speed
{
    get { return speed; }
    private set { speed = value; }
}
```
</details>

<details>
  <summary><b>Inheritance</b></summary>

Use virtual methods in parent classes to allow children to override behavior where appropriate.
**Example**:
```csharp
public class Enemy
{
    public virtual void UpdateEnemyLocation()
    {
        // Base behavior
    }
}

public class FastEnemy : Enemy
{
    public override void UpdateEnemyLocation()
    {
        // Custom behavior for FastEnemy
    }
}

```
</details>

<details>
  <summary><b>Abstraction</b></summary>

Abstraction hides complex implementation details from the user and provides a clear interface to interact with objects.
Use abstract classes or interfaces to define behaviors that must be implemented by other classes.

**Example**:
```csharp
public interface IBombHandler
{
    void ShootBomb();
}

public class Player : IBombHandler
{
    public void ShootBomb()
    {
        // Player's bomb shooting logic
    }
}

```
</details>

<details>
  <summary><b>Polymorphism</b></summary>

Polymorphism allows objects of different types to be treated as instances of a common parent type.
Use method overriding (runtime polymorphism) or method overloading (compile-time polymorphism) to handle diverse behaviors dynamically.

**Example**:
```csharp
public class GameMap
{
    public List<Enemy> MapEnemies { get; set; }

    public void SpawnEnemies()
    {
        foreach (var enemy in MapEnemies)
        {
            enemy.UpdateEnemyLocation(); // Calls the appropriate version for each type of Enemy
        }
    }
}

```

</details>



---

## Variables

### Naming Conventions
1. **Public or External Variables**: Use **pascal case** for variables accessed or initialized from outside the class.  
   **Example**:
```csharp
   Texture2D PlayerImage;
   Vector2 PlayerPosition;

   // Constructor
   public Player(Texture2D playerImage, Vector2 playerPosition)
   {
       PlayerImage = playerImage;
       PlayerPosition = playerPosition;
   }
```

2. **Public or External Variables**: Use **camel case** for variables that are private to the class and not exposed externally.
**Example**:
```csharp
private int speed;
private int radius;

// Constructor
public Player()
{
    speed = 2;
    radius = 5;
}
```
### Accessability
Some variables my be required to be accessed by outside classes and still maintain its access restricted.
**Example**:
```csharp
// Backing field
    private int speed;

    // Public property with a private setter
    public int Speed
    {
        get { return speed; }
        private set { speed = value; }
    }
```

## Methods
Use Pascal case for all method names.
**Example**:

```csharp
public void UpdatePlayer(){}

public void DrawPlayer(){}

### Method Parameters
Use descriptive names for parameters to indicate their purpose.
**Example**:
```csharp

public void MovePlayer(Vector2 direction, float deltaTime)
{
    PlayerPosition += direction * speed * deltaTime;
}
```

### Overriding Methods
Use override when modifying inherited behavior.
**Example**:
```csharp
public override void UpdateEnemyLocation()
{
    // Unique behavior for Enemy One
    EnemyPosition.X += Speed;
}
```

## Constructors

Constructors should focus on initializing the class's variables, preferably with parameters for essential data.
**Example**:
```csharp
public GameMap(Texture2D backgroundSprite, Vector2 mapPosition)
{
    BackgroundSprite = backgroundSprite;
    MapPosition = mapPosition;
    MapEnemies = new List<Enemy>();
}
```

## Comments and Documentation

### XML Documentation
Add XML comments (///) to all public classes, methods, and properties for automatic documentation generation.
**Example**:
```csharp
/// <summary>
/// Updates the position of the player based on input.
/// </summary>
public void UpdatePosition()
{
    // Logic here
}
```

### Inline Comments
Use inline comments to explain complex logic or non-obvious decisions.
**Example**:
```csharp
// Prevent the player from moving below the ground level
if (PlayerPosition.Y > GroundLevel)
{
    PlayerPosition.Y = GroundLevel;
}
```

## Error Handling

### Try-Catch Blocks
Handle exceptions gracefully and provide meaningful error messages.
**Example**:
```csharp
try
{
    // Load game assets
}
catch (Exception ex)
{
    Console.WriteLine($"Error loading assets: {ex.Message}");
}
```

## Project Structure and Organization

### File Structure
Organize files by type or feature for clarity.
Example:
/Classes
    Player.cs
    Enemy.cs
    GameMap.cs
/UI
    GameUI.cs

