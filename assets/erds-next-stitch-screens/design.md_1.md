# ERDS vNext Design Guide

## Purpose
This document defines the visual and user experience direction for ERDS vNext, the Ministry of Education's next-generation Educational Resource Distribution System. It is intended to guide product, design, and development decisions so the application feels consistent, professional, calm, and easy to use across desktop, tablet, and mobile devices.

This guide draws inspiration from a modern dashboard reference with soft colors, rounded cards, generous spacing, and structured information density. The goal is not to copy the reference literally, but to translate its strengths into a purposeful design language tailored to ERDS.

## Design Goals
ERDS should feel:

- Professional and ministry-ready
- Calm and easy on the eyes during long use
- Data-rich without feeling crowded
- Modern, but not trendy to the point of sacrificing clarity
- Mobile-friendly for quick access and field use
- Trustworthy for operational and leadership decision-making
- Accessible to a wide range of users with different technical comfort levels

## Core Design Principles

### 1. Clarity first
Every screen should make it obvious what the user is looking at, what matters most, and what they can do next.

### 2. Calm over clutter
The interface should avoid visual noise. Use white space, card grouping, and restrained colors to reduce cognitive load.

### 3. Hierarchy before density
ERDS will contain large amounts of data. Information should be layered so users can scan summaries first and drill into details only when needed.

### 4. Operational confidence
Users should feel that the system is stable, accurate, and intentional. The UI should reinforce precision and accountability.

### 5. Mobile-aware, not desktop-shrunk
The mobile experience should be intentionally designed, especially for dashboards, recipient lookup, stock alerts, and receipt confirmation.

### 6. Intelligence with restraint
AI insights should feel helpful and explainable, not noisy or overbearing. Recommendations should support user decisions, not overwhelm them.

## Overall Visual Direction
The design direction for ERDS is:

**Clean executive dashboard meets operational workspace**

This means the application should combine:

- Executive-grade summary dashboards
- Practical workflow screens for day-to-day officers
- Clean, card-based layouts
- Gentle visual tone with strong information hierarchy
- Tables and filters that feel structured rather than heavy

## Look and Feel Summary
ERDS should use:

- Soft neutral or mist backgrounds instead of harsh white
- Rounded cards and panels
- Subtle shadows rather than heavy borders
- A restrained color system with clear semantic meaning
- Plenty of spacing between sections
- Clear headings and readable body text
- Minimal decorative elements

It should avoid:

- Loud gradients across main content areas
- Overly small text
- Dense unbroken tables without filters or grouping
- Too many same-looking cards without priority cues
- Excessive icons, badges, or color noise

## Color System

### Base Palette
Recommended foundation:

- Background: soft mist or pale gray-green
- Surface: warm white or very pale neutral
- Primary: deep teal or green
- Secondary: muted blue
- Accent: soft gold or amber
- Text primary: dark slate
- Text secondary: medium gray
- Divider: very light neutral gray

### Semantic Colors
Use colors consistently by meaning:

- Success: green
- Info: blue
- Warning: amber
- Danger: red
- Neutral: gray

### Color Usage Rules
- Primary color should be used for primary actions, key highlights, selected navigation, and active states.
- Warning and danger colors should be reserved for meaningful conditions such as low stock, anomalies, overdue receipts, and failures.
- Accent colors should guide attention, not dominate the UI.
- Do not rely on color alone to communicate meaning. Always support with text, icons, or labels.

## Typography
Typography should be simple, modern, and highly readable.

### Recommendations
- Sans-serif family with strong readability
- Moderate contrast between headings and body text
- Comfortable line height
- Avoid overly compressed or overly elegant styles

### Suggested Scale
- Page title: large, strong, clear
- Section title: medium-large
- Card title: medium
- Body text: standard readable size
- Helper text: slightly smaller, but still legible
- KPI numbers: large and bold

### Typography Rules
- Use sentence case for most UI labels and headings
- Avoid excessive all-caps except for tiny metadata if necessary
- Keep line lengths reasonable, especially in cards and side panels

## Spacing and Layout Rhythm
Spacing is a core part of the ERDS visual identity.

### Principles
- Use generous padding inside cards
- Keep clear separation between page sections
- Prefer grouped layouts over packed layouts
- Allow breathing room between filters, charts, and tables

### Rhythm
Use consistent spacing values across the app so screens feel related and predictable.

## Border Radius and Elevation

### Border Radius
Use soft rounded corners throughout the application.

Recommended use:
- Cards: medium to large rounding
- Buttons: medium rounding
- Inputs: medium rounding
- Modals: large rounding

### Elevation
- Use subtle shadow for cards and overlays
- Avoid harsh shadows or dramatic depth
- Prefer layered softness over skeuomorphic effects

## Iconography
Icons should be clean, light, and functional.

### Rules
- Use icons to support recognition, not replace labels
- Use a consistent line-icon family
- Keep icon sizes consistent within contexts
- Use icons in navigation, status indicators, filters, and summaries

## App Shell Layout

### Desktop
The standard application shell should include:

- Left sidebar navigation
- Top header with search, notifications, profile, and contextual controls
- Main content area with page title, summary row, filters, and content sections

### Sidebar
The sidebar should:
- Be visually stable and easy to scan
- Use grouped navigation sections where helpful
- Clearly indicate active page
- Support collapsed mode if needed on wider screens

Suggested navigation groups:
- Dashboard
- Inventory
- Distributions
- Projects
- Schools / Institutions
- Reports
- AI Insights
- Alerts
- Administration

### Header
The header should remain simple:
- Global search
- Notifications / alerts
- User profile / role
- Optional quick context such as current term or region

Do not overcrowd the top header with workflow actions.

## Dashboard Design
Dashboards should be informative but never jumbled.

### Dashboard Structure
A typical dashboard should include:
- Page title and context summary
- KPI cards
- Alert and action zone
- Trend and analysis cards
- Recent activity / pending actions
- Drill-down panels or tables

### KPI Cards
Use cards for:
- Total stock on hand
- Pending receipts
- This month's distributions
- Low stock items
- Active projects
- AI forecast summary

### Dashboard Card Rules
- Keep each card focused on one idea
- Use larger numbers for key metrics
- Use small supporting text for explanation
- Avoid too many metrics in a single card
- Make important cards visually distinct through layout or subtle accenting

## Table Design
ERDS will rely heavily on tables. Tables must feel organized and not intimidating.

### Principles
- Always provide filters for large tables
- Use sticky headers when appropriate
- Support sorting and search
- Use row spacing and alignment for readability
- Keep actions compact and consistent

### Responsive Behavior
On smaller screens, complex tables should transform into:
- stacked cards
- expandable list rows
- simplified key-detail layouts

### Table Content Hierarchy
Each row should present:
- primary identifier
- supporting context
- status
- action area

Avoid walls of identical text.

## Filters and Search
Filters should not feel like clutter.

### Pattern
Use one of these patterns depending on the page:
- inline summary filters for simple pages
- slide-over or side-panel filters for dense tables
- collapsible advanced filter sections for reporting

### Rules
- Show the most-used filters first
- Hide advanced filters behind expansion or side panel
- Keep filter labels concise and clear

## Forms and Data Entry
Forms should feel structured and forgiving.

### Guidelines
- Group related fields into sections
- Use section titles for complex forms
- Use helper text only when it adds value
- Mark required fields clearly
- Validate early but politely
- Preserve user progress where possible

### Long Forms
Break long forms into:
- sections
- tabs
- accordion groups
- step-based flows where useful

## Modals, Drawers, and Panels
Use overlays thoughtfully.

### Use Modals For
- simple create/edit forms
- confirmations
- focused review steps

### Use Drawers or Side Panels For
- advanced filtering
- details preview
- activity history
- school resource snapshot quick view

Avoid putting overly long workflows in cramped modals.

## Status and Feedback Patterns
Feedback should be immediate, clear, and respectful.

### System Feedback Types
- Success confirmations
- Inline validation
- Loading states
- Empty states
- Warning states
- Error states

### Empty States
Every empty screen should guide the user with a next step:
- create an item
- adjust filters
- connect data
- check permissions

### Alerts
Alerts should be clearly tiered:
- informational
- warning
- urgent

Avoid showing too many alerts at once.

## AI Experience Design
AI must feel grounded, explainable, and useful.

### AI UI Principles
- Present AI as assistance, not authority
- Explain the reason behind recommendations when possible
- Allow manual override
- Show confidence or rationale carefully
- Keep AI insights visually separate from ordinary transactional data

### AI Card Types
- Forecast cards
- Recommendation cards
- Risk alerts
- Summary narrative cards
- Opportunity callouts

### AI Visual Treatment
AI cards may use a subtle accent band, icon, or label such as:
- AI insight
- Forecast
- Recommendation
- Attention needed

Do not make AI look flashy or gimmicky.

## ERDS-Specific Page Patterns

### 1. Dashboard Home
Purpose:
Provide a clean overview of stock, pending actions, alerts, projects, and intelligence.

Recommended layout:
- top summary row
- alerts strip
- activity + trends row
- projects + AI row
- recent distributions / pending receipts row

### 2. Inventory Page
Purpose:
Allow distributors to monitor stock clearly and take action.

Should include:
- total stock summary
- low stock indicators
- category filters
- stock list/table
- stock movement history
- threshold settings entry points

### 3. Distributions Page
Purpose:
Support creation, review, approval, and tracking of distributions.

Should include:
- summary cards
- filterable list/table
- status chips
- quick actions
- detailed side panel or detail page

### 4. School Resource Snapshot
Purpose:
Give project managers and distribution teams a clear view of what a school already has.

Should show:
- current resource counts
- recent distributions
- ownership by teacher/student/school
- age/lifecycle status
- sufficiency score
- duplicate distribution risk
- AI recommendation summary

This screen is critical and should be especially clean and readable.

### 5. Projects / Pilot Programs
Purpose:
Help managers plan targeted distributions without blind spots.

Should show:
- project metadata
- target schools
- existing resources in those schools
- recommended quantities
- duplication warnings
- projected gaps

### 6. Recipient Lookup
Purpose:
Allow teachers, staff, and students to verify received resources using EMIS ID and DOB.

Design requirements:
- minimal, clean, public-facing interface
- strong trust cues
- simple form flow
- clear privacy wording
- readable results cards

This page should feel calmer and more minimal than the internal application.

### 7. Alerts Center
Purpose:
Give users a focused list of stock alerts, pending confirmations, anomalies, and AI warnings.

Should support:
- alert type filtering
- urgency markers
- date and location context
- action buttons

## Role-Based UX Guidance
Different users should not all see the same density and emphasis.

### Leadership / Minister / Directors
Need:
- high-level summaries
- trends
- impact indicators
- project status
- regional comparisons
- AI insights

Should see:
- more charts and summaries
- less transactional clutter

### Distribution Officers / Inventory Managers
Need:
- stock visibility
- pending actions
- transaction lists
- thresholds
- approvals

Should see:
- more tables, filters, and action controls

### Project Managers
Need:
- target school visibility
- existing resource picture
- duplication warnings
- sufficiency insights
- planning tools

### Public Recipients
Need:
- simple lookup
- clear result history
- no unnecessary complexity

## Mobile and Responsive Design
ERDS must be genuinely usable on mobile for selected workflows.

### Mobile Priorities
Mobile should strongly support:
- dashboard summaries
- recipient lookup
- alerts review
- receipt confirmation
- school snapshot quick view
- project summary checks

### Mobile Layout Rules
- sidebar becomes drawer
- cards stack vertically
- filters move into bottom sheet or slide-over
- wide tables become cards or expandable rows
- important actions remain easy to reach
- charts simplify rather than merely shrink

### Tablet Behavior
Tablet should preserve the sense of structure while reducing multi-column density.

## Accessibility Guidelines
The application should be accessible to a broad set of users.

### Requirements
- sufficient color contrast
- visible focus states
- readable type sizes
- keyboard navigability where appropriate
- semantic labels for screen readers
- errors explained clearly

### Avoid
- conveying status by color alone
- low-contrast helper text
- overly small clickable targets

## Interaction Tone
The product voice should be:
- clear
- respectful
- calm
- helpful
- non-technical where possible

Examples:
- “No distributions found for the selected period.”
- “This school may already have sufficient tablets based on recent distributions.”
- “Low stock alert triggered for Mathematics Textbook Grade 6.”

Avoid robotic or overly technical error phrasing unless needed.

## Recommended Component Set
The front end should standardize reusable components such as:

- AppShell
- SideNav
- PageHeader
- StatCard
- AlertCard
- InsightCard
- DataTable
- FilterPanel
- SummaryPanel
- TrendChartCard
- ActivityTimeline
- ResourceSnapshotCard
- SufficiencyIndicator
- AIRecommendationCard
- EmptyStatePanel
- PublicLookupForm

## Design Do and Do Not

### Do
- Keep screens structured and breathable
- Use cards and grouped panels for complex information
- Use consistent spacing and component patterns
- Make high-priority information visible early
- Support deep workflows without overwhelming first glance

### Do Not
- Overload dashboards with too many equally weighted widgets
- Use too many accent colors on one screen
- Shrink dense tables onto mobile unchanged
- Hide important operational warnings inside tertiary tabs
- Make AI features visually louder than core workflow controls

## Suggested Design Keywords
These keywords should guide design choices:

- Calm
- Trustworthy
- Structured
- Modern
- Operational
- Intelligent
- Readable
- Measured
- Professional
- Insightful

## Final Direction
ERDS should visually communicate that it is:

- a serious national operational system
- a modern and user-friendly platform
- a trustworthy source of visibility and accountability
- an intelligent planning tool, not just a tracking database

The design should feel polished and contemporary, while remaining restrained, accessible, and practical for real Ministry workflows.
