# Sidewinder Syndicate Quick Reference

## Commander-Building-Unit Mapping

### 1. Marshal Coil (Defensive)
**Files:** `MarshalCoilCommander.cs`, `MarshalCoilRuntime.cs`
**Buildings:**
- CoilWatchtower → Defense aura
- FortifiedDepot → Armor bonus
- ContractMilitiaPost → **SPAWNER** → ContractMilitiaUnit
- BountyTelegraphOffice → Enemy marking

**Passive:** Units near buildings gain armor + regen
**Active:** Orbital barrage on all enemies

---

### 2. Hexshot Harlan (Aggressive Economy)
**Files:** `HexshotHarlanCommander.cs`, `HexshotHarlanRuntime.cs`
**Buildings:**
- CursedGunsmith → Ricochet enhancement
- GamblersDen → Random kill bonuses
- RicochetRange → Projectile bounces
- BountyBank → Dividend income

**Passive:** Kills grant credits + cooldown refund
**Active:** Ricochet bullets hit 5 enemies

---

### 3. Train Baron Slith (Infrastructure)
**Files:** `TrainBaronSlithCommander.cs`, `TrainBaronSlithRuntime.cs`
**Buildings:**
- RailHub → Network connector
- ArmoredTrainyard → **SPAWNER** → SupplyTrainUnit
- FreightDepot → Credit conversion
- SignalTower → Range/damage boost

**Passive:** Rail-connected buildings get bonuses
**Active:** Summon supply trains for buffs

---

### 4. Deadman's Hand (High Stakes)
**Files:** `DeadmansHandCommander.cs`, `DeadmansHandRuntime.cs`
**Buildings:**
- HighStakesSaloon → Gamble on building
- BondOffice → Immediate income, future penalty
- InsuranceBureau → Destruction protection
- GraveLedger → Failure mitigation

**Passive:** Scaling income, no refunds
**Active:** Buff building - survive = bonus, die = penalty

---

### 5. Doc Venom (Heal/Overclock)
**Files:** `DocVenomCommander.cs`, `DocVenomRuntime.cs`
**Buildings:**
- VenomClinic → Healing aura
- OverclockLab → Damage/speed boost
- MedDroneBay → **SPAWNER** → RepairDroneUnit
- CoolingTower → Heat dissipation

**Passive:** Periodic healing for all units
**Active:** Heal burst + overclock boost

---

### 6. The Sheriff (Automation)
**Files:** `TheSheriffCommander.cs`, `TheSheriffRuntime.cs`
**Buildings:**
- JusticeDroneFoundry → **SPAWNER** → JusticeDroneUnit
- LawOffice → Fine collection
- SurveillancePost → Enemy detection
- HoldingCell → Enemy slowing

**Passive:** Auto-tag high-threat enemies
**Active:** Empower all justice drones

---

### 7. Bounty Queen Rattle (Target Priority)
**Files:** `BountyQueenRattleCommander.cs`, `BountyQueenRattleRuntime.cs`
**Buildings:**
- BountyBoard → Mark & reward system
- HuntersLodge → Anti-marked damage bonus
- TaggingStation → Area marking
- TrophyVault → Rotating buffs

**Passive:** Marked kills = team buffs (stacking, decaying)
**Active:** Mark 3 priority targets

---

### 8. Goldfang (Greedy Economy)
**Files:** `GoldfangCommander.cs`, `GoldfangRuntime.cs`
**Buildings:**
- CorpseCollector → Corpse-to-credits
- ChokePointCartel → Positional bonuses
- SmelterMint → Scaling production
- RiskExchange → Risk-reward payouts

**Passive:** Corpses at choke points = bonus credits
**Active:** Convert all corpses to credits

---

## Unity Integration Checklist

### Per Commander (x8)
- [ ] Create commander prefab with script attached
- [ ] Create 4 building prefabs (assign scripts, set costs/health)
- [ ] For spawner buildings: create unit prefab first, assign to productPrefab
- [ ] Add buildings to MarketManager.buildingTiers in Inspector

### Spawner Buildings (4 total)
1. ContractMilitiaPost → ContractMilitiaUnit
2. ArmoredTrainyard → SupplyTrainUnit
3. MedDroneBay → RepairDroneUnit
4. JusticeDroneFoundry → JusticeDroneUnit

### Recommended Costs
- Support: 75 credits
- Economy: 100 credits
- Spawners: 125 credits
- Turrets: 150 credits

### Recommended Health
- Economy: 25 HP
- Support: 30 HP
- Spawners: 35 HP
- Turrets: 40 HP

### Production Intervals
- Fast spawners: 10s
- Standard: 15s
- Slow spawners: 20s

---

## Script Count Summary
- **Commander Scripts:** 8
- **Runtime Helpers:** 8
- **Building Scripts:** 32 (4 per commander)
- **Unit Scripts:** 4 (for spawners)
- **Total C# Files:** 52

---

## File Locations
```
Assets/Scripts/
├── Commanders/Sidewinder/
│   ├── MarshalCoil/
│   ├── HexshotHarlan/
│   ├── TrainBaronSlith/
│   ├── DeadmansHand/
│   ├── DocVenom/
│   ├── TheSheriff/
│   ├── BountyQueenRattle/
│   └── Goldfang/
├── Buildings/Sidewinder/
│   └── [same structure]
└── Units/Sidewinder/
    ├── MarshalCoil/
    ├── TrainBaronSlith/
    ├── DocVenom/
    └── TheSheriff/
```

---

## Testing Priority Order
1. **Marshal Coil** - Simplest, good baseline test
2. **Doc Venom** - Test healing mechanics
3. **The Sheriff** - Test autonomous behavior
4. **Hexshot Harlan** - Test economy scaling
5. **Train Baron Slith** - Test network effects
6. **Bounty Queen Rattle** - Test buff stacking
7. **Deadman's Hand** - Test gambling mechanics
8. **Goldfang** - Test corpse system

---

## Known Simplifications
- Enemy marking: logic-based, no visual markers
- Corpse system: tracked in runtime, no GameObject corpses
- Targeting: auto-target nearest instead of manual selection
- Rail network: radius-based instead of actual pathfinding
- Heat/overclock: simplified without explosion mechanics
- Choke points: proximity-based instead of map analysis

---

## Common Debug Commands

Add to GameManager for testing:
```csharp
// Spawn test enemy
if (Input.GetKeyDown(KeyCode.E))
    SpawnTestEnemy();

// Grant credits
if (Input.GetKeyDown(KeyCode.M))
    playerMoney += 100;

// Trigger commander ability
if (Input.GetKeyDown(KeyCode.Space))
    FindObjectOfType<Commander>()?.ActivateAbility(this);

// Kill all enemies
if (Input.GetKeyDown(KeyCode.K))
    foreach(var u in FindObjectsOfType<Unit>())
        if(u.isEnemy) u.health = 0;
```
