---
name: review-workflow-preference
description: Len wants quick conversational code checks while editing; reserve the formal /code-review for a stable pre-PR snapshot
metadata: 
  node_type: memory
  type: feedback
  originSessionId: a35811d0-1111-4c61-a8cd-c2231c2ebbc4
---

While Len is actively editing scripts, he prefers **quick, conversational code checks** — he pastes a snippet or points at a file, and I give focused correctness / bug-proneness feedback inline. He does **not** want the heavyweight `/code-review` workflow run mid-edit.

**Why:** the formal review reads the actual files for context, so running it while he's changing those files yields stale/noisy findings; and a pre-PR review is only meaningful on a stable diff. A lightweight check fits iterative work and doesn't fight his live edits.

**How to apply:** default to reading + commenting in-chat for "is this right / prone to bugs?" asks. Only launch `/code-review` (or the multi-agent workflow) when he says he's at a stopping point or ready for the PR. See [[len-developer-profile]].
