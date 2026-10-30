---
name: fail-fast-surface-issues
description: "Len wants problems to show up immediately (error sprite, Game.Log.Error/Warn) rather than being hidden by silent null guards or fallbacks"
metadata:
  node_type: memory
  type: feedback
  originSessionId: 0081a3d5-18f3-465a-953f-5a9cc066781c
  modified: 2026-10-16T14:37:12.270Z
---

When reviewing or writing UI/widget code, prefer making a problem visible the first time it happens: an error sprite, `Game.Log.Error/Warn<T>()`, or letting an unknown case be loud. Don't add silent `return`s, `?.` chains, or "hide it if empty" fallbacks that mask bad data or a missing prefab state.

**Why:** Len said "if there is an issue, we must see it right away so we can fix it right away" (Oct 2026) while simplifying `BaseCardWidget` (frame + image always shown, empty key now paints the error sprite on purpose) and after a missing `Interactable` state silently did nothing because `SimpleStateComponent.PlayState` ignores unknown state names.

**How to apply:**
- Don't "fix" an empty-key error sprite by hiding the image; flag who passes the empty key instead.
- Prefer a logged error + graceful degrade over a throw inside a refresh method (a throw abandons the rest of the setters and leaves a half-bound card).
- Silent no-op risks to call out: unknown state names in `PlayState`, null configs, empty deeplinks.
- Still surface, don't fix, unless asked — see [[surface-dont-fix]].
- Team-side tension: `main`'s "Battle polish" wanted hide-on-empty (bare frame, never error sprite); Len's `BaseCardWidget` now does the opposite. Worth telling the author.
