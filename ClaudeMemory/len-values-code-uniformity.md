---
name: len-values-code-uniformity
description: "Len deliberately keeps empty scaffold methods + a uniform structure across facades for consistency — don't flag them as dead code or push brevity refactors that break the pattern"
metadata: 
  node_type: memory
  type: feedback
  originSessionId: 42bb39d9-bf72-467f-b0d3-557a4b3a73a7
  modified: 2026-09-16T07:51:17.085Z
---

Len deliberately keeps **empty scaffold methods** (e.g. `SetListeners()`) and a **uniform method structure** across his facades (`OnBind` → `SetListeners()` + `RefreshUI()`, etc.) for CONSISTENCY — even when a method is empty or a field looks redundant. He corrected me (Sep 2026) when I suggested deleting the empty `SetListeners()`: *"keep it, I'm trying to keep uniform code."*

**Why:** uniform structure across files is HIS form of clean code — every facade has the same shape, so it's predictable, easy to navigate, and new ones stamp out identically. He explicitly holds **consistency > brevity**. Deeper reasoning, in his words (Sep 2026): he hates spaghetti / structureless code because *only the author can understand it* — when someone else takes over it costs them extra time to find where things live; a fixed structure "provides direction." His analogy: **sorting trash into designated containers, not throwing it wherever.** This is handover / bus-factor thinking — the same instinct a team lead has ([[len-leadership-goal]]). Don't mistake his structure-first stance for over-engineering; it's a deliberate maintainability philosophy.

**How to apply:** don't flag empty scaffold methods or uniformity-driven redundancy (empty `SetListeners`, a `_data` field that duplicates base `Data`, etc.) as "dead code to remove." When reviewing or refactoring his UI, PRESERVE the uniform facade shape rather than trimming it for brevity. Real bugs / logic errors still get surfaced — this is only about not pushing cosmetic brevity that breaks his pattern.

**Hard style rule (Sep 2026):** **block-bodied methods ONLY — never expression-bodied.** `private void SetState(string state) { View.PlayState(state); }`, never `... => View.PlayState(state);`. Applies to all methods, not just facades. He corrected me when I wrote an expression-bodied helper.

His canonical facade skeleton lives in [[facade-skeleton-structure]].

Related: [[facade-skeleton-structure]], [[surface-dont-fix]], [[prefer-minimal-diff]], [[len-developer-profile]].
