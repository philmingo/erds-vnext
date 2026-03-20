# Design System Strategy: ERDS vNext

## 1. Overview & Creative North Star
The Creative North Star for this design system is **"The Intelligent Atelier."** 

Unlike generic enterprise dashboards that rely on rigid grids and clinical white spaces, this system treats data as a craft. It combines the high-level authority of an executive "Editorial" layout with the tactical precision of an operational workspace. We break the "template" look by using intentional white space (defined by our Spacing Scale), soft-mist backgrounds (`#f6fafa`), and a focus on **Tonal Layering** rather than structural lines. The result is a UI that feels calm, curated, and breathable—more like a premium broadsheet than a database.

---

## 2. Colors & Surface Philosophy
The palette is rooted in deep, authoritative teals and greens, balanced by sophisticated neutrals that move away from pure, sterile whites.

### The "No-Line" Rule
To achieve a high-end editorial feel, **1px solid borders are prohibited for sectioning.** Boundaries must be defined through background color shifts. 
- Use `surface` (`#f6fafa`) as your base canvas.
- Define regions using `surface-container-low` (`#f0f4f4`) or `surface-container` (`#ebefef`).
- Visual separation is achieved through the contrast between these tones, never through a stroke.

### Surface Hierarchy & Nesting
Treat the UI as a series of physical layers. We use the Material surface tiers to imply importance:
- **Base Level:** `surface` (The desk).
- **Secondary Work Area:** `surface-container-low` (The blotter).
- **Active Cards/Insights:** `surface-container-lowest` (`#ffffff`) (The paper).
- **Elevated Modals/Popovers:** `surface-bright` with Glassmorphism.

### The Glass & Gradient Rule
Floating elements (tooltips, dropdowns, floating action buttons) should utilize **Glassmorphism**. Use `surface-container-lowest` at 80% opacity with a `16px` backdrop-blur. 
For primary CTAs and high-level KPI backgrounds, use a subtle linear gradient transitioning from `primary` (`#034f42`) to `primary_container` (`#276759`) at a 135-degree angle to provide a "signature" depth that flat color cannot replicate.

---

## 3. Typography
We use a dual-font strategy to balance character with readability.

*   **Display & Headlines (Manrope):** Used for "The News." Large, bold, and authoritative.
    *   *Display-LG/MD:* Reserved for hero numbers or major section headers.
    *   *Headline-SM:* High-level summary titles.
*   **Title & Body (Inter):** Used for "The Data." Neutral, highly legible, and functional.
    *   *Title-MD/SM:* Used for card headers to keep the workspace feeling organized.
    *   *Body-MD:* The workhorse for all table data and descriptive text.
*   **Labels (Inter):** Used for "The Metadata." Small-caps or heavy weights are encouraged for secondary labels to create a distinct hierarchy from body text.

---

## 4. Elevation & Depth
In this system, elevation is a function of light and layering, not artificial outlines.

*   **Tonal Layering:** Most cards should sit on a slightly darker background (e.g., a `#ffffff` card on a `#f0f4f4` surface). This creates a "soft lift."
*   **Ambient Shadows:** When a shadow is necessary for a floating state, it must be "Ambient."
    *   **Value:** `0px 12px 32px`
    *   **Color:** `on-surface` (`#181c1d`) at **4% to 6% opacity**. 
    *   **Logic:** The shadow should feel like a soft glow of depth, not a dark smudge.
*   **The Ghost Border Fallback:** If a border is required for accessibility (e.g., in a high-density table), use `outline-variant` (`#bec9c5`) at **20% opacity**. Never use a 100% opaque border.

---

## 5. Components

### Buttons
*   **Primary:** Solid `primary` gradient with `on-primary` text. Radius: `full`.
*   **Secondary:** `secondary-container` background with `on-secondary-container` text.
*   **Tertiary:** Ghost style. No background/border until hover, using `primary` text.
*   **Interaction:** On hover, primary buttons should shift to `primary_container`.

### Cards & KPI Indicators
*   **Structure:** Use `xl` (1.5rem) or `lg` (1rem) rounding. 
*   **Padding:** Use Spacing `6` (2rem) for generous, executive-level breathing room.
*   **AI Insights:** To highlight intelligent insights, use a subtle `tertiary_fixed` (`#ffdeac`) glow or a thin `tertiary` left-accent bar (4px) to make it "subtly distinct."

### Tables & Lists
*   **The No-Divider Rule:** Forbid the use of horizontal lines between rows. Use alternating row colors (`surface` and `surface-container-low`) or Spacing `2` vertical gaps to separate content.
*   **Headers:** Use `label-md` in `on-surface-variant` for table headers, all-caps with 0.05em tracking for an editorial feel.

### Filters & Chips
*   **Style:** Pill-shaped (`full` roundedness).
*   **State:** Selected chips use `primary_fixed` (`#afefdd`) to feel vibrant but calm.

---

## 6. Do’s and Don’ts

### Do
*   **Do** use asymmetrical layouts. A large KPI card on the left balanced by two smaller insight cards on the right creates visual interest.
*   **Do** use `surface-container-highest` for "active" or "selected" sidebar states.
*   **Do** lean into the "Mist" (`#f6fafa`) background; it reduces eye strain compared to pure white.

### Don’t
*   **Don't** use 1px solid black or dark grey borders. If you feel you need a line, use a background color change instead.
*   **Don't** use "Standard Blue" for links. Use the `primary` teal to maintain the signature identity.
*   **Don't** crowd components. If a card feels full, increase the padding using the Spacing Scale rather than shrinking the text.
*   **Don't** use heavy shadows. If the shadow is visible at first glance, it is too dark. It should be felt, not seen.