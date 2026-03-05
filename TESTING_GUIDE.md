# Manual Testing Guide: Sidewinder Syndicate

## Pre-Testing Setup

### 1. Create Prefabs in Unity Editor

For each building and unit script, you need to create a corresponding prefab:

#### Building Prefab Creation
1. Create a new GameObject in the scene
2. Add a SpriteRenderer component (use any placeholder sprite)
3. Add the building script component (e.g., CoilWatchtower)
4. Set the following values in Inspector:
   - `cost`: 50-150 (see recommendations in SIDEWINDER_IMPLEMENTATION.md)
   - `maxHealth`: 20-50
   - `productionInterval`: 10-20 (for spawners only)
5. For spawner buildings, create the unit prefab first, then assign it to `productPrefab`
6. Save as prefab in appropriate folder (e.g., Assets/Prefabs/Sidewinder/MarshalCoil/Buildings/)

#### Unit Prefab Creation
1. Create a new GameObject in the scene
2. Add a SpriteRenderer component
3. Add a CircleCollider2D or BoxCollider2D component
4. Add the unit script component (e.g., ContractMilitiaUnit)
5. Stats are configured in the script's Awake() method, no Inspector setup needed
6. Save as prefab in appropriate folder (e.g., Assets/Prefabs/Sidewinder/MarshalCoil/Units/)

### 2. Configure MarketManager

1. Open your main game scene
2. Select the MarketManager GameObject
3. In Inspector, expand the `buildingTiers` array
4. Add building prefabs to tiers (recommend Tier 0 or 1 for testing)
5. Ensure each tier has at least 4 buildings for market options

### 3. Setup Commander Selection

Option A (Quick Test):
1. Create an empty GameObject in the scene
2. Add one of the commander scripts (e.g., MarshalCoilCommander)
3. In Start() of GameManager, call:
   ```csharp
   FindObjectOfType<MarshalCoilCommander>()?.ApplyTrait(this);
   ```

Option B (Full Integration):
- Implement commander selection UI
- Call `ApplyTrait()` when player selects commander
- Wire up ability activation button to call `ActivateAbility()`

## Testing Each Commander

### Marshal Coil

**Passive Test:**
1. Start game with Marshal Coil as commander
2. Place a ContractMilitiaPost near center of map
3. Wait for militia units to spawn
4. Observe units near buildings - they should regenerate health slowly
5. Check Debug log for "Bulwark of the Line" effects

**Active Test:**
1. Wait for enemy units to spawn
2. Activate Marshal Coil's ability
3. Check Debug log for "Dead Noon barrage" messages
4. Verify enemy units take damage

**Buildings Test:**
- CoilWatchtower: Place and verify defense aura (visual confirmation via debug)
- FortifiedDepot: Place near units, check armor bonuses apply
- ContractMilitiaPost: Verify spawns ContractMilitiaUnit every ~15 seconds
- BountyTelegraphOffice: Place near enemies, check marking logic

**Unit Test:**
- ContractMilitiaUnit: Verify expires after 30 seconds
- Check unit attacks enemies and moves forward when no targets

### Hexshot Harlan

**Passive Test:**
1. Enable Hexshot Harlan commander
2. Place buildings and units
3. Kill enemy units (manually set health to 0 if needed)
4. Observe credit bonuses in Debug log

**Active Test:**
1. Activate ability with multiple enemies present
2. Verify ricochet effect hits up to 5 enemies
3. Check Debug log for hit confirmations

**Buildings Test:**
- CursedGunsmith: Place near ranged units, verify ricochet buff
- GamblersDen: Trigger kills nearby, check for random bonuses
- RicochetRange: Place and verify projectile bounce effects
- BountyBank: Observe periodic credit dividends

### Train Baron Slith

**Passive Test:**
1. Enable Train Baron Slith commander
2. Place a RailHub
3. Place other buildings within connection radius (~6 units)
4. Observe rail network bonuses in Debug log

**Active Test:**
1. Place ArmoredTrainyard or any building
2. Activate ability
3. Verify units near buildings receive health buffs
4. Check Debug log for supply train dispatch

**Buildings Test:**
- RailHub: Place and use Gizmos to see connection radius
- ArmoredTrainyard: Verify spawns SupplyTrainUnit every interval
- FreightDepot: Observe credit conversion shipments
- SignalTower: Place near RailHub, check range/damage bonuses

**Unit Test:**
- SupplyTrainUnit: Verify moves and provides healing aura to nearby units

### Deadman's Hand

**Passive Test:**
1. Enable Deadman's Hand commander
2. Wait and observe passive income scaling
3. Check Debug log for income rate increases
4. Verify income accumulates over time

**Active Test:**
1. Place several buildings
2. Activate ability to buff a random building
3. Wait for duration to expire
4. Check if building survives for permanent buff or dies for penalty

**Buildings Test:**
- HighStakesSaloon: Manually trigger gamble, observe buff/penalty mechanics
- BondOffice: Trigger bond issuance, verify future penalties
- InsuranceBureau: Set up protection, test destruction prevention
- GraveLedger: Record failures, verify mitigation accumulation

### Doc Venom

**Passive Test:**
1. Enable Doc Venom commander
2. Spawn player units
3. Observe periodic healing in Debug log
4. Verify units slowly regain health

**Active Test:**
1. Have player units at less than full health
2. Activate ability
3. Verify units receive healing burst
4. Check for overclock damage boost

**Buildings Test:**
- VenomClinic: Place near units, verify healing aura
- OverclockLab: Check nearby units get damage boost
- MedDroneBay: Verify spawns RepairDroneUnit
- CoolingTower: Place near overclocked units, verify cooldown

**Unit Test:**
- RepairDroneUnit: Verify seeks damaged buildings and repairs them

### The Sheriff

**Passive Test:**
1. Enable The Sheriff commander
2. Spawn enemy units with varying stats
3. Observe auto-tagging of high-threat enemies
4. Check Debug log for threat calculations

**Active Test:**
1. Spawn JusticeDroneUnits
2. Activate ability
3. Verify drones receive empowerment
4. Check attack multiplier increases

**Buildings Test:**
- JusticeDroneFoundry: Verify spawns JusticeDroneUnit
- LawOffice: Observe periodic fine collection
- SurveillancePost: Check enemy detection radius
- HoldingCell: Verify enemy slowing effect

**Unit Test:**
- JusticeDroneUnit: Verify deals bonus damage to high-threat targets
- Check ranged combat behavior

### Bounty Queen Rattle

**Passive Test:**
1. Enable Bounty Queen Rattle commander
2. Mark enemies (via ability or BountyBoard)
3. Kill marked enemies
4. Observe team buff stacking
5. Watch buffs decay slowly over time

**Active Test:**
1. Spawn multiple enemy units
2. Activate ability to mark priority targets
3. Verify up to 3 enemies get marked
4. Check Debug log for marks

**Buildings Test:**
- BountyBoard: Manually mark enemies, verify kill rewards
- HuntersLodge: Check nearby units get damage bonus
- TaggingStation: Use area mark, verify multiple enemies marked
- TrophyVault: Store trophies, observe rotating buffs

### Goldfang

**Passive Test:**
1. Enable Goldfang commander
2. Kill enemies to generate corpses
3. Observe corpse tracking in GoldfangRuntime
4. Verify credit conversion over time

**Active Test:**
1. Kill several enemies
2. Activate ability
3. Verify immediate credit bonus
4. Check Debug log for corpse conversion

**Buildings Test:**
- CorpseCollector: Place and observe periodic corpse collection
- ChokePointCartel: Place at building clusters, verify bonuses
- SmelterMint: Observe scaling credit production over time
- RiskExchange: Monitor risk calculation based on enemy penetration

## Common Issues & Debugging

### Issue: Buildings don't appear in market
**Solution:** 
- Check MarketManager.buildingTiers array in Inspector
- Ensure building prefabs are assigned to at least one tier
- Verify tier count matches available tiers

### Issue: Spawner buildings don't produce units
**Solution:**
- Check productPrefab is assigned in Inspector
- Verify productionInterval is set (10-20 seconds recommended)
- Check GameManager.playerMoney >= 10 for ContractMilitiaPost
- Look for Instantiate errors in Console

### Issue: Commander passive doesn't activate
**Solution:**
- Verify ApplyTrait() is called at game start
- Check runtime component was added to GameManager
- Look for null reference errors in Console

### Issue: Commander ability does nothing
**Solution:**
- Verify GameManager.Instance is not null
- Check that units/buildings exist in scene
- Review Debug log for ability activation messages

### Issue: Units don't move or attack
**Solution:**
- Verify Collider2D component is on unit prefab
- Check isEnemy flag is set correctly (false for player units)
- Ensure Physics2D collision detection is enabled
- Verify enemy units exist for player units to target

### Issue: Auras/buffs don't seem to work
**Solution:**
- Many effects are simplified and show in Debug log only
- Check Console for effect application messages
- For visual confirmation, add Debug.DrawLine in building Update()

## Performance Monitoring

Watch for these potential issues:
1. **Update() called too frequently:** Each building/unit calls Update(), monitor FPS
2. **Physics checks:** OverlapCircleAll calls can be expensive, limit radius
3. **FindObjectsOfType:** Used in some abilities, avoid calling every frame
4. **Memory leaks:** Verify destroyed objects are properly cleaned up

## Balance Tuning

After testing, adjust these values:
1. **Building costs:** Increase if economy breaks, decrease if too expensive
2. **Production intervals:** Adjust spawn rates for game pacing
3. **Damage values:** Tune attack/health for proper combat feel
4. **Aura radii:** Modify range values for better gameplay flow
5. **Credit generation:** Balance passive income and bonuses

## Next Steps After Testing

1. Create visual markers for tagged/marked enemies
2. Add VFX for abilities and auras
3. Implement proper targeting UI for abilities
4. Add sound effects
5. Balance tuning based on playtesting
6. Polish visual feedback for all mechanics
7. Add tooltips explaining building/commander effects
