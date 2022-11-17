# Castle Crashers

A CMPT-306 dungeon crawler game built in Unity and C# by a team of 7 people in the span of 1.5ish months!
The name was a coincidence; we just like the ring to it (so did The Behemoth for the real Castle Crashers!)
Note: the class focused on Game Mechanics, most of the visual and audio assets were used from free libraries or purchased from the Unity Store.

## Overview
The goal of the game is to traverse deeper and deeper to new levels of the castle, wield a variety of weapons to battle a variety of enemies, utilize gathered loot and coins to get stronger via opening chests, receiving permanent power upgrades, and buying stat & skill upgrades. Once the player reaches the end of their journey, usually caused by a gruesome death, they receive a score based on their performance in the game.
Link to our trailer video:

[![Castle Crashers trailer video](http://img.youtube.com/vi/27xrTJ3nenE/0.jpg)](http://www.youtube.com/watch?v=27xrTJ3nenE)

### Stats
Stats could be upgraded between levels and affected the player power in different ways:
- Strength: increases damage of weapons. 
- Agility: increases the attack and movement speed of the player.
- Stamina: increases player health and the effectiveness of health potions.

### Weapons
Several weapons are available to the player, most weapons types focusing on different ranged weapons:
- Sword: a basic weapon that does damage in a small arc from the player.
- Rock: a thrown weapon that is easy to target and hit with that does moderate damage.
- Arrow: a thrown weapon that hits enemies for a moderate amount of damage and leaves a small bleed DoT (damage of time) effect on enemies.
- Fireball: a small, but hard to hit with, fireball that does a small amount of initial damage but leaves enemies on fire; while the enemy is on fire, they periodically take heavy fire damage.

### Skills
To further modify the player's power, there are four skills to choose from and level up:
- Stun: modifies melee attacks to stun the enemy for a duration equal to the levels invested in this skill.
- Piercing: causes each ranged attack to pierce through a number of enemies equal to the levels invested in this skill.
- Dash: Allows the player access to the Dash ability, which allows the player to quickly move a great distance. With each subsequent invested level past the first reduces the cooldown of the dash ability.
- Multiply: modifies ranged attacks to fire multiple times based on the level invested into this skill.

## Development
This project was used as the final project and primary evaluation for the introductory Game Mechanics class (CMPT 306) at the University of Saskatchewan; we had specific goals to achieve to gain a base understanding of game dev. We worked together and delegated various tasks to ensure each team member had work they wanted to complete or had the skills to complete. We often had discussions in weekly meetings, frequent communication via a Discord server with a GitHub webhook to keep track of work completed and Pull Requests (PR). As a team we were able to support each other through tricky problems and review each others work through feedback and PRs.  

### Mechanics & Features
Various mechanics were implemented to support an infinite dungeon crawler game; these included:
- Procedural level generation
- Enemy randomization
- Enemy AI (with the help of Polarith)
- Player movement and combat
- Player weapons with different combat styles
- Player skill system to further enhance combat
- Player pickups, including permanent power ups, items and coins
- Loading system for levels, player skill buy screens and player's current inventory/stats between levels
- Inventory system; item types, stackable items, equippable weapons in left/right click, and more
- General UI; inventory screen and skill buy ui in-game
- Main Menu and Stat Buy screens
- Music system
- Sound Effects
- Achivement System that tracks players progress in several ways, such as killstreaks, total kills, various amounts of items picked up.


### Rewards
Much of the class focused on rewarding the player in several ways to make the game fun to play and enjoyable! This involved several different types of rewards:
- Access
- Facility
- Sustenence
- Glory
- Praise

Some of these were easier than others to implement. For instance getting a killstreak **Praises** the player for performing well, there was always a stream of coins and items to **Sustain** the player and create a resource that increases and depletes as the game is played, or achieving **Glory** via a high score at the end of the game were easy to understand and implement. **Access**, on the other hand, was more difficult and the only thing we added was extra loot via keys around levels to open chests and a hole in the ground to continue through the dungeon; typically this would include different doors and paths in a level but being procedurally generated we opted to focus on chests. Additionally, giving the player **Facility** through skills, stats and permanent upgrades to allow the player choice in how they want to play the game was the most difficult but important for a game with a heavy focus on combat; we were initially going to sprinkle the different weapons throughout the levels or boss battles (was stretch goal) but decided to have the player access to all weapons from the beginning.
