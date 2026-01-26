# Multi-Agent Implementation Guide: Commanders, Buildings, Units, Abilities

Purpose: Enable multiple agents to concurrently implement all commanders, unique buildings, spawned units, and both passive/active abilities across all races, while matching the project’s current code structure and avoiding conflicts.

---

## Scope & Baseline
- Engine: Unity (C#)
- Core base classes:
  - Commander base: [Assets/Scripts/Commanders/Commander.cs](../../Assets/Scripts/Commanders/Commander.cs)
  - Building base: [Assets/Scripts/Buildings/Building.cs](../../Assets/Scripts/Buildings/Building.cs)
  - Unit base: [Assets/Scripts/Units/Unit.cs](../../Assets/Scripts/Units/Unit.cs)
  - Managers: [GameManager](../../Assets/Scripts/Managers/GameManager.cs), [GridManager](../../Assets/Scripts/Managers/GridManager.cs), [MarketManager](../../Assets/Scripts/Managers/MarketManager.cs)
- Placement & UI:
  - Placement via `GridManager.PlaceBuilding()` and `BuildingPlacer`
  - Market option pipeline via `MarketManager.buildingTiers` and `optionButtons`

---

## Architectural Conventions
- File/folder structure (create folders if missing):
  - Commanders: Assets/Scripts/Commanders/<Race>/<CommanderName>/
  - Buildings: Assets/Scripts/Buildings/<Race>/<CommanderName>/
  - Units: Assets/Scripts/Units/<Race>/<CommanderName>/
  - Prefabs: Assets/Prefabs/<Race>/<CommanderName>/{Buildings|Units}/
- Naming:
  - Classes: PascalCase. Example: `MarshalCoilCommander`, `CoilWatchtower`, `ContractMilitiaUnit`.
  - Files match class names (Unity convention).
  - For building spawners, set `Building.productPrefab` to the correct unit prefab.
- Commander implementation contract:
  - `ApplyTrait(GameManager gm)`: apply passive (trait) effects, register listeners, or attach runtime components.
  - `ActivateAbility(GameManager gm)`: perform the active effect (spawn, buff, explosion, etc.).
- Building implementation contract:
  - Derive from `Building`. Override `Produce()` for spawner buildings. Use `OnDestroyed()` as needed.
  - Tune `cost`, `productionInterval`, `maxHealth` per design.
- Unit implementation contract:
  - Derive from `Unit`. Override `AttackTarget()` and/or provide flags (`isEnemy`, `isRanged`, optional bool fields like `isFlying`).

---

## Concurrency & Branching
- Work split by race or by commander to minimize conflicts.
- Branch naming: `feature/<race>/<commander>` (e.g., `feature/sidewinder/marshal-coil`).
- Each branch adds only its commander + buildings + units + prefabs + minimal integration to manager lists.
- Avoid editing shared core files unless necessary; if needed, coordinate via a separate PR and stub feature flags first.

---

## Implementation Steps (Per Commander)
1. Code scaffolding
   - Create `.../Commanders/<Race>/<CommanderName>/<CommanderName>Commander.cs` extending `Commander`.
   - Create 4 building classes in `.../Buildings/<Race>/<CommanderName>/` extending `Building`.
   - For each spawner building, create 1+ unit classes in `.../Units/<Race>/<CommanderName>/` extending `Unit`.
2. Prefabs
   - Create building prefabs in `Assets/Prefabs/<Race>/<CommanderName>/Buildings/` with attached scripts and tuned values.
   - Create unit prefabs in `Assets/Prefabs/<Race>/<CommanderName>/Units/` and assign to `Building.productPrefab` for spawners.
3. Market integration
   - Add building prefabs to appropriate `MarketManager.buildingTiers` (Inspector) so they can appear as options.
4. Passive (trait) wiring
   - Implement in `ApplyTrait(gm)`. If ongoing logic is needed, attach a helper `MonoBehaviour` component (e.g., `MarshalCoilRuntime`) to `GameManager.Instance.gameObject` or create it on-demand.
5. Active ability wiring
   - Implement in `ActivateAbility(gm)`.
   - If ability needs targeting, either: a) work with existing selection UI, or b) temporarily auto-target nearest relevant object (documented for iteration).
6. Registration and test
   - Ensure newly created commander is selectable (scene/UI integration TBD). For now, validate that `ApplyTrait` runs, buildings can be placed, and spawner buildings produce correct units.

---

## Design→Code Mapping (Spawner vs Support)
Notes: “Spawner” buildings must override `Produce()` and set `productPrefab`. “Support/Utility” buildings apply auras or one-off effects in `Update()` or via attached components.

### Race 1 — Sidewinder Syndicate
- Marshal Coil (Passive: Bulwark of the Line)
  - Coil Watchtower — Support turret
  - Fortified Depot — Support aura
  - Contract Militia Post — Spawner → `ContractMilitiaUnit`
  - Bounty Telegraph Office — Support (marking)
- Hexshot Harlan (Passive: Hex Refund)
  - Cursed Gunsmith — Support
  - Gambler's Den — Support economy
  - Ricochet Range — Support
  - Bounty Bank — Support economy
- Train Baron Slith (Passive: Rail Efficiency)
  - Rail Hub — Support network
  - Armored Trainyard — Spawner → `SupplyTrainUnit`
  - Freight Depot — Support economy
  - Signal Tower — Support range/path
- Deadman’s Hand (Passive: All-In Economy)
  - High-Stakes Saloon — Support (targeted boost)
  - Bond Office — Support economy
  - Insurance Bureau — Support protection
  - Grave Ledger — Support mitigation
- Doc Venom (Passive: Controlled Dose)
  - Venom Clinic — Support heal
  - Overclock Lab — Support overclock
  - Med Drone Bay — Spawner → `RepairDroneUnit`
  - Cooling Tower — Support cooling
- The Sheriff (Passive: Rule of Law)
  - Justice Drone Foundry — Spawner → `JusticeDroneUnit`
  - Law Office — Support debuff/economy
  - Surveillance Post — Support reveal
  - Holding Cell — Support crowd-control
- Bounty Queen Rattle (Passive: Queen’s Mark)
  - Bounty Board — Support mark engine
  - Hunter’s Lodge — Support unit buff
  - Tagging Station — Support area mark
  - Trophy Vault — Support rotating buffs
- Goldfang (Passive: Greedy Gain)
  - Corpse Collector — Support economy (conversion)
  - Choke Point Cartel — Support positional
  - Smelter Mint — Support economy
  - Risk Exchange — Support risk-reward

### Race 2 — Helio-Swarm
- The Dawnbinder — Daylight Obelisk (Support), Chrono Sundial (Support), Photosphere Reservoir (Support), Radiant Outpost (Support)
- Nova Herald — Nova Spire (Support), Burst Crucible (Support), Timing Relay (Support), Overcharge Array (Support)
- The Eclipse — Eclipse Generator (Support), Shadow Nursery (Spawner → `ShadowAdeptUnit`), Nightfall Ward (Support), Obscura Prism (Support)
- Prism Mother — Prism Nursery (Support), Refraction Tower (Support), Shard Hive (Spawner → `ShardlingUnit`), Lightscatter Loom (Support)
- Flare Architect — Detonation Node (Support), Flare Foundry (Support), Rebuild Crane (Support), Thermal Converter (Support)
- Lux Harvester — Compression Vault (Support), Flare Dampener (Support), Capacitor Garden (Support), Light Siphon (Support)
- Radiant Tyrant — Hemolight Crucible (Support), Searing Shrine (Support), Pain Engine (Support), Vital Furnace (Support)
- The Last Sunset — Eventide Bastion (Support), Twilight Forge (Support), Last Light Banner (Support), Collapse Engine (Support)

### Race 3 — Void Union
- Foreman Collapse — Mobile Platform (Support), Transit Gantry (Support), Adaptive Rig (Support), Site Office (Support)
- Union Rep Null — Filing Station (Support), Arbitration Chamber (Support), Compliance Bureau (Support), Benefit Office (Support)
- The Auditor — Assessment Tower (Support marking), Risk Desk (Support), Retention Field (Support slow), Ledger Node (Support payout)
- Gravemaster — Gravity Well Anchor (Support pathing), Orbital Lure (Support), Vector Bastion (Support defense), Path Shaper (Support)
- Shiftwalker — Phase Relay (Support), Crossroad Obelisk (Support), Echo Node (Support), Inversion Gate (Support)
- Overtime Protocol — Tenure Core (Support), Maintenance Hub (Support), Productivity Beacon (Support), Stability Lattice (Support)
- Zoning Commissioner — Boundary Marker (Support), Zoning Office (Support), Permit Kiosk (Support), Taxation Node (Support)
- Singularity Prime — Assimilation Spire (Support), Core Foundry (Support), Grav Control Nexus (Support), Stellar Feeder (Support)

### Race 4 — Chorus of Many
- The First Voice — Rally Ampitheater (Support), Fresh Echo Nursery (Support), Momentum Drum (Support), Primer Pavilion (Support)
- Echo Queen — Echo Lattice (Support), Afterimage Gate (Support), Resonance Archive (Support), Memory Pathways (Support)
- The Conductor — Metronome Tower (Support), Sync Node (Support), Crescendo Hall (Support), Staccato Forge (Support)
- Silencer — Null Vault (Support), Quiet Foundry (Support), Silence Field (Support), Brutalist Keep (Support)
- Splitmind — Mirror Loom (Support), Overlay Hub (Support), Feedback Array (Support), Echo Scribe (Support)
- Dirge — Wailing Spire (Support), Memorial Cloister (Support), Elegy Drum (Support), Black Procession (Spawner → `SpectralReinforcementUnit`)
- Archivist — Archive Vault (Support), Curator’s Hall (Support), Testimony Chamber (Support), Heritage Monument (Support/meta)
- The Final Note — Crescendo Stage (Support), Rehearsal Hall (Support), Silence Curtain (Support), Final Baton (Support)

### Race 5 — Scrap Ascendants
- Assembler Alpha — Module Forge (Support), Integration Bay (Support), Optimization Lab (Support), Blueprint Library (Support)
- Rust Prophet — Oxidizer Tower (Support), Corrosion Vat (Support economy), Pitting Array (Support), Decay Relay (Support)
- Patchwork King — Fusion Loom (Support), Patch Port (Support), Graft Bench (Support), Crown Socket (Support)
- The Reclaimer — Scrap Foundry (Support economy), Audit Crane (Support), Recovery Yard (Support), Salvage Terminal (Support)
- Overclocker — Thermal Jack (Support), Stressor Rig (Support), Coolant Plant (Support), Maintenance Den (Support)
- Scrapchild — Merge Yard (Support), Collective Beacon (Support), Trait Nursery (Support), Swarm Pen (Spawner → `FodderUnit`)
- Legacy Protocol — Registry Core (Support), Archive Backplane (Support), Seed Vault (Support/meta), Protocol Relay (Support)
- The Machine God — Directive Temple (Support), Mutation Forge (Support), Observation Spire (Support), Catalyst Pool (Support) — plus a unique autonomous entity `MachineGodEntity` (unit/pseudo-building) required.

---

## Coding Templates

### Commander class template
```csharp
public class MarshalCoilCommander : Commander
{
    public override void ApplyTrait(GameManager gm)
    {
        // Example: add a runtime handler component to apply passive auras
        if (gm != null)
        {
            if (gm.GetComponent<MarshalCoilRuntime>() == null)
                gm.gameObject.AddComponent<MarshalCoilRuntime>();
        }
        traitDescription = "Bulwark of the Line: building-adjacent armor + regen";
    }

    public override void ActivateAbility(GameManager gm)
    {
        // Active ability logic (e.g., Dead Noon barrage)
    }
}
```

### Building spawner override
```csharp
public class ContractMilitiaPost : Building
{
    protected override void Produce()
    {
        if (productPrefab != null)
        {
            Instantiate(productPrefab, transform.position, Quaternion.identity);
        }
    }
}
```

### Unit override example
```csharp
public class ContractMilitiaUnit : Unit
{
    protected override void AttackTarget(Unit target)
    {
        // Example: slightly higher burst on first hit
        base.AttackTarget(target);
    }
}
```

---

## Integration Checklist (Per Commander)
- [ ] Derived commander class created and wired into scene (or selection flow)
- [ ] `ApplyTrait` implements passive; runtime helper component added if needed
- [ ] `ActivateAbility` implemented and manually testable
- [ ] 4 building scripts created and attached to prefabs
- [ ] Spawner buildings: unit scripts + prefabs created; set `productPrefab`
- [ ] Costs, intervals, health tuned with placeholder balance values
- [ ] Buildings added to `MarketManager.buildingTiers` (Inspector)
- [ ] Basic playtest: place buildings, observe production, ability works

---

## QA & Validation
- Manual pass per commander:
  - Place each building, verify expected role (Spawner/Support)
  - Trigger active ability and confirm no exceptions
  - Validate passive effects (visual debug logs if needed)
- Regression checks:
  - Ensure `GameManager.playerBuildings` evolves correctly on build/destroy
  - Verify enemy pathing unaffected unless intended (e.g., Void Union)

---

## Work Allocation Proposal
- Phase 1: Create all class stubs (commanders, buildings, units) and empty prefabs → 1 PR per race.
- Phase 2: Implement passives + simple building behaviors → parallel per commander branches.
- Phase 3: Implement unit behaviors and connect spawners.
- Phase 4: Balance pass + basic VFX/SFX hooks.

---

## Notes & Risks
- Avoid editing base classes unless absolutely required; extend via components.
- For advanced mechanics (e.g., path bending in Void Union), start with a simple approximation (slow/knockback zones) and iterate.
- For meta-progression (Legacy Protocol), stub data persistence behind a simple interface and no-op in-editor.
