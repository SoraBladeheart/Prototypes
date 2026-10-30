---
name: feedback-log-solved-problems
description: "After solving a problem Len asked help with, append a plain-words entry (problem + solution) to his private Problem-Log.md — never commit/push it"
metadata:
  node_type: memory
  type: feedback
  originSessionId: 0081a3d5-18f3-465a-953f-5a9cc066781c
  modified: 2026-10-30T06:50:47.354Z
---

When Len gets stuck while working, asks me for help, and we reach a solution, I append one entry to `D:\Projects\Allen\Prototypes\Journal\Problem-Log.md` (his personal log; newest entry first, under the marker comment at the top). Set up 2026-10-30.

Entry format: date, tag (unity/csharp/git/prefab/ui/build/tools/other), a one-line title, then **Problem** (what went wrong, what he saw), **Cause** (why, if known), **Solution** (what fixed it), and **Lesson** (one line he can reuse).

**Why:** Len wants a personal reference of problems he hit and how they were solved, so he can look back instead of re-asking, and so he grows as a developer.

**How to apply:**
- Write the entry once the problem is actually solved/verified — not while still guessing. If it's unclear whether it's solved, ask.
- Only for problems he asked help on; not for every task.
- 🚨 The file lives inside `Prototypes`, a PUBLIC git repo (untracked on purpose). Len's rule (2026-10-30): only IDEAS and PROBLEMS, nothing company-related. General terms are fine, and so are bare class/method names like `BuildingUpgradePopupFacade` ("it doesn't really mean anything"). NEVER write the project/company name (the work repo / the studio), secrets, keys, internal URLs, or pasted blocks of company code. If a problem is too company-specific, describe the kind of problem generically or ask first.
- Never stage, commit or push anything in `Prototypes` unless he asks. A work session writing outside its folder may prompt for permission — that's expected.
- Keep to his working agreements: tell him briefly what I added; he can edit or delete any entry.
See [[len-personal-catalog]], [[surface-dont-fix]].
