---
name: len-personal-catalog
description: "Len's private catalog/front door at D:\\Projects\\Allen\\Prototypes\\INDEX.md (untracked in a PUBLIC repo — never commit) — add entries only when asked; don't scan or read his personal folder"
metadata:
  node_type: memory
  type: reference
  originSessionId: 0081a3d5-18f3-465a-953f-5a9cc066781c
  modified: 2026-10-30T06:46:37.978Z
---

`D:\Projects\Allen\Prototypes\INDEX.md` is Len's personal catalog: one entry per project or note (title, one-line description, link). Created 2026-10-30. Moved into `Prototypes\` on 2026-10-30 at Len's request. 🚨 `Prototypes` is itself a git repo with a PUBLIC remote (github.com/SoraBladeheart/Prototypes), so INDEX.md and `Journal/` are UNTRACKED on purpose and must never be committed/pushed (never `git add .` there; don't commit or push in that repo unless he asks). Layout: SoraBladeheart (own separate public hub repo, gitignored by Prototypes), FlappyBird, RPG_001, Journal (Work-Journal.md).

**Why:** Len wants one central "town center" that gives general direction to everything he builds in his own time; the folder will keep growing. It is personal (experiments, journal) and he said he'll keep working on it himself.

**Experiment freedom (2026-10-30):** on his PERSONAL files/projects Len said "we can make as many mistakes as we want, it won't cause problems for anyone but me" — so the strict work-repo rule ([[prefer-minimal-diff]]: additive, minimal, removable) is relaxed there; bold experiments and learning-by-breaking are welcome. Guardrails that still hold: `Prototypes` is a PUBLIC repo (no pushing/committing unless asked, nothing confidential from work), keep an undo path (git or a backup copy) for anything he'd be sad to lose, and the work-repo rules stay strict.

**Git permission on personal repos (2026-10-30):** Len said "feel free to commit, push or anything, just give me a heads up." Applies to his PERSONAL repos only (SoraBladeheart, Prototypes) — NOT the work repo the work repo (work rules unchanged: commit/push only when asked, never merge into main). Always give him a heads-up (what was committed/pushed, to which repo/branch). EXCEPTION I keep: before pushing anything from the private set — `INDEX.md`, `Journal/` (Work-Journal, Problem-Log), diary/personal notes, anything work-confidential — to a PUBLIC remote, confirm first; a push there can't be undone (cached/indexed). Prefer adding those to `.gitignore` instead of committing them.

**How to apply:** Add an entry only when he asks, in the right section, matching the existing format (bold linked title + dash + short description). Never scan, read or deep-dive the folder or its journal/personal files unless he asks; shallow name-only listings are fine when he asks for a catalog. Never link personal items from the public SoraBladeheart README. See [[sora-repo-public-and-gi-portability]] and [[parked-design-notes]].
