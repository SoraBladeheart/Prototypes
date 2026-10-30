---
name: prototypeone-flappybird
description: "Len's first small game — a complete Flappy Bird clone (Unity 6, D:/Projects/PrototypeOne/Prototype); on GitHub, pending WebGL + itch + SoraBladeheart link"
metadata: 
  node_type: memory
  type: project
  originSessionId: 5af93954-0c96-471e-8a0c-2d3ed035ff21
  modified: 2026-08-07T15:51:19.741Z
---

Len's first solo small game, built in one evening (2026-08-07) as his after-work **dev block** — a complete, working **Flappy Bird clone** in Unity 6 (2D URP, new Input System). Part of the "make small games → Sora Bladeheart portfolio" want (see [[self-improvement-program]]).

**Location:** `D:/Projects/PrototypeOne/Prototype` (Unity project root = git repo root).
**GitHub:** https://github.com/SoraBladeheart/Prototype_FlappyBird — pushed to `main`. (Underscore name, not the `()` Len first wanted — GitHub rejects parentheses.)

**What it has:** bird (hover-until-first-tap via gravityScale 0→restore; flap on space/Pointer), pipe prefab + PipeSpawner (random gap height, first pipe immediate), a **GameManager singleton** (start / game-over / restart state + score), `OnCollisionEnter2D` death (solid pipes + ground), ScoreZone trigger (+1 per gap passed), live HUD score + game-over score board (TMP), Play Again + Quit buttons. Scripts in `Assets/Scripts` (Bird, PipeMover, PipeSpawner, GameManager, ScoreZone). **Len wrote big chunks himself** — the whole score system, the quit buttons, the HUD/game-over UI split.

**How we worked:** I write scripts to disk, Len does the Unity Editor wiring; he also edits files live (concurrent — the write-guard bounced a couple of my writes, which is fine and correct). See [[concurrent-editing-protocol]].

**Pending (2026-08-08+):** Len made a **Windows** standalone build (works; Quit works in standalone). For the portfolio "click-a-link-and-play" goal he still needs a **WebGL** build — enable **Player → Publishing Settings → Decompression Fallback** so it runs on static hosts. Plan: host on **itch.io** (Windows as a download + WebGL "run in browser" on the same page), then add **both links (▶ Play + source) into the SoraBladeheart repo README**. Unity `.gitignore` already committed.

Unity-6 gotchas taught this session (reusable): `Rigidbody2D.linearVelocity` (not `.velocity`); new Input System low-level reads (`Keyboard.current` / `Pointer.current`); changing a script's default field value does NOT update already-serialized component instances (edit in Inspector); `Application.Quit()` is a no-op in the Editor and in WebGL.

Related: [[self-improvement-program]], [[len-developer-profile]], [[concurrent-editing-protocol]].
