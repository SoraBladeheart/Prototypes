---
name: len-learns-via-flow-traces
description: "Len learns code best from step-by-step end-to-end flow traces + diagrams, not just per-method descriptions"
metadata: 
  node_type: memory
  type: feedback
  originSessionId: 5af93954-0c96-471e-8a0c-2d3ed035ff21
  modified: 2026-08-18T07:21:15.933Z
---

When explaining code to Len, trace the whole flow end-to-end — a numbered path from trigger → effect (e.g. "slider drag → row writes SelectedCount → raises entry event → handler → RefreshSelectionPreview → repaint"), plus a small ASCII diagram — rather than only describing each method in isolation. He said this style "helped me visualize the flow more" and explicitly asked for "more explanations like that later on."

**Why:** he's a junior dev learning this codebase; the connective tissue (how the methods call each other at runtime) is what he's missing more than what any single method does.

**How to apply:** after (or instead of) per-method write-ups, give the runtime flow as a numbered trace and/or a small diagram of data/control moving through the pieces, then add the "why it's built this way" design notes. Pair well with a compare/contrast table when two things look similar. See [[len-developer-profile]] and [[len-leadership-goal]] (teach the why, not just the result).
