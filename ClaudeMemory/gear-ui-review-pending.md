---
name: gear-ui-review-pending
description: "Gear UI (InventoryGearWidget / GearInfoPopup / GearEquip deeplinks) — review CLOSED, PR merged 2026-08-20; fixes + hardening below kept as reference"
metadata: 
  node_type: memory
  type: project
  originSessionId: 5af93954-0c96-471e-8a0c-2d3ed035ff21
  modified: 2026-08-20T08:16:44.395Z
---

**STATUS (2026-08-20): MERGED & CLOSED.** The GearInfoPopup PR was merged to main (alongside the Hospital popup PR). Everything below is retained as reference for *what* was fixed/hardened — not as open work.

Gear UI review that started on `feature/iteminfopopup_redesign` (after the ItemDetailPopup refactor — see [[iteminfopopup-refactor-state]]). Covered InventoryGearWidget, OpenGearInfoTask, GearInfoPopup, and the GearEquip deeplink tasks.

**Done:** `InventoryGearWidget` → `Widget<InventoryGearData>`; equipped icon uses `hero.IconAddress`; sample classes deleted.

**Previously flagged bugs — VERIFIED RESOLVED (2026-08-11 on `feature/len`), now merged:**
- `GearInfoPopupFacade` SetListeners subscription-storm — FIXED: `SetListeners()` now runs once in `OnBind`, not inside `RefreshUI`.
- `GetItem` wrong-id (passed EquipmentId to an InstanceId param) — FIXED: `RefreshGearInfo()` now calls `GetItem(Data.EquipmentInstance.InstanceId)`.
- Duplicate `[Alias(Deeplinks.OpenGearEquip)]` — RESOLVED: `ShowGearEquipTask.cs` no longer exists; `OpenGearEquipTask` is the SOLE handler and owns the live alias (fired by GearSlotWidget taps, GearCheats). **Do NOT comment its alias off — that would remove the only handler.** (Stale `ShowGearEquipTask` reference lingers in ClaudeContext_Len/_INDEX_CATALOG.md.)

**Hardening applied 2026-08-11:** GearInfoPopup action handlers now read the live `_equipmentInstance` (not the possibly-stale `Data.EquipmentInstance`), each null-guarded; the three async handlers (Upgrade/Promote/Remove) got a shared `_actionInFlight` double-tap guard (set before await, cleared in finally). Open edge surfaced to Len at the time: on a [Poolable] facade, closing mid-await leaves `_actionInFlight` true until the finally runs — a one-line `OnBind` reset would close it. (Unknown whether that reset was added before merge — verify against current code if it matters.)

**Design principle (Len's learning):** *every boundary guards its own concern* — widget checks its own data, deeplink checks existence, facade null-checks its input. The deeplink is a "public door": always validate, you don't control who knocks. (Consistent with the WoundedTroopRow call 2026-08-20: guard runtime states like null data, fail loud on programmer errors like missing prefab refs.)

Related: [[iteminfopopup-refactor-state]], [[surface-dont-fix]], [[len-developer-profile]].
