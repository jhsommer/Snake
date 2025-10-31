# Project documentation / Snake Game
### Project description

For this assignment, a small game or feature for an existing project had to be developed.

Important requirements were:
- Minimal but functional implementation (e.g., games such as Breakout or Snake)
- A class diagram as a basis for planning
- Unit tests (at least three)
- Clean, object-oriented implementation
- meaningful use of design patterns
- consistent commit history with meaningful commit messages and an appropriate .gitignore file
- compliance with C# code conventions
- well-structured and readable documentation

I chose the game Snake because I am already familiar with it and it is very well suited for a small but clean object-oriented implementation.

### Planing
During the planning phase, I first created a class diagram to plan the basic structure of the project.
Here is my class diagram from the planning phase:

![class diagram](./docs/images/SoftwareEngineering.drawio.png)

The goal was to achieve clean interaction between the GameManager, Snake, Fruit, Controller, and Program classes.
Particular attention was paid to separating game logic, input, and rendering.

### Implementation
During implementation, I tried to make the game as object-oriented as possible.
I used design patterns where it made sense especially singletons to make the GameManager and Controller centrally accessible.

Since the project was deliberately kept small, I avoided more complex patterns, as they would not have added any additional value here.

Some decisions:

- No common parent class for Snake and Fruit, as both are conceptually very different and have hardly any common properties.
- Instead, I worked with interfaces (IRendable) so that objects could be rendered independently of each other.
- This allows the main program to render all objects via the same interface without knowing their specific implementation.

Example:

IRendable player = _controller.Pawn;  
IRendable fruit = GameManager.GetFruit();

Objects.Add(player);  
Objects.Add(fruit);

This largely decouples the classes from each other and makes the system expandable in terms of rendering.

### Technical Implementation & Challenges
#### Movement & Rendering
- The Draw() function is no longer entirely located in the Main class.
- The rendering has been moved to the Snake and Fruit classes.
- This has made it possible to separate the game logic more clearly, even though there is still some flickering at present because the playing field is completely redrawn for each frame.

#### Logic & Bugs
- A minor bug occurs when collecting fruit: the snake's new body segment initially appears at the position of the head and only then attaches itself correctly to the body.
- The exact error has not yet been fully identified, as it is only cosmetic and does not make the game unplayable.

#### Object orientation & controllers
- The Controller class is responsible for processing input and communicates with the GameManager.
- The GameManager then passes this input to the Snake to trigger movement.
- The Controller class also initializes the snake and sets its starting position.

#### Data structure
- The original plan was to work with a Vector2 structure.
Ultimately, however, I decided to use simple two-dimensional integer coordinates, as this is enough for a 2D console game and reduces complexity.

### Design choices
- **Interfaces**:  
IRendable is used to render objects such as Snake and Fruit uniformly.
This makes it easy to add new objects if they implement the interface.
- **Singletons**:  
  The GameManager and Controller were implemented as a singleton to enable global access similar to larger game engines.
- **Separation of logic and presentation**:  
  The game logic (movement, collision, etc.) is clearly separated from the presentation.
### Conclusion
The project was successfully implemented.
Despite a few known minor bugs (e.g., when new body parts appear), the game logic is stable and comprehensible.  

I learned a lot about clean object orientation, the use of interfaces, and building a simple game loop.

With more time, I would have improved the following points:
- Optimize rendering (avoid flickering)
- Event system for fruit collisions
- Decoupling game logic more from the main class

Nevertheless, I am satisfied with the result, as the game works and principles of OOP have been implemented.