---
name: len-inherits-handover-work
description: "Len's standard: authorship is irrelevant, only whether the code works and is done properly — provenance is a diagnostic hint, never a verdict"
metadata: 
  node_type: memory
  type: feedback
  originSessionId: a35811d0-1111-4c61-a8cd-c2231c2ebbc4
  modified: 2026-07-21T14:48:04.841Z
---

Len takes over unfinished features from other developers (`FacilityDetailsPopup`, rebuilt July 2026, came from another dev's partial work — the zero-scaled Viewport, redundant `ListSection` wrapper, `StatType.ToString()` headers and `FlatValue`-only cells were all inherited).

When I framed those as "someone else's leftovers", he corrected me:

> "it doesn't matter who did it first, the concern is if it is working or done properly. If not, we fix it."

**Why it matters:** provenance has exactly one legitimate use — it tells you whether a strange config is *more likely* an accident than a deliberate workaround, which changes how you diagnose. It is never an explanation for why something is broken, a reason to soften a finding, or a way to apportion blame. I let it slide from the first use toward the second, and he pulled it back.

**How to apply:** ask "did you write this, or did it come with the feature?" purely to calibrate whether odd code is intent or accident — then judge it on the same bar either way: does it work, is it done properly, and if not we fix it. Never present a defect as inherited-and-therefore-excusable. Treat inherited structure as a hypothesis, not a constraint (he correctly binned the `ListSection` wrapper and the `_headerRow` link). See [[empirical-over-doc-contract]], [[facility-details-header-structure]], [[len-leadership-goal]].
