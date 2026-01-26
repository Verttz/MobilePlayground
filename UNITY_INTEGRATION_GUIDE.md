# Unity Integration Guide for Race 3 Commanders

## Quick Start

This guide shows how to integrate the Race 3 commanders and buildings into your Unity project.

## Step 1: Create Prefabs

For each building, you need to create a Unity prefab:

### Example: Creating Mobile Platform Prefab

1. In Unity Editor, right-click in `Assets/Prefabs/Race3/Buildings/`
2. Create → 2D Object → Sprite (or appropriate visual representation)
3. Name it "MobilePlatform"
4. Add Component → Scripts → Mobile Platform
5. Configure in Inspector:
   - Cost: 120 (already set in script)
   - Max Health: 20 (already set in script)
   - Production Interval: 0 (already set in script)
6. Add visual elements (sprite renderer, etc.)
7. Save as prefab

Repeat this process for all 32 buildings.

## Step 2: Commander Setup

### Example: Setting up Foreman Collapse Commander

```csharp
// In your game setup or scene initialization:
public class CommanderSelector : MonoBehaviour
{
    public GameObject foremanCollapsePrefab; // Assign in Inspector
    
    void Start()
    {
        // Instantiate commander
        GameObject commanderObj = Instantiate(foremanCollapsePrefab);
        ForemanCollapseCommander commander = commanderObj.GetComponent<ForemanCollapseCommander>();
        
        // Apply passive trait
        commander.ApplyTrait(GameManager.Instance);
        
        // Commander ability can be triggered via UI button:
        // commander.ActivateAbility(GameManager.Instance);
    }
}
```

## Step 3: Market Integration

To make buildings available in the market:

1. Open MarketManager in Unity Inspector
2. Expand `buildingTiers` array
3. Add Race 3 building prefabs to appropriate tiers:
   - Tier 1: Basic buildings (cost 110-140)
   - Tier 2: Advanced buildings (cost 150-170)
   - Tier 3: Elite buildings (cost 180-200)

Example tier assignment:
```
Tier 1:
- Filing Station (110)
- Mobile Platform (120)
- Boundary Marker (140)

Tier 2:
- Transit Gantry (150)
- Assessment Tower (150)
- Orbital Lure (150)

Tier 3:
- Gravity Well Anchor (180)
- Core Foundry (180)
- Assimilation Spire (200)
```

## Step 4: Building Placement

Buildings use the existing GridManager system:

```csharp
// Example placement code (already integrated in GridManager):
void PlaceBuilding(Building buildingPrefab, Vector2 gridPosition)
{
    if (GameManager.Instance.playerMoney >= buildingPrefab.cost)
    {
        GameManager.Instance.PlaceBuilding(buildingPrefab, gridPosition);
    }
}
```

## Step 5: Testing Commanders

### Test Foreman Collapse:
1. Place a Mobile Platform
2. Activate commander ability to relocate it
3. Verify the building receives productivity buff (check ForemanCollapseRuntime)

### Test Union Rep Null:
1. Activate commander ability to file grievance
2. Wait 3 seconds for delayed boost
3. Verify permanent buffs are applied to all structures

### Test The Auditor:
1. Place Assessment Tower near enemy path
2. Activate ability to mark enemies
3. Verify Mass generation increases over enemy lifetime

### Test Gravemaster:
1. Activate ability to deploy gravity well
2. Verify enemy pathing curves around the well
3. Check that repeated traversals increase well potency

### Test Shiftwalker:
1. Wait for enemies to group up
2. Activate ability to swap enemy positions
3. Verify disorientation debuffs apply

### Test Overtime Protocol:
1. Place buildings and leave them untouched for multiple waves
2. Activate ability to overclock
3. Verify stacking bonuses based on uptime

### Test Zoning Commissioner:
1. Activate ability to create restricted zone
2. Verify enemies in zone receive movement penalties
3. Test zone overlap for compounded effects

### Test Singularity Prime:
1. Build Assimilation Spire
2. Absorb nearby structures
3. Activate ability to relocate with power spike

## Step 6: Debugging

Use Unity Debug Console to verify:

```csharp
// Each commander has Debug.Log statements for testing:
// "Foreman Collapse Ability: Relocate building"
// "Union Rep Null Ability: Filing grievance"
// etc.
```

## Step 7: Visual Feedback (Future Work)

Consider adding:
- Particle effects for abilities
- Visual indicators for buffs/debuffs
- Animation for building relocation
- Zone boundary visualization
- Gravity well distortion effects

## Balance Tuning

After integration, tune these values based on playtesting:

1. **Building Costs** - Adjust 110-200 range as needed
2. **Building Health** - Adjust 18-30 range as needed
3. **Ability Cooldowns** - Not yet implemented, add in future
4. **Buff Magnitudes** - Adjust in Runtime components
5. **Zone Effects** - Adjust debuff percentages

## Common Issues

**Q: Buildings don't appear in market?**
A: Ensure prefabs are added to MarketManager.buildingTiers

**Q: Commander ability does nothing?**
A: Check that Runtime component is attached to GameManager

**Q: Buildings have no visual?**
A: Add SpriteRenderer or other visual components to prefabs

**Q: Passive traits not working?**
A: Verify ApplyTrait() is called on commander initialization

## Next Steps

1. Create all 32 building prefabs
2. Add visual assets (sprites, effects)
3. Implement full Runtime component logic
4. Add UI for ability activation
5. Playtest and balance
6. Add sound effects and polish

## Race 3 Commander Quick Reference

| Commander | Ability | Passive | Buildings Count |
|-----------|---------|---------|-----------------|
| Foreman Collapse | Relocate building | Movement buffs | 4 |
| Union Rep Null | File grievance | Permanent buffs | 4 |
| The Auditor | Mark enemies | Mass over time | 4 |
| Gravemaster | Deploy gravity well | Well potency | 4 |
| Shiftwalker | Swap positions | Disorientation | 4 |
| Overtime Protocol | Overclock buildings | Uptime bonuses | 4 |
| Zoning Commissioner | Create zones | Zone layering | 4 |
| Singularity Prime | Relocate megastructure | Absorption | 4 |

Total: 8 commanders, 32 buildings, 0 units
