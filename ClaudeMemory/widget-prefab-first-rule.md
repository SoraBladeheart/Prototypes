---
name: widget-prefab-first-rule
description: "Len's UI rule: for any image use ThumbnailWidget, for any label use LabelWidget (planned prefab); build UI from reusable widget prefabs, never raw Image/PText"
metadata:
  node_type: memory
  type: feedback
  originSessionId: 0081a3d5-18f3-465a-953f-5a9cc066781c
  modified: 2026-10-19T06:06:42.258Z
---

When asked to put an **image** on a UI, use a **`ThumbnailWidget`**. When asked to add a **label**, use a **`LabelWidget`** (a prefab Len is planning to build around `PText`; it does NOT exist yet as of 2026-10-19 — check before assuming). Don't drop a raw `Image` or bare `PText` into a screen.

**Why:** Len wants UI built from reusable widget prefabs so one change reaches every screen ("we should have been building up prefabs for everything"). `BaseCardWidget` (image + rarity frame only) is the same idea one layer up: character/gear/skill/item cards compose it and add only their own extras. Fonts are the motivating pain: ~1,300 texts have a font baked into their prefab, so changing `FontConfig` doesn't reach them.

**How to apply:** use nested prefab instances / variants (not copies) for differences; prefer a named TextStyleSheet style over per-instance overrides; keep `BaseCardWidget` limited to image + frame (extras live in each card). Retrofit gradually when touching a screen, not big-bang. Related: [[len-values-code-uniformity]], [[len-leadership-goal]].
