# Race 1: Sidewinder Syndicate Implementation

## Overview
This document maps the implemented classes and prefabs to the design specifications from CommanderDesignDoc.md.

## Implementation Status

### Commanders Implemented (8/8)

#### 1. Marshal Coil ✓
- **Commander:** `MarshalCoilCommander.cs`
- **Runtime Helper:** `MarshalCoilRuntime.cs`
- **Passive:** Bulwark of the Line - Units near buildings gain armor and regeneration
- **Active:** Dead Noon - Orbital revolver barrage damaging all enemy units
- **Buildings:**
  - `CoilWatchtower.cs` - Defensive turret with defense aura
  - `FortifiedDepot.cs` - Armor-granting support building
  - `ContractMilitiaPost.cs` - Spawner building
  - `BountyTelegraphOffice.cs` - Enemy marking support
- **Units:**
  - `ContractMilitiaUnit.cs` - Temporary militia with contract duration

#### 2. Hexshot Harlan ✓
- **Commander:** `HexshotHarlanCommander.cs`
- **Runtime Helper:** `HexshotHarlanRuntime.cs`
- **Passive:** Hex Refund - Enemy kills refund cooldown and grant bonus credits
- **Active:** Ricocheting cursed bullets hitting multiple enemies
- **Buildings:**
  - `CursedGunsmith.cs` - Ricochet enhancement support
  - `GamblersDen.cs` - Chance-based economy building
  - `RicochetRange.cs` - Projectile bounce training
  - `BountyBank.cs` - Bounty storage with dividends

#### 3. Train Baron Slith ✓
- **Commander:** `TrainBaronSlithCommander.cs`
- **Runtime Helper:** `TrainBaronSlithRuntime.cs`
- **Passive:** Rail Efficiency - Rail-connected buildings gain bonuses
- **Active:** Summon armored supply trains
- **Buildings:**
  - `RailHub.cs` - Rail network connector
  - `ArmoredTrainyard.cs` - Spawner building
  - `FreightDepot.cs` - Credit-to-resource converter
  - `SignalTower.cs` - Range and damage booster
- **Units:**
  - `SupplyTrainUnit.cs` - Mobile supply unit granting shields

#### 4. Deadman's Hand ✓
- **Commander:** `DeadmansHandCommander.cs`
- **Runtime Helper:** `DeadmansHandRuntime.cs`
- **Passive:** All-In Economy - Credit income scales over time, no selling
- **Active:** Gamble on building/unit survival for permanent buffs
- **Buildings:**
  - `HighStakesSaloon.cs` - Gambling mechanic building
  - `BondOffice.cs` - Immediate income with future penalties
  - `InsuranceBureau.cs` - Building protection service
  - `GraveLedger.cs` - Failure mitigation tracker

#### 5. Doc Venom ✓
- **Commander:** `DocVenomCommander.cs`
- **Runtime Helper:** `DocVenomRuntime.cs`
- **Passive:** Controlled Dose - Periodic unit healing
- **Active:** Heal and overclock units with venom injections
- **Buildings:**
  - `VenomClinic.cs` - Healing aura building
  - `OverclockLab.cs` - Attack speed/damage booster
  - `MedDroneBay.cs` - Spawner building
  - `CoolingTower.cs` - Heat dissipation support
- **Units:**
  - `RepairDroneUnit.cs` - Building repair drone

#### 6. The Sheriff ✓
- **Commander:** `TheSheriffCommander.cs`
- **Runtime Helper:** `TheSheriffRuntime.cs`
- **Passive:** Rule of Law - Auto-tags high-threat enemies
- **Active:** Empower justice drones
- **Buildings:**
  - `JusticeDroneFoundry.cs` - Spawner building
  - `LawOffice.cs` - Fine collection building
  - `SurveillancePost.cs` - Enemy detection support
  - `HoldingCell.cs` - Enemy slowing building
- **Units:**
  - `JusticeDroneUnit.cs` - Autonomous combat drone

#### 7. Bounty Queen Rattle ✓
- **Commander:** `BountyQueenRattleCommander.cs`
- **Runtime Helper:** `BountyQueenRattleRuntime.cs`
- **Passive:** Queen's Mark - Marked kills grant stacking team buffs
- **Active:** Mark priority targets
- **Buildings:**
  - `BountyBoard.cs` - Target marking and bounty system
  - `HuntersLodge.cs` - Unit training for marked targets
  - `TaggingStation.cs` - Area-of-effect marking
  - `TrophyVault.cs` - Trophy storage with rotating buffs

#### 8. Goldfang ✓
- **Commander:** `GoldfangCommander.cs`
- **Runtime Helper:** `GoldfangRuntime.cs`
- **Passive:** Greedy Gain - Corpse conversion with choke point bonuses
- **Active:** Convert corpses into credit piles
- **Buildings:**
  - `CorpseCollector.cs` - Corpse-to-credit converter
  - `ChokePointCartel.cs` - Positional bonus building
  - `SmelterMint.cs` - Scaling economy building
  - `RiskExchange.cs` - High-risk, high-reward economics

## File Structure

```
Assets/
├── Scripts/
│   ├── Commanders/
│   │   └── Sidewinder/
│   │       ├── MarshalCoil/
│   │       │   ├── MarshalCoilCommander.cs
│   │       │   └── MarshalCoilRuntime.cs
│   │       ├── HexshotHarlan/
│   │       │   ├── HexshotHarlanCommander.cs
│   │       │   └── HexshotHarlanRuntime.cs
│   │       ├── TrainBaronSlith/
│   │       │   ├── TrainBaronSlithCommander.cs
│   │       │   └── TrainBaronSlithRuntime.cs
│   │       ├── DeadmansHand/
│   │       │   ├── DeadmansHandCommander.cs
│   │       │   └── DeadmansHandRuntime.cs
│   │       ├── DocVenom/
│   │       │   ├── DocVenomCommander.cs
│   │       │   └── DocVenomRuntime.cs
│   │       ├── TheSheriff/
│   │       │   ├── TheSheriffCommander.cs
│   │       │   └── TheSheriffRuntime.cs
│   │       ├── BountyQueenRattle/
│   │       │   ├── BountyQueenRattleCommander.cs
│   │       │   └── BountyQueenRattleRuntime.cs
│   │       └── Goldfang/
│   │           ├── GoldfangCommander.cs
│   │           └── GoldfangRuntime.cs
│   ├── Buildings/
│   │   └── Sidewinder/
│   │       ├── MarshalCoil/
│   │       ├── HexshotHarlan/
│   │       ├── TrainBaronSlith/
│   │       ├── DeadmansHand/
│   │       ├── DocVenom/
│   │       ├── TheSheriff/
│   │       ├── BountyQueenRattle/
│   │       └── Goldfang/
│   └── Units/
│       └── Sidewinder/
│           ├── MarshalCoil/
│           │   └── ContractMilitiaUnit.cs
│           ├── TrainBaronSlith/
│           │   └── SupplyTrainUnit.cs
│           ├── DocVenom/
│           │   └── RepairDroneUnit.cs
│           └── TheSheriff/
│               └── JusticeDroneUnit.cs
└── Prefabs/
    └── Sidewinder/
        ├── MarshalCoil/
        │   ├── Buildings/
        │   └── Units/
        ├── HexshotHarlan/
        │   └── Buildings/
        ├── TrainBaronSlith/
        │   ├── Buildings/
        │   └── Units/
        ├── DeadmansHand/
        │   └── Buildings/
        ├── DocVenom/
        │   ├── Buildings/
        │   └── Units/
        ├── TheSheriff/
        │   ├── Buildings/
        │   └── Units/
        ├── BountyQueenRattle/
        │   └── Buildings/
        └── Goldfang/
            └── Buildings/
```

## Integration Requirements

### Prefab Creation (Unity Editor Required)
For each building and unit, create a prefab in Unity Editor:

1. **Building Prefabs:**
   - Create a GameObject with a sprite renderer
   - Attach the appropriate building script
   - Set conservative balance values:
     - `cost`: 50-150 credits
     - `maxHealth`: 20-50
     - `productionInterval`: 10-20 seconds (for spawners)
   - For spawner buildings, assign the unit prefab to `productPrefab` field
   - Save to appropriate `Assets/Prefabs/Sidewinder/<Commander>/Buildings/` folder

2. **Unit Prefabs:**
   - Create a GameObject with sprite renderer and Collider2D
   - Attach the appropriate unit script
   - Stats are set in Awake() method of each unit script
   - Save to appropriate `Assets/Prefabs/Sidewinder/<Commander>/Units/` folder

### MarketManager Integration
In Unity Editor:
1. Open the scene with MarketManager
2. Select the MarketManager GameObject
3. In Inspector, expand `buildingTiers` array
4. Add building prefabs to appropriate tiers (Tier 0-2 recommended for testing)
5. Ensure at least 4 buildings are available per tier for market options

### Commander Selection
- Commanders need to be integrated into the commander selection UI
- Set commander's `availableBuildings` list to include their 4 unique buildings
- Apply trait on game start via `ApplyTrait(GameManager.Instance)`

## Placeholder Balance Values

### Buildings (Recommended Starting Values)
- **Support Buildings:** cost: 75, maxHealth: 30, productionInterval: N/A
- **Economy Buildings:** cost: 100, maxHealth: 25, productionInterval: N/A
- **Spawner Buildings:** cost: 125, maxHealth: 35, productionInterval: 15s
- **Turret Buildings:** cost: 150, maxHealth: 40, productionInterval: N/A

### Units (Set in Awake())
- **Militia/Basic:** health: 10-15, attack: 3-5, speed: 2-3
- **Drones:** health: 15-25, attack: 4-8, speed: 2-4
- **Support Units:** health: 20-40, attack: 0, speed: 1-3

## Implementation Notes

### Approximations Made
1. **Targeting Systems:** Most abilities auto-target nearest enemies due to lack of targeting UI
2. **Corpse System:** Simplified corpse tracking without actual GameObject corpses
3. **Marking System:** Enemy marking implemented via logic rather than visual markers
4. **Rail Network:** Connection detection via radius checks rather than actual pathfinding
5. **Heat/Overclock:** Simplified heat tracking without full overheat explosion mechanics
6. **Choke Point Detection:** Basic proximity-based rather than full map analysis

### Future Enhancements
- Implement visual marker components for tagged/marked enemies
- Add targeting UI for commander abilities
- Implement actual corpse GameObject spawning and collection
- Add visual effects for auras, buffs, and abilities
- Implement full heat/overclock system with explosion mechanics
- Add sound effects for buildings and abilities
- Create proper choke point analysis system
- Add meta-progression saving/loading

### Testing Checklist
- [ ] Each commander's passive trait activates on game start
- [ ] Each commander's active ability can be triggered without errors
- [ ] Spawner buildings produce correct unit types
- [ ] Support buildings apply their auras/effects
- [ ] Economy buildings generate credits over time
- [ ] Units behave according to their roles (combat/support)
- [ ] Buildings can be purchased and placed via market
- [ ] No null reference exceptions during gameplay

## Known Limitations
- Prefabs must be created manually in Unity Editor (cannot be scripted)
- Some advanced mechanics simplified for MVP implementation
- Visual markers and effects not included (code structure supports addition)
- Balance values are conservative placeholders requiring tuning
- Some building interactions require manual event hookups

## Next Steps
1. Open project in Unity Editor
2. Create all required prefabs following structure above
3. Assign prefabs to MarketManager.buildingTiers
4. Test each commander individually
5. Iterate on balance values
6. Add visual effects and polish
7. Implement advanced targeting systems
8. Add sound effects and UI improvements
