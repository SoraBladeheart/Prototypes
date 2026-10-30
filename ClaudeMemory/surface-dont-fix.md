---
name: surface-dont-fix
description: "When reviewing or working nearby, REPORT irregularities to Len rather than fixing them — he decides, then tells me to act"
metadata: 
  node_type: memory
  type: feedback
  originSessionId: a35811d0-1111-4c61-a8cd-c2231c2ebbc4
  modified: 2026-07-22T13:31:38.418Z
---

Len's explicit working agreement (2026-07-22):

> "when you see irregularities or possible mistakes, inform me... so I can review and let you know what's up"

**Why:** during a HUD review I flagged two unused `ADDRESSABLE_KEY_*` constants **and** rewrote the call sites to use them. They were deliberate placeholders — the intended art isn't authored yet, so "fixing" them would have made two buttons render nothing. The observation was correct; taking the decision was not. Same shape as three other times that day: I treated "looks wrong" as "is wrong" without asking whether it was chosen.

**The distinction that matters:** flagging is the job, changing is a different act. A reviewer says *"these two are unused — intentional?"*. A reviewer does not rewrite the call sites and report it afterwards. The author has context the reviewer doesn't.

**How to apply:**
- **Asked to fix X** → fix X, and only X.
- **Noticed Y while doing X** → report Y with the evidence and what I'd suggest. Wait.
- The test: *did he ask me to change this specific thing?* If no, it's a finding, not a task.
- Applies hardest to anything that looks like an oversight — unused constants, mismatched values, dead-looking code, "wrong" config. A mismatch that survived someone's attention is more likely intentional than accidental.
- Does NOT mean withholding findings. Report everything; just don't act unilaterally.

See [[empirical-over-doc-contract]], [[len-inherits-handover-work]], [[concurrent-editing-protocol]].
