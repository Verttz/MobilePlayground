# Game Design Documentation: RTS/Rogue-like/Auto-Battler

## Core Concepts
- Space/future theme with 4–5 races/factions
- Each race has unique units, buildings, and a race-wide mechanic
- 8–10 commanders per race, each with:
  - Unique active ability
  - Unique trait
  - Access to specific buildings and units
  - 4 personal buildings tailored to their playstyle
- 11–15 units per race:
  - 1–6 melee units
  - 2–5 ranged units
  - 1–6 flying units
  - Some units may be commander-exclusive
- 21 standard buildings (4 per tier, 5 tier 5), plus 4 unique per commander
- 5 maps, each themed after the enemy base’s race
- Relics: Roguelite-style buffs/tweaks with unique effects (unlock grid, give cash, buff units/buildings, etc.)
- Controllable map areas (e.g., gold mine, monster, tile unlock) for strategic buffs

## Gameplay Flow
- Player chooses a race/faction and commander
- Places buildings on a grid (initially 4 columns unlocked, more via upgrades/relics)
- Builds army by purchasing buildings and units
- Fights waves of enemy units, progressing toward the enemy base
- Defeats enemy base to win; loses if all buildings are destroyed
- Collects relics and controls map areas for buffs

## Next Steps (Prototype Phase)
- Start with one race/faction
- Create a handful of commanders (2–3)
- Design a handful of units (3–5)
- Implement basic buildings and relics
- Build out core gameplay loop and test

---

Expand systems and content step by step, playtest, and refine as you go.
