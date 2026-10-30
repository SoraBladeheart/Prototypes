---
name: prefer-minimal-diff
description: "Len consistently picks the smallest change that fixes the problem; I keep proposing the 'thorough' option and he keeps being right"
metadata: 
  node_type: memory
  type: feedback
  originSessionId: a35811d0-1111-4c61-a8cd-c2231c2ebbc4
  modified: 2026-10-30T06:41:58.158Z
---

Repeated pattern: I recommend the comprehensive/"correct" option, Len picks the surgical one, and his call proves better.

- **NavTabWidget sizes** — I argued for serialized fields ("a designer might want a wider centre tab"); he said make them constants. Right: no drift across five copies, and promoting a const to a field later is one line.
- **`IReadOnlyList` wrapper** — I suggested it defensively; he asked "are there methods that mutate it?" There weren't. Dropped.
- **Addressables merge fix (2026-07-24)** — I recommended regenerating `addressable_group_manifest.json` (the "correct" fix, +327 lines). He fixed the missing comma by hand: 4 lines, fixed the boot, reviewable in seconds. For a hotfix to a broken `main`, that is plainly better.

**Why it matters:** the "correct" fix and the "right" fix diverge when the change has to be reviewed, merged, and trusted quickly. A large diff in a hotfix is a cost, not a bonus. Len weighs review burden and merge risk; I default to completeness.

**How to apply:** when there are two fixes, lead with the smaller one and state what it leaves unfixed, rather than leading with the thorough one. If the larger fix is genuinely necessary, prove *why the small one is insufficient* — don't assume comprehensiveness wins. Separate "fixes the reported problem" from "fixes everything adjacent"; the second is usually a follow-up task, not part of this change. See [[surface-dont-fix]], [[readthrough-cost-awareness]].

## ADD, don't alter — Len's stated way of working (2026-10-30)

Context: the senior owns the real fixes (e.g. the party-panel queue unlock design, see [[party-queue-vs-lineup]]) and said they'll do them later, so Len can't fix root causes himself. Len is still learning, wants to experiment (that's how he learns), but his experiments have caused problems elsewhere.

**Rule:** make changes ADDITIVE, ISOLATED and REMOVABLE.
- If an existing implementation doesn't suit us, write a NEW one beside it and switch ONE call site to it. Leave the old code untouched.
- Removing it later = revert that one line + delete the new piece. No tangled edits.
- Keep the blast radius small: before touching anything, grep who else uses it and tell Len. Do NOT edit shared/Core code (many callers) for a local need — build the local version instead, or ask first.
- Mark workarounds so they're findable and deletable (a short `// TEMP(len): <why, what the senior will replace>` comment), and say plainly "this is a workaround for X".
- Experiments go on a branch / in their own small commit, never mixed with unrelated changes; surface anything that could affect other screens.
- Still: surface, don't fix others' issues; report what's wrong and wait.

**Why:** Len's priority is not breaking other people's work while he's building understanding; a clean, removable change is worth more to him than a "proper" one he can't fully reason about yet.

**Self-check against this rule:** Core `ConditionEvaluator` number-format change (2026-10-29) violated it — a shared file with wide reach; a more isolated version would format at the display layer or add an opt-in token instead.
