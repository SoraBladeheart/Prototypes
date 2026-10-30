---
name: rpg-ff-style-project
description: "Len's RPG2.0 — top-down 2D Unity 6 JRPG inspired by Final Fantasy 1–7; movement cleaned to Idle/Walk/Run; monorepo \"Prototypes\" plan in progress (folders being renamed 2026-09-23)"
metadata:
  node_type: memory
  type: project
  originSessionId: a76c5369-3eaf-457b-9ebd-b57c9cb6a26a
  modified: 2026-09-22T21:29:43.666Z
---

**RPG2.0** (was at `D:/Projects/Allen/RPG2.0`; Len is RENAMING folders 2026-09-23, so re-check the path) — Unity 6000.3.10f1, 2D URP, new Input System, **top-down** (Rigidbody2D gravity 0). Goal: a game like **Final Fantasy 1–7** (field exploration + random encounters + separate turn-based battle scene).

**State (2026-09-23):** Len himself stripped the player scripts (PlayerInput/Controller/Movement/AnimatorController/State) down to **Idle/Walk/Run**; input actions = Move, Run (LShift), Interact (E, not yet used). Tested working. Fixed the "slides forever after walking down" bug (removed gravity-style Fall/Landing checks). `linearVelocity` rename done (in first commit). Leftover: Run/Interact have no gamepad bindings.

**Naming convention (Len's pick):** type + zero-padded number, PascalCase-ish with underscores — RPG2.0 → **`RPG_01`** (renaming after a PC restart); real titles go in Player → Product Name, not the folder.

**Encounters Part A DONE (2026-09-23, commit ab282db):** Len wrote `Assets/Scripts/Encounters/EncounterCounter.cs` (distance → steps, random target min/max ints + Random.Range max+1, `>=` check, Debug.Log "Battle!"), on Player. Notes doc at `RPG_001/Docs/RandomEncounters.md` (outline only; Len to fill in own words). **NEXT = Part B:** replace the log with opening a battle scene.

**Next milestone** ("one walk, one fight"): step counter → random encounter → 1 hero vs 1 slime, turn-based (Attack/Run) → XP → back to map. Suggested classic turn-based (FF1–3) before ATB; Len hasn't chosen yet.

**GIT DONE (2026-09-23):** repo root `D:/Projects/Allen/Prototypes` (contains FlappyBird/, RPG_001/, and SoraBladeheart/ which is gitignored as a separate repo) → pushed to github.com/SoraBladeheart/Prototypes on `main` (first commit 3c574c2, 224 files). Repo-local user.name = SoraBladeheart (global is the work login — keep it off public commits). GitHub account on this PC = SoraBladeheart. Len uses Sourcetree too (username set to SoraBladeheart). Old Prototype_FlappyBird repo archived (Len, 2026-09-23).

**Original git plan (Option A, Len's choice over separate repos):** one GitHub repo `Prototypes`, root = the parent folder (`D:/Projects/Allen`) holding FlappyBird + RPG2.0 as subfolders. Steps: delete FlappyBird/.git (history stays in old repo → archive `Prototype_FlappyBird`), move its .gitignore to root and prefix root-anchored `/` patterns with `**`, add `SoraBladeheart/` to ignore (separate PUBLIC repo), dry-run check no `Library/` staged. Open questions: public vs private.

**How Len works here:** wants to do edits HIMSELF — I guide step by step and then verify files after. See [[len-developer-profile]], [[prototypeone-flappybird]], [[surface-dont-fix]].
