# Castle Crashers

A CMPT-306 dungeon crawler game made by a team of 7 people in the span of 1.5ish months!
The name was a coincidence; we just like the ring to it (so did The Behemoth for the real Castle Crashers!)
Note: the class focused on Game Mechanics, most of the visual and audio assets were used from free libraries or purchased from the Unity Store.

## Overview
The goal of the game is to traverse deeper and deeper to new levels of the castle, wield a variety of weapons to battle a variety of enemies, utilize gathered loot and coins to get stronger via opening chests, reciveving permanent power upgrades, and buying stat & skill upgrades. Once the player reach the end of their journey, usually ended from a gruesome death, they would recieve a score based on their performance in the game.

### Stats
Stats could be upgraded between levels and affected the player power in different ways:
- Strength: increase damage of weapons. 
- Agility: increase the attack speed and movement speed of the player.
- Stamnia: increase player health and how increase the effictiveness of health pots.

### Weapons
Several weapons were available to the player, most weapons types focusing on different ranged weapons:
- Sword: a basic weapon that would sweep an area of enemies causing damage.
- Rock: a thrown weapon that is easy to hit with and did moderate damage.
- Arrow: a thrown weapon that hit enemies for a moderate amount of damage and left a small bleed on enemies.
- Fireball: a small, hard to hit with fireball would do a small amount of damage but leave enemies on fire ticking for heavy fire damage. 

### Skills
To further modify the player's power, there are four skills to choose from and level up:
- Stun: modifies melee attacks to stun the enemy for a duration equal to the levels invested in this skill.
- Peircing: causes each ranged attack to peirce through a number of enemies equal to the levels invested in this skill.
- Dash: Allows the player access to the Dash ability, with each subsequent invested level past the first reducing the cooldown of the dash ability.
- Multiply: modifies ranged attacks to fire multiple times baed on the level invested into this skill.

## Development
This project was used as the final project and primary evaluation for the introductory Game Mechanics class (CMPT 306) at the University of Saskatchewan; we had specific goals to achieve to gain a base understanding of game dev.

### Rewards
Much of the class focused on rewarding the player in several ways to make the game fun to play and enjoyable! This involved several different types of rewards:
- Access
- Facility
- Sustenence
- Glory
- Praise
Some of these were easier than others to implement. For instance getting a killstreak **Praises** the player for performing well, there was always a stream of coins and items to **Sustain** the player and create a resource that increases and depletes as the game is played, or achieving **Glory** via a high score at the end of the game. **Access** to extra loot via keys around levels to open chests and a hole to continue through the dungeon. Given the player **Facility** through skills, stats and permanent upgrades to allow the player choice in how they want to play the game. 

### Mechanics
Various mechanics were implemented to support a infinite dungeon crawler game; these included:
- Procedural level generation
- Enemy AI (with the help of Polarith)
- Player movement and combat
- Player weapons with different combat styles
- Player skill system to further enhance combat
- Player pickups, including power ups, items and coin
- Loading system for levels and player skill buy screens
- Inventory system
- General UI
