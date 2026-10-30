---
name: fui-cache-stale-widget-not-rendering
description: Symptom→cause→fix — Widget.SetData called but OnDisplay never fires (no error) = stale FUI child-widget cache; run FUI Resolve
metadata: 
  node_type: memory
  type: reference
  originSessionId: 42bb39d9-bf72-467f-b0d3-557a4b3a73a7
  modified: 2026-09-16T14:45:33.137Z
---

Diagnostic signature: a child `Widget<T>` whose `SetData(data)` is clearly called (no NRE — the field is wired) but whose `OnDisplay` never fires, so it renders nothing and logs nothing.

WHY: `Widget<TData>.SetData` (Widget.cs) stores `Data`/`HasData` but only calls `OnDisplay` `if (IsInitialized)`. A child widget gets `IsInitialized` from its host's init cascade — `PListItem.NotifyPreBind()` (UIView / TabContent have the analog) → `GetChildWidgets()` → `WidgetUtils.InitWidgets(...)`. `GetChildWidgets()` returns the **serialized `_childWidgets` "FUI Cache"** and only re-scans (`FindDirectWidgets`) when that array is **null** — a stale non-null cache is used as-is. So if you add a child widget to a prefab and don't re-run **FUI Resolve**, the new widget is missing from the cache → never `Init()`ed → `SetData` silently skips `OnDisplay`.

FIX: run **FUI Resolve** on the prefab to rebuild `_childWidgets`. The tell in the console (editor / DEVELOPMENT_BUILD) is `WidgetUtils.ValidateCache` logging `[FUI] Stale widget cache on '<owner>' … Run FUI Resolve on this prefab.` The sibling validator logs `[FUI] Stale injectable cache …` for stale `[IInject]` resolution (same fix) — those fields resolve null/stale until resolved.

First hit: Sep 2026, BattleHeroCardItem — a refactor swapped its individual widgets for a `CharacterCardWidget` but the FUI Cache still held the old set; the card stayed blank in the BattleHud only. Refactors that add/remove prefab widgets are the trigger — see [[main-pull-vfx-churn]] and [[config-field-codegen-churn]] for the same "cache drift after churn" shape. Explain it to Len as a flow trace ([[len-learns-via-flow-traces]]).
