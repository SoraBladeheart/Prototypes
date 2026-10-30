---
name: concurrent-editing-protocol
description: "Len edits files live in his IDE while I edit them too; re-read before writing, one owner per file per task"
metadata: 
  node_type: memory
  type: feedback
  originSessionId: a35811d0-1111-4c61-a8cd-c2231c2ebbc4
---

Len works in his own IDE and often edits the SAME files I'm editing, live, mid-session (prefab wiring, view [IInject] fields, button handlers). This caused repeated "file modified since read" errors and near-clobbers during the party-panel work.

**Why:** He's hands-on and learning — he wants to do his share, so he'll jump into a file while I'm mid-change rather than wait.

**How to apply:** Re-read a file immediately before every Write/Edit if there's any chance he touched it since my last read. For non-trivial work, agree an explicit owner per file up front ("I take the facade, you take the view + prefab") so we don't overwrite each other. Always prefer targeted Edits over full-file rewrites. See [[len-developer-profile]].
