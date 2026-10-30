---
name: hud-return-from-exploration-bug
description: Diagnosed-not-yet-fixed — HUD stays hidden after returning PlayerBase→Exploration→PlayerBase
metadata: 
  node_type: memory
  type: project
  originSessionId: 42bb39d9-bf72-467f-b0d3-557a4b3a73a7
  modified: 2026-08-23T00:32:50.388Z
---

**Bug (diagnosed 2026-08-23, fix deferred by Len):** going PlayerBase → Map Exploration (single-player) → back to PlayerBase leaves the HUD hidden.

**Root cause:** `ExplorationChapterMediator.Dispose()` (~line 749) calls `_hudSystem.SetState(HudState.ExplorationOverworld)` — it's written for the flow PlayerBase → **Overworld** → Chapter, where the Overworld's own Dispose later restores `HudState.PlayerBase`. But Len's World button goes **PlayerBase → Chapter directly** (no Overworld layer in the stack), so nothing ever restores `PlayerBase`. And `PlayerBaseMediator` only sets `HudState.PlayerBase` in `OnInitialize` (line 112), which does NOT re-run because PlayerBase stays loaded additively *underneath* exploration. Net: HUD stuck in the hidden exploration state.

**Proposed fix:** on the exit-back-to-base path, call `_hudSystem.SetState(HudState.PlayerBase)`. Need to pin the exact exit seam (the back-to-base unload). Small change. `IHudSystem` API: `SetState(HudState)`, `PushHide/PopHide(HudSection)` ref-counted, `StateVersion` token.

Related: [[exploration-transition-architecture]], [[demo-build-config-state]].
