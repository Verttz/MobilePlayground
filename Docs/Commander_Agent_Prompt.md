# Commander Creation — Multi-Agent Prompt

Objective: Implement all commanders across five races, with four unique buildings per commander, units spawned from applicable buildings, and both passive (trait) and active abilities fully wired and functional.

---

## Plan Overview (Read First)
- Scope:
  - Implement per the design in [CommanderDesignDoc.md](../CommanderDesignDoc.md) and conventions in [Commander_Implementation_Guide.md](Commander_Implementation_Guide.md).
- Concurrency strategy:
  - Work is split per race/commander to minimize conflicts. Use one branch per commander.
  - Branch naming: `feature/<race>/<commander>` (e.g., `feature/sidewinder/marshal-coil`).
- Coding contracts:
  - Commanders derive from `Commander` (see [Assets/Scripts/Commanders/Commander.cs](../../Assets/Scripts/Commanders/Commander.cs)); implement `ApplyTrait(GameManager gm)` for the passive and `ActivateAbility(GameManager gm)` for the active.
  - Buildings derive from `Building` (see [Assets/Scripts/Buildings/Building.cs](../../Assets/Scripts/Buildings/Building.cs)); spawners override `Produce()` and set `productPrefab`.
  - Units derive from `Unit` (see [Assets/Scripts/Units/Unit.cs](../../Assets/Scripts/Units/Unit.cs)); override `AttackTarget()` as needed; set flags such as `isEnemy`, `isRanged`.
- Prefabs & integration:
  - Create building prefabs and unit prefabs under `Assets/Prefabs/<Race>/<CommanderName>/{Buildings|Units}/` and attach scripts.
  - Add building prefabs to `MarketManager.buildingTiers` via Inspector so they appear as options.
- Non-invasive principle:
  - Do not modify core managers or base classes unless absolutely necessary; prefer helper MonoBehaviours attached at runtime for passives/auras.
- Deliverables (per commander):
  - 1 commander class; 4 building classes + prefabs; any required unit classes + prefabs; passive wired via `ApplyTrait`; active wired via `ActivateAbility`; basic test verified.

---

## Execution Steps (Per Commander)
1. Scaffolding
   - Create `Assets/Scripts/Commanders/<Race>/<CommanderName>/<CommanderName>Commander.cs` (extends `Commander`).
   - Create 4 building scripts under `Assets/Scripts/Buildings/<Race>/<CommanderName>/` (extend `Building`).
   - For each spawner building, create unit scripts under `Assets/Scripts/Units/<Race>/<CommanderName>/` (extend `Unit`).
2. Prefabs
   - Create building prefabs under `Assets/Prefabs/<Race>/<CommanderName>/Buildings/` and attach the building scripts.
   - Create unit prefabs under `Assets/Prefabs/<Race>/<CommanderName>/Units/` and set `Building.productPrefab` for spawners.
3. Passive ability (trait)
   - Implement in `ApplyTrait(GameManager gm)`. If continuous effects are needed, add a runtime helper component (e.g., `MarshalCoilRuntime`) to `GameManager.Instance.gameObject`.
4. Active ability
   - Implement in `ActivateAbility(GameManager gm)`. If targeting UI is not available, auto-target nearest sensible object and log TODOs for UI hookup.
5. Market integration
   - Register building prefabs into `MarketManager.buildingTiers` (Inspector) so they surface in the four option buttons.
6. Validation
   - Place buildings via the existing placement flow; verify spawners produce units; trigger active ability; observe passive effects.
7. Documentation & PR
   - Include a short mapping from design entries to implemented classes and prefabs; note any approximations.

---

## Constraints & Quality Bar
- Style: Minimal changes, follow existing naming and folder structure; classes in PascalCase.
- Safety: No breaking edits to `GameManager`, `GridManager`, `MarketManager`, `Building`, or `Unit` unless coordinated.
- Performance: Keep per-frame logic small; prefer event-style triggers or timed intervals.
- Tests: Manual playtest in scene; verify placement, production, combat, and ability triggers without exceptions.

---

## Commander-Specific Mapping
Use [CommanderDesignDoc.md](../CommanderDesignDoc.md) for exact names. Example mappings:
- Sidewinder/Mars hal Coil: Passive Bulwark; Buildings — Coil Watchtower (support), Fortified Depot (support), Contract Militia Post (spawner → `ContractMilitiaUnit`), Bounty Telegraph Office (support).
- Helio/Prism Mother: Passive Refraction; Buildings — Prism Nursery (support), Refraction Tower (support), Shard Hive (spawner → `ShardlingUnit`), Lightscatter Loom (support).
- Void/Gravemaster: Passive Gravitic Memory; Buildings — Gravity Well Anchor, Orbital Lure, Vector Bastion, Path Shaper (all support/pathing).
- Chorus/Dirge: Passive Mourners' Weight; Buildings — Wailing Spire, Memorial Cloister, Elegy Drum (support), Black Procession (spawner → `SpectralReinforcementUnit`).
- Scrap/Machine God: Passive Self-Design; Buildings — Directive Temple, Mutation Forge, Observation Spire, Catalyst Pool (support), plus autonomous `MachineGodEntity`.

---

## Acceptance Criteria (Per Commander)
- Passive:
  - `ApplyTrait` runs without exceptions and produces the intended effect (or a documented approximation with a runtime component).
- Active:
  - `ActivateAbility` triggers reliably; targeting behavior is deterministic and logged.
- Buildings:
  - All four buildings exist, attached to prefabs, placed via market/placement flow.
  - Spawner buildings produce their units at `productionInterval` and on position.
- Units:
  - Units participate in combat (movement, targeting, attack) per `Unit` logic; any special flags are set.
- Integration:
  - Market options surface; buildings place on unlocked grid cells and interact with game state.

---

## Prompt (Use As-Is)
You are implementing a single commander (and their buildings/units) from the design in [CommanderDesignDoc.md](../CommanderDesignDoc.md), following the conventions in [Commander_Implementation_Guide.md](Commander_Implementation_Guide.md).

Do the following in a dedicated branch named `feature/<race>/<commander>`:
- Create the commander class extending `Commander` and implement:
  - `ApplyTrait(GameManager gm)` for the passive; add any helper MonoBehaviour for ongoing effects.
  - `ActivateAbility(GameManager gm)` for the active; if targeting UI is missing, auto-target nearest relevant object and leave a TODO.
- Create four building classes (extend `Building`) matching the design names and roles. For spawners, override `Produce()` and set `productPrefab` to the corresponding unit prefab.
- Create all required unit classes (extend `Unit`) that are spawned by spawner buildings; implement any special behavior (e.g., ranged, flying) via fields and/or override `AttackTarget`.
- Create building and unit prefabs under `Assets/Prefabs/<Race>/<CommanderName>/{Buildings|Units}/`, attach scripts, and wire references.
- Register building prefabs to appear in `MarketManager.buildingTiers` via the Inspector so they can be offered as market options.
- Validate in-editor: place buildings via the existing flow, confirm spawners produce units, test passive/active ability behavior without exceptions.
- Submit a PR with a brief mapping of design entries to implemented classes/prefabs, known limitations, and manual test notes.

Constraints:
- Do not modify core manager/base classes unless required; if required, keep changes minimal and documented.
- Keep per-frame logic light; prefer intervals or event triggers.
- Follow file/folder naming, PascalCase classes, and Unity conventions.

Deliverables:
- Code files for commander, buildings, and units.
- Prefabs with scripts attached and references wired.
- A short README in the commander folder summarizing implementations (optional but preferred).
