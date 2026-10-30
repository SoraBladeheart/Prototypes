---
name: minimize-script-changes-prefer-config
description: "DURING A RUSH/crunch, prefer config (JSON) edits over C# edits to dodge rebuild time — not a permanent rule; the mechanism (a .cs change = full recompile + domain reload) is always true"
metadata: 
  node_type: memory
  type: feedback
  originSessionId: 42bb39d9-bf72-467f-b0d3-557a4b3a73a7
  modified: 2026-09-02T14:34:05.231Z
---

**Always-true mechanism (reference):** editing any `.cs` file makes Unity recompile the affected assemblies + do a **domain reload** — a slow full rebuild that drops Play mode and resets the MCP bridge. (This session the bridge kept disconnecting precisely because I was editing camera/build/facade code; every save re-triggered it.) Config JSON under `Assets/Configs/GameConfig/*.json` is a data asset: editing it is a single fast reimport, read **live on the next Play**, no recompile. Only a device build needs the compiled `MegaConfig.bytes`, which the build regenerates automatically.

**The preference is situational, NOT permanent.** Len asked to minimise script changes **because they were in a rush** (Sep 2026) and rebuilds were eating the loop. So: while under time pressure, prefer config-only changes, defer/batch any needed `.cs` edits into a single recompile, and inspect state via MCP reads (which don't recompile) rather than live C# tweaks. **When not rushed, normal engineering resumes** — make the right script change when it's warranted; don't contort a design into config to avoid a recompile.

Related: [[main-pull-vfx-churn]], [[demo-build-config-state]], [[readthrough-cost-awareness]], [[mcp-for-unity-setup]].
