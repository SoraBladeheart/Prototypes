---
name: empirical-over-doc-contract
description: "When Len reports a behavior as working in the editor, that outranks my doc/contract-derived reasoning — verify before proposing a restructure"
metadata: 
  node_type: memory
  type: feedback
  originSessionId: a35811d0-1111-4c61-a8cd-c2231c2ebbc4
  modified: 2026-07-21T11:40:25.256Z
---

On the FacilityDetailsPopup scroll work I read the `PVirtualizedList` header contract, found Len's prefab structure violated it, and produced a confident 4-step "fix" — including a `drivenByObject: Content` "smoking gun" and a "15px column offset". Len had already tested the contract-compliant structure; it misbehaved, so he'd deviated deliberately. His structure worked. **Both of my headline findings were wrong**: the 15px was compensated by `List.anchoredPosition.x = 15`, and the VerticalLayoutGroup only stomps the header on a *layout rebuild*, which doesn't fire during a plain scroll.

**Why:** I reasoned from a static config dump plus a source contract and never asked the one cheap question — *"does it currently work?"* A config that violates a documented contract is a hypothesis, not a defect.

**How to apply:** before proposing any restructure, ask what the current behavior actually is. State confidence honestly — "this violates the documented contract, which *may* explain X" — not "this is the root cause." When Len says something behaves correctly, treat that as ground truth and reconcile my model to it. If I still think there's a latent risk, give him a **falsifiable test** to run rather than a restructure to perform. See [[facility-details-header-structure]], [[concurrent-editing-protocol]].
