---
name: work-pc-constraints-and-gi-voice
description: "Len's WORK PC forbids installing non-work software; Gi's read-aloud voice is built from Windows-only tools (Zira TTS via a Stop hook) to comply"
metadata: 
  node_type: memory
  type: project
  originSessionId: 5af93954-0c96-471e-8a0c-2d3ed035ff21
  modified: 2026-08-10T07:22:01.739Z
---

**Work-PC constraint (standing, important):** Len uses a **work computer** in the office where he **cannot install any non-work-related software** (corporate IT policy). Any tool suggestion for that machine must use **what already ships with Windows** (PowerShell, System.Speech, built-in voices) or a pure web/API path — never "install X." Install-required tools (VOICEVOX, Open-LLM-VTuber, SillyTavern, standalone apps) are a **personal-machine, someday** thing. Also avoid piping our conversation to an external server (e.g. ElevenLabs API) on the work PC — prefer fully on-device.

**Gi read-aloud voice (built 2026-08-10):** Gi now speaks her replies aloud, zero-install, fully on-device:
- `C:\Users\Allen\.claude\Gi-speak.ps1` — reads the Stop-hook JSON from stdin, pulls the last assistant TEXT block from the transcript (skips tool-call-only entries), strips markdown/links/emoji, caps at 1200 chars, speaks it with the built-in **Microsoft Zira Desktop** voice (System.Speech).
- Wired as an **async `Stop` hook** in `C:\Users\Allen\.claude\settings.json` (user/global → every project). Command: `powershell.exe -NoProfile -ExecutionPolicy Bypass -File '.../Gi-speak.ps1'`.
- **STATUS (2026-08-10): the hook block is currently REMOVED from settings.json — held during WORK hours so Gi doesn't speak at Len's office desk.** The script stays in place; to activate, re-add the Stop-hook block above and reload via `/hooks` (or restart). Len wants to resume/tune this **after work hours**.
- **Tuning knobs (in the script):** `SelectVoice`, `Rate`, `Volume`, the 1200-char cap. **Disable** by removing the Stop hook (or via `/hooks`). Activating a settings change needs `/hooks` or a Claude Code restart.
- **Step-2 wishlist (personal machine only):** cuter voices — VOICEVOX (free/local/adorable but Japanese-focused → great for a *Japanese-speaking* Gi) or ElevenLabs (natural English, external API). Windows 11 "natural" voices via Settings *might* be allowed on the work PC.

Len is a determined beginner here ("not an expert or genius… but determined") — guide step by step, zero assumed knowledge, celebrate small wins. Related: [[len-developer-profile]], [[len-wellbeing-crisis-care]].
