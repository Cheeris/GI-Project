[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/0n2F_Zha)
# Game Design Document (GDD)

### Table of contents
* [Game Overview](#Game-Overview)
* [Story and Narrative](#Story-and-Narrative)
* [Gameplay and Mechanics](#Gameplay-and-Mechanics )
* [Levels and World Design](#Levels-and-World-Design)
* [Art and Audio](#Art-and-Audio)
* [User Interface (UI)](#User-Interface-(UI))
* [Technology and Tools](#Technology-and-Tools)
* [Team Communication, Timelines and Task Assignment](#Team-Communication-and-Task-Assignment)
* [Possible Challenges](#Possible-Challenges)
* [References](#references)


## Game Overview

### Core Concept


### Genre


### Target Audience



### Unique Selling Points (USPs)


## Story and Narrative

### Backstory


 
## Gameplay and Mechanics 


### Player Perspective

- This game is a third-person game. The camera moves as the player moves during the game. The camera is fixed on a distinct height above the player. The player is always in the center of the camera’s view. When we switch between the characters, the camera would move to the position of the switched character and focus on it. This player perspective can provide the player a great field of view, which can make the player have quick response to the map situation. Another advantage of this perspective is that it has a smaller possibility to trigger 3D Vertigo syndrome, which makes the player have nausea, vomiting, palpitation.
- The prototype of the player perspective: ![player1](Images/player1.png)
    
### Controls

- Movement: The player can use “w” “a” “s” “d” to control the movement of the character
- Switch between the characters: The player can press “q” to switch between the two characters. ![Untitled](https://github.com/COMP30019/project-1-cheesego/assets/113833060/27af47e1-abe4-48d3-b655-e2419df44bdd)
- Attack:  The player can press “j” to perform a normal attack, press “k” to perform a skill
- Opening the treasure chest: The player can control the character 2 to hack into the treasure chest and use “w” “a” “s” “d” to finish a simple QTE (Quick Time Event) in order to open the treasure chest.


### Progression

This game separates the 5 minutes time survival into two challenges:
1. Control the character 1 to save the character 2 and survive. (About 2 minutes)
2. Control both two characters and use their distinct skills to defeat the enemies and survive until reinforcements arrive. (About 3 minutes)

The first challenge is a tutorial challenge, which means it has low difficulty and makes sure most of players are able to complete it. The player can get familiar with the controls of the two characters and their distinct effect of skills. If character 2 is not saved in the limited 2 minutes time or the controlled character 1 is dead, the player would “lose“ the game. Otherwise, the game would enter the second phase.

The second challenge would have increasing difficulty during the 3 minutes time survival. The amount of enemies would increase as the time remaining to survive decreases. Enemies would be spawned for a a while during each tier and the player is provided with some rest time in order to prevent player from feeling tired. Additionally, more types of enemies would appear, which can increase the difficulty of the game.

When the game succeed, the score of the game would be computed according to the amount of damage received during the game. The less damage received the higher score the player would get. Four rates (S, A, B, C) would also be provided based on the final score.

The main purpose of dividing the 5 minutes time survival into two challenge is in order to provide the players positive feedback, instead of simply surviving for 5 minutes. The first challenge can attract players’ interest and enjoy the special game mechanics of the game. The second challenge would be a bit challenging, which is beneficial to the game. The player can get excited as the difficulty increases.
        
### Gameplay Mechanics

The core mechanics in the game is that the player can switch between two characters to defeat different types of enemies and interact with the game world. For example, If the player switch to the character 2, character 1 would automatically follow the character 2 controlled by the player and perform normal attack. In order to emphasize the core mechanics, the two characters would have different special skills:
- Character 1: Can deal damage to enemies in a large area around her.
- Character 2: Can hack into the treasure chest to get the item. Can hack into the enemies to cause a large amount of damage to the hacked enemy or make the hacked enemy attack other enemies for a limited time and then explode.
    
In challenge 2, the game would have more types of enemies with different rules, including hack-damage-resist, which encourages more switching between the two characters. Player is encouraged to use Character 1 to defeat large amount of enemies with relatively low HP, and to use Character 2 to defeat the Elite enemies with high HP.

QTE system would be added into the hack process, which makes hack interesting. Player should finish the QTE in limited time, otherwise the character 2 (who has the hack skill) would receive some damage. During the QTE, the player cannot control the character 2 and switch between two characters. To finish the QTE, player need to press down the “w” “a” “s” “d” in a distinct order randomly generated by the system. Although the QTE system would not be extremely difficult, it can still increase the excitement of the time survival game.

## Levels and World Design

### Game World

The game is presented in a **single third-person** perspective, which allows players to fully immerse themselves in the experience. 

While there is only one level, it is divided into **two distinct areas** that offer unique challenges to the player.
- The wild forest, for instance, is a vast location that provides players with an opportunity to explore and gather essential tools to aid in combat with the enemy robots.
- The castle, on the other hand, is the ultimate destination where the player must secure the hacker while facing intense resistance from the enemy. 

To aid in player navigation, a **minimap** is displayed on the top right of the screen, which not only helps players find their way but also adds to the overall immersive experience of the game. 

### Objects

#### Enemy robots

These robotic adversaries have different characteristics and roles within the game.
- **Normal Robots:** Average stats in terms of health and attack.
- **Robot Wall:** High health but lower attack power, acting as durable obstacles.
- **Robot Knight:** High attack power with a chance of critical hits, but lower health compared to other enemies.
- **Robot Queen:** A unique enemy that is invulnerable to physical attacks. Can only be affected by hacking. Only appears after rescuing the hacker.


#### Tools

Scattered randomly throughout the map, these items provide immediate benefits when collected by the player (interacted with using the F key).
- **Bandage:** Heals 5% of the player's health.
- **Medkit:** Heals 20% of the player's health.
- **Expresso:** Reduces cooldown times by 50% for the next 20 seconds.
- **Energy Drink:** Increases player's attack power by 30% for the next 20 seconds.

### Physics

In the game, the physics closely resemble those of the real world, creating a more immersive experience for the player. The player is able to interact with objects in the environment, such as picking up tools and engaging in combat with robots. This adds a layer of depth to the gameplay as the player can use these tools to their advantage to overcome obstacles and defeat enemies. It's worth noting that robots in the game lack the ability to pick up tools, which creates a strategic element for the player to consider. 

## Art and Audio

### Art Style

### Sound and Music
### Assets

## User Interface (UI)



## Technology and Tools

For the development of this game, we will be using a combination of industry-standard software and tools to create a cohesive and high-quality gaming experience:

1. **Unity (Version 2022.3.X)**
2. **GitHub:** We will use GitHub for version control and collaborative development. It ensures that the team can work on different aspects of the game simultaneously, and we can track changes and resolve conflicts efficiently. 
3. **Excalidraw:** Excalidraw will be used for sketching and presenting initial ideas for level designs, character concepts, and environment layouts. It's a simple yet effective tool for visual brainstorming. 
4. **Canva:** Canva will be our primary tool for UI/UX design. It's a collaborative design tool that allows real-time collaboration, making it easy to create and iterate on our game's user interface. 
5. **Photoshop:** Photoshop will be used for image editing, including creating textures, concept art, and editing UI elements to ensure a polished visual presentation.

## Team Communication, Timelines and Task Assignment

### Team Communication
To ensure effective communication, manage timelines, and delegate tasks efficiently, we'll use the following tools:

1. **Notion:** 
    - Notion will be our hub for organizing resources, tracking meeting notes, and sharing important project-related information. It keeps everything in one place, making it easy to access and collaborate on essential documents. ![notion1.png](Images/notion1.png)
    -  It will also be our task management tool. We'll create boards for different aspects of the project (e.g., level design, coding) and assign tasks, set deadlines, and track progress. 
        - On the task board, we break a milestone into several tasks sorted by priority and delegate them to team members. ![notion2.png](Images/notion2.png)
        - On the project board, we can track the overall progress of each milestone. ![notion3](Images/notion3.png)
2. **WeChat**: WeChat will serve as our primary communication channel for quick updates, discussions, and coordination among team members. It's widely used and ensures real-time communication. 


### Timeline

To ensure we meet our project deadline, we've established sub-deadlines, breaking tasks into two key phases: execution and review. The execution phase will occupy around 60-70% of the milestone period, with the remainder focused on iterative reviews and optimizations. This approach guarantees timely completion while emphasizing quality. Since we're unaware of potential game bugs or player experience enhancements, we've reserved sufficient time to ensure top-notch quality.

For instance, within Project 2, we've primarily split the development process into two stages: Development and Testing.

The timeline visualization can be seen in the picture below: ![timeline](Images/timeline.png)

| Team Member | Responsibility | 
| -------- | -------- | 
| Kexin Chen    | Manage the collaboration tools; Develop the enemies behaviours   | 
| Kaisheng Su    | Developer: Build the major interactions between player and character   | 
| Feifei Hao    | Developer: Build the UI system and tool's effects   | 
| Haoyuan Qin | Developer: Build the game world and scoring system |


## Possible Challenges

While we are excited about creating this game, we acknowledge that there may be challenges along the way:

1. **Technical Hurdles:** Developing a 3D action-adventure game involves complex programming and integration. We'll address this by breaking down tasks into manageable components and regularly conducting prototyping and testing to identify and resolve technical challenges. 
2. **Time Constraints:** Developing a high-quality game within the given timeframe can be challenging. We'll mitigate this by setting realistic milestones, tracking progress, and ensuring efficient time management. Iterative development and prioritization will be key.
3. **Balancing Gameplay:** Ensuring the gameplay is engaging, challenging, and well-balanced requires careful design and testing. We'll conduct a small scale of playtesting to gather feedback and fine-tune the game mechanics, difficulty levels, and pacing.
4. **Collaboration Challenges:** Effective collaboration among team members is essential. We'll schedule regular meetings, use project management tools, and maintain clear documentation to ensure everyone is aligned and informed.

By addressing these challenges proactively and maintaining a flexible approach, we're confident that we can overcome obstacles and deliver a successful and enjoyable game.

## References 

