# MobilePlayground

## Overview
A Unity-based mobile RTS/Rogue-like/Auto-Battler game. Place buildings, produce units/resources, and battle enemy waves to destroy the enemy base.

## Project Structure
- `Scripts/` — C# scripts for game logic
- `Prefabs/` — Unity prefabs for buildings, units, etc.
- `Art/` — Art assets (sprites, textures, etc.)
- `Scenes/` — Unity scenes
- `UI/` — UI assets and prefabs

## Setup Instructions
1. Open this folder in Unity Hub and create/open the project.
2. Place your assets and scripts in the appropriate folders.
3. Build for Android/iOS via File > Build Settings.

## Requirements
- Unity 2021.3 LTS or newer
- Android/iOS build support modules


## Initial Scene
- Create a new scene named `MainScene` in the `Scenes/` folder.
- Add three placeholder objects:
	- PlayerBase (blue cube) at (-8, 0, 0)
	- EnemyBase (red cube) at (8, 0, 0)
	- Field (green, flat rectangle) at (0, 0, 0), scale (16, 0.2, 4)
- Attach the `PlaceholderObject` script to each and set the `objectType` and `color` fields.

See `Scenes/README.txt` for details.

---
Replace placeholder assets and scripts with your own as development progresses.
