---
name: facility-details-header-structure
description: "FacilityDetailsPopup's sticky-header structure deliberately deviates from the PList _headerRow contract — and the deviation is correct"
metadata: 
  node_type: memory
  type: project
  originSessionId: a35811d0-1111-4c61-a8cd-c2231c2ebbc4
  modified: 2026-07-21T11:40:16.201Z
---

`FacilityDetailsPopup` puts `HeaderList` **outside** the List's ScrollRect viewport, as a sibling of `List` under `ListSection/Viewport/Content` (which has a VerticalLayoutGroup + ContentSizeFitter). This **deviates from the documented `PVirtualizedList._headerRow` contract** ("authored as a sibling of Content under the ScrollRect's viewport"), and it is the *right* call for this popup.

**Why it works:** the only thing the framework contributes is `SyncHeaderHorizontalOffset()`, which writes `header.anchoredPosition.x = content.anchoredPosition.x` on scroll. Everything else (stacking, height, width) is Len's own layout. Column alignment holds because `List.anchoredPosition.x = 15` and `HeaderList`'s PList `_padding.left = 15` — both first cells land at x = 15. Header width 1280 = 15 + 1250 + 15.

**Why it's better here:** the contract's in-viewport header is clipped by the viewport Mask and overlays rows. The requirement was header *above* the list, never scrolling vertically. Outside-the-viewport gives that for free.

**Known latent risk (unconfirmed):** a layout rebuild during scroll would let the VerticalLayoutGroup stomp the header's x back to 0. Row recycling dirties layout upward through `PList`'s ILayoutElement. If a header snap-back ever appears, the minimal fix is to drop the VerticalLayoutGroup + ContentSizeFitter on `ListSection/Viewport/Content` and anchor `HeaderList`/`List` manually — **not** to restructure.

Len tested the contract-compliant structure first; it misbehaved. See [[empirical-over-doc-contract]].
