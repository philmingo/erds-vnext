

Let me read all the guide files as instructed by the master prompt. 

Read [](file:///c%3A/projects/erds_vNext)

Read [](file:///c%3A/projects/erds_vNext/guides)

Read [](file:///c%3A/projects/erds_vNext/assets)

Reading all three guide files in parallel: 

Read [](file:///c%3A/projects/erds_vNext/guides/plans.md#1-1), lines 1 to 300

Read [](file:///c%3A/projects/erds_vNext/guides/plans.md#300-300), lines 300 to 465

Read [](file:///c%3A/projects/erds_vNext/guides/design.md#1-1), lines 1 to 300

Read [](file:///c%3A/projects/erds_vNext/guides/design.md#300-300), lines 300 to 500

Read [](file:///c%3A/projects/erds_vNext/guides/design.md#500-500), lines 500 to 588

Now reading the process guide: 

Read [](file:///c%3A/projects/erds_vNext/guides/product_and_engineering_process_guide.md#1-1), lines 1 to 300

Read [](file:///c%3A/projects/erds_vNext/guides/product_and_engineering_process_guide.md#300-300), lines 300 to 367

Now let me check what prototype screens exist: 

Read [](file:///c%3A/projects/erds_vNext/assets/erds-next-stitch-screens)

Read [](file:///c%3A/projects/erds_vNext/assets/erds-next-stitch-screens/stitch)

All guides and assets reviewed. Here is my summary and proposal:

---

## Summary of Guide Files

### plans.md — WHAT to build
- **System**: National educational resource distribution platform (Guyana MOE)
- **Stack**: .NET 10 API + React/Vite frontend + PostgreSQL (Supabase) + Azure AD auth + SendGrid email
- **Core domain**: Organizations (synced from EMIS) → Inventory (items, categories, stock ledger) → Distribution workflow (create/approve/issue/receive) → Projects/Programs → Resource Intelligence → AI
- **Data ownership**: OpenEMIS owns master education data (schools, students, teachers); ERDS owns items, stock, distributions, permissions
- **10 implementation phases** from Foundation through Hardening/Rollout
- **Key architectural decisions**: EMIS-first master data, stock transaction ledger model, clean architecture, OpenAPI-first contracts, AI assists but never controls

### design.md — HOW it should look and behave
- **Visual direction**: "Clean executive dashboard meets operational workspace" — soft mist backgrounds, rounded cards, subtle shadows, deep teal/green primary, generous spacing
- **Principles**: Clarity first, calm over clutter, hierarchy before density, operational confidence, mobile-aware, intelligence with restraint
- **Component set**: AppShell, SideNav, PageHeader, StatCard, AlertCard, DataTable, FilterPanel, AIRecommendationCard, PublicLookupForm, etc.
- **Role-based UX**: Leadership sees summaries/charts; officers see tables/actions; public sees minimal calm lookup
- **AI design**: Present as assistance not authority, explainable, visually distinct but not flashy
- **Mobile**: Dashboard summaries, recipient lookup, alerts, receipt confirmation must work well on mobile

### product_and_engineering_process_guide.md — HOW development must be done
- **Vertical slice delivery**: Every feature must ship with business logic + UI + API + validation + permissions + audit + tests
- **Feature lifecycle**: Define → Design → Deliver (with sub-phases: Business Definition → Process Mapping → UI Draft → API Contract → Backend → Frontend → Testing → Sign-off)
- **Build order** (Milestones 0-8): Foundation → EMIS Integration → Inventory → Distribution → Visibility → Projects → Alerts → Public Access → AI
- **13 development rules**: No UI without process, no API without purpose, no feature without permissions/audit, no partial features
- **Definition of Done**: Backend + frontend + API integration + permissions + audit + edge cases + mobile + stakeholder approval

---

## Next Logical Module: Milestone 0 — Foundation

Per the process guide's build order and the plan's Phase 2, the codebase is currently empty (only guide docs and a .gitignore). The next logical step is **Milestone 0: Foundation** — setting up the technical skeleton that everything else depends on.

---

## Proposed Milestone 0 Breakdown into Features

Following the vertical-slice discipline, each feature below includes backend + frontend + integration as appropriate:

| # | Feature | Scope |
|---|---------|-------|
| **0.1** | **.NET Solution Scaffold** | Create the `ERDS.sln` with all projects: Api, Application, Domain, Infrastructure, Contracts, Shared. Wire up DI, middleware pipeline, Serilog, health checks. Swagger/OpenAPI configured. |
| **0.2** | **React App Scaffold** | Create `erds-web` via Vite + TypeScript. Install core dependencies (TanStack Query, React Hook Form, Zod, Zustand, MUI). Set up project folder structure (api/, auth/, components/, features/, hooks/, store/, types/, utils/). |
| **0.3** | **Design System Foundation** | Implement the MUI theme (color palette, typography scale, spacing rhythm, border radius, elevation) per design.md. Build the `AppShell` (sidebar nav, top header, main content area). Build `PageHeader`, `StatCard`, `EmptyStatePanel` base components. |
| **0.4** | **Azure AD Authentication** | Backend: Configure Microsoft.Identity.Web with JWT bearer. Frontend: Configure MSAL React, auth context, protected routes. Verify: login → acquire token → call API → return 200/401. |
| **0.5** | **Database Connection & Migration Pipeline** | Configure EF Core 10 with Npgsql (Supabase PostgreSQL). Create `ErdsDbContext`. Set up migration infrastructure. Create and run initial migration (empty schema baseline). |
| **0.6** | **Authorization & Permissions Skeleton** | Domain: `User`, `Role`, `Permission`, `UserRestriction` entities. Backend: permission-based authorization policies, `ICurrentUserService`. Frontend: auth-aware route guards, permission context. API: `/api/v1/admin/me` endpoint returning current user + permissions. |
| **0.7** | **Audit Logging Infrastructure** | Domain: `AuditLog` entity. Infrastructure: automatic audit interceptor on `SaveChanges`. API: audit entries written on every state change. This is foundational — every subsequent feature writes audit entries. |
| **0.8** | **OpenAPI Codegen Pipeline** | Configure NSwag or Kiota to generate TypeScript API clients from the .NET OpenAPI spec. Validate: generated client can call the `/api/v1/admin/me` endpoint from React. |

### Dependencies
```
0.1 ──┬── 0.4 (auth needs API project)
      ├── 0.5 (DB needs Infrastructure project)
      └── 0.8 (codegen needs OpenAPI from API)
0.2 ──┬── 0.3 (design system needs React app)
      ├── 0.4 (MSAL needs React app)
      └── 0.8 (codegen needs React app)
0.5 ──── 0.6 (permissions need DB)
0.6 ──── 0.7 (audit needs user context from permissions)
```

### Optimal build sequence
1. **0.1** + **0.2** (parallel — independent scaffolds)
2. **0.3** + **0.5** (parallel — design system + database)
3. **0.4** (auth wires both sides together)
4. **0.6** (permissions skeleton)
5. **0.7** (audit infrastructure)
6. **0.8** (OpenAPI codegen pipeline — validates full roundtrip)

### Milestone 0 Definition of Done
- .NET API starts, responds to health check, serves OpenAPI spec
- React app starts, renders AppShell with sidebar navigation
- Azure AD login works end-to-end (React → token → API → 200)
- EF Core connects to Supabase, migrations run cleanly
- Permission check works (`/api/v1/admin/me` returns user + roles)
- Audit log writes on entity changes
- Generated TypeScript client successfully calls the API from React
- MUI theme matches design.md (palette, spacing, typography, border radius)

---

**Ready to proceed with Feature 0.1 (.NET Solution Scaffold), or would you like to adjust the breakdown first?**