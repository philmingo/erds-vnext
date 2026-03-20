# Plan: ERDS vNext — Full Application Build

## TL;DR
Build a greenfield Educational Resource Distribution System (ERDS vNext) for the Ministry of Education (Guyana) using .NET 10 + React + PostgreSQL (Supabase). The system manages nationwide distribution of educational resources (textbooks, devices, furniture, consumables, etc.) across departments, regions, schools, teachers, and students. It integrates with OpenEMIS as the master data source, provides AI-powered forecasting and decision support, supports project-based distribution planning, and offers public recipient self-service lookup.

---

## Architecture Overview

- **Frontend**: React 19+ / TypeScript / Vite / TanStack Query / React Hook Form + Zod / MUI or Ant Design / MSAL React / Recharts
- **Backend**: ASP.NET Core 10 Web API / EF Core 10 / MediatR (CQRS) / FluentValidation / Serilog / Hangfire / SignalR
- **Database**: PostgreSQL on Supabase
- **Auth**: Azure AD (Entra ID) — OpenID Connect frontend, JWT bearer backend, Microsoft.Identity.Web
- **Email**: SendGrid (backend-only, via background jobs)
- **Integration**: OpenEMIS Core v5 API + Webhooks
- **AI**: ML.NET / Python microservices / Azure OpenAI (phased)

## Solution Structure

```
ERDS.sln
├── src/
│   ├── ERDS.Api                        // ASP.NET Core entry point, controllers, middleware
│   ├── ERDS.Application                // Use cases, CQRS commands/queries, validators
│   ├── ERDS.Domain                     // Entities, enums, value objects, business rules
│   ├── ERDS.Infrastructure             // EF Core, email, auth, file storage, logging
│   ├── ERDS.Infrastructure.Jobs        // Hangfire jobs, sync orchestration
│   ├── ERDS.Integrations.OpenEMIS      // OpenEMIS API client, sync, webhook handling
│   ├── ERDS.AI                         // AI/ML services (forecasting, anomaly, recommendations)
│   ├── ERDS.Contracts                  // DTOs, API contracts, shared request/response models
│   └── ERDS.Shared                     // Constants, enums, cross-cutting utilities
├── tests/
│   ├── ERDS.UnitTests
│   ├── ERDS.IntegrationTests
│   └── ERDS.Api.Tests
└── erds-web/                           // React frontend (Vite)
    ├── src/
    │   ├── api/                        // OpenAPI-generated TypeScript clients
    │   ├── auth/                       // MSAL config, auth context
    │   ├── components/                 // Reusable UI primitives
    │   │   ├── AppDataGrid
    │   │   ├── AppFilterPanel
    │   │   ├── AppFormDialog
    │   │   ├── AppLookupSelect
    │   │   ├── AppStatCard
    │   │   ├── AppPageHeader
    │   │   └── AppConfirmDialog
    │   ├── features/                   // Feature modules
    │   │   ├── dashboard/
    │   │   ├── inventory/
    │   │   ├── distributions/
    │   │   ├── projects/
    │   │   ├── reports/
    │   │   ├── admin/
    │   │   ├── notifications/
    │   │   ├── public-lookup/
    │   │   └── ai-insights/
    │   ├── hooks/
    │   ├── store/                      // Zustand stores
    │   ├── types/
    │   └── utils/
    └── public/
```

---

## Domain Model

### Organization / Delivery Structure
- `Tenant` / `MinistryInstance`
- `Region` (synced from EMIS, local cache with `ExternalId`, `LastSyncedAt`, `SourceSystem`)
- `Department`
- `School` / `Institution` (synced from EMIS)
- `SchoolLevel` (synced from EMIS)
- `Grade` (synced from EMIS)
- `AcademicYear`
- `SchoolTerm`

### People / Recipients
- `User` (internal app users, linked to Azure AD)
- `Staff` (synced from EMIS)
- `Teacher` (synced from EMIS)
- `Student` (synced from EMIS)
- `RecipientProfile` — polymorphic recipient: `RecipientType`, `RecipientExternalId` (EMIS ID), `RecipientName`, `DateOfBirth`, `InstitutionId`, `RegionId`, `SourceSystem`
- `RecipientType` enum: Department, Region, School, Staff, Teacher, Student

### Inventory
- `ItemCategoryGroup` (Textbooks, Devices, Furniture, Consumables, Teaching Aids, Uniforms, Other)
- `ItemCategory` (e.g., Mathematics Textbooks, Tablets, Chairs)
- `ItemSubcategory`
- `Item` / SKU (e.g., Grade 3 Mathematics Textbook, Lenovo 100e Laptop)
- `ItemUnit`
- `ItemCondition`
- `ItemSource`
- `Supplier` / `Donor`
- `StockLocation`
- `StockBalance`
- `StockTransaction` — ledger model: TransactionType, ItemId, QuantityIn/Out, SourceLocation, DestinationLocation, LinkedDistributionLineId, Timestamp, ActorId

### Distribution
- `DistributionHeader` — DistributionNumber, SourceType/Id, DestinationType/Id, Status, CreatedBy, ApprovedBy, IssueDate, ReceiptStatus, Notes, ProjectId (optional)
- `DistributionLine` — ItemId, QtyRequested, QtyApproved, QtyIssued, QtyReceived, Remarks
- `ReceiptConfirmation`
- `Transfer`
- `Return`
- `Adjustment`

### Projects / Programs
- `Project` — Name, Description, StartDate, EndDate, OwningDepartment, FundingSource, TargetAudience
- `ProjectTargeting` — list of target schools, filters (region, grade levels, school type, enrollment thresholds)
- `ProjectResourcePlan` — items to distribute, target quantities per student/teacher/school

### Resource Intelligence
- `ResourceLifecycle` — IssueDate, ExpectedLifespan, Condition, ReturnDate, ReassignmentHistory
- `ResourceState` enum: New, InUse, Aging, DueForReplacement, Lost, Returned, Reassigned
- `SufficiencyScore` — per school: Sufficient, NeedsSupplement, CriticalShortage, OverSupplied

### Stock Alerts
- `AlertProfile` — per distributor
- `ItemThresholdRule` — global default, category-based, item-specific thresholds
- `AlertExclusion` — items excluded from alerting
- `NotificationChannel` — dashboard-only, email, or both

### Governance / Security
- `Role`
- `Permission` (e.g., inventory.view, inventory.create, distribution.create, distribution.approve, distribution.receive, reports.export, admin.manage_users)
- `UserRestriction` — region, department, school, entity-type restrictions, can-view-global-reports
- `AuditLog`
- `Notification`
- `Attachment`

### OpenEMIS Integration Tables
- `emis_regions`, `emis_institutions`, `emis_school_levels`, `emis_grades`
- `emis_people`, `emis_students`, `emis_staff`
- `sync_runs`, `webhook_events`, `external_mappings`

---

## Data Ownership

**Owned by OpenEMIS** (synced, not authored in ERDS):
- Regions, Institutions/Schools, School Levels, Grades, Students, Teachers, Staff, EMIS identifiers

**Owned by ERDS**:
- Item categories, Items/SKUs, Stock locations, Stock balances, Stock transactions, Distributions, Receipts, Low stock rules, Notification preferences, Audit logs, Roles, Permissions, Projects

**Cached locally from EMIS** (tagged with `ExternalSource`, `ExternalId`, `LastSyncedAt`):
- All EMIS entities for fast search, reporting joins, resilience

---

## OpenEMIS Integration Strategy

1. **Initial Sync**: One-time bulk import of regions, institutions, grades/levels, active students, teachers/staff
2. **Scheduled Sync**: Nightly full or delta sync via background jobs, with retry for failed records
3. **Webhook-Driven Updates**: Listen for student/institution/staff created/updated events

### Integration Components
- `OpenEmisApiClient` — HTTP client for OpenEMIS Core v5 API
- `OpenEmisSyncService` — orchestrates initial + scheduled syncs
- `OpenEmisWebhookController` — receives webhook payloads
- `SyncCheckpointRepository` — tracks sync state
- `ExternalIdentityResolver` — maps EMIS IDs to local entities
- `IntegrationAuditService` — logs all sync events

---

## API Design

Resource-based REST with versioning: `/api/v1/...`

Key endpoints:
- `/api/v1/items`, `/api/v1/item-categories`, `/api/v1/stock-locations`, `/api/v1/stock-balances`
- `/api/v1/distributions`, `/api/v1/distributions/{id}`, `/api/v1/distributions/{id}/approve`, `/api/v1/distributions/{id}/receive`
- `/api/v1/distributions/search`
- `/api/v1/projects`, `/api/v1/projects/{id}/resource-plan`
- `/api/v1/reports/stock-summary`, `/api/v1/reports/distribution-by-category`, `/api/v1/reports/distribution-by-recipient`
- `/api/v1/admin/users`, `/api/v1/admin/permissions`
- `/api/v1/schools/{id}/resource-snapshot`
- `/api/v1/ai/demand-forecast`, `/api/v1/ai/sufficiency-scores`, `/api/v1/ai/anomalies`
- `/api/v1/public/recipient-lookup` (unauthenticated, rate-limited, CAPTCHA)
- `/api/v1/webhooks/openemis` (webhook receiver)

---

## Security Model

### Authentication
- Azure AD / Entra ID via OpenID Connect (frontend) + JWT bearer (API)
- MSAL React on frontend, Microsoft.Identity.Web on backend

### Authorization
- Hybrid model: Azure AD authenticates, app maps to internal permissions
- Permission-based actions (inventory.view, distribution.approve, etc.)
- Data restrictions by region, department, school

### Public Lookup Security
- EMIS ID + DOB exact match only
- Rate limiting (IP-based)
- CAPTCHA after repeated attempts
- Short-lived session token after successful lookup
- Lockout threshold after repeated failures
- Audit log of all attempts
- Minimal field exposure (item name, quantity, date, issuing org)

---

## AI & Intelligence Layer

### Phase 1 (MVP AI — statistical/rules-based)
- Demand forecasting (basic regression + moving averages using historical distributions + EMIS enrollment)
- Stock depletion prediction ("will run out in X days")
- Low-stock intelligent alerts (beyond simple thresholds)
- AI dashboard summaries
- Anomaly detection (simple rules + statistics: duplicate distributions, unrealistic quantities, enrollment mismatches)

### Phase 2 (ML models)
- Enrollment-based allocation modeling (expected vs actual)
- Return rate prediction (by school, region, item, grade)
- Redistribution/rebalancing suggestions
- Procurement planning recommendations
- Sufficiency scoring per school
- Device lifecycle intelligence
- Duplicate prevention warnings during distribution

### Phase 3 (LLM/Advanced)
- Conversational AI assistant for decision makers
- Natural language reporting queries
- Auto-generated report summaries
- AI-powered project planning assistant

### AI Architecture
```
ERDS.AI
├── ForecastingService
├── RecommendationService
├── AnomalyDetectionService
├── InsightGenerationService
└── NaturalLanguageQueryService
```

### AI Governance
- All predictions must be explainable
- Store model inputs and outputs
- Users can override AI decisions
- Never auto-execute distributions
- Log all AI recommendations

---

## Reporting

### Core Reports
- Stock on hand by location/category
- Distribution history, item movement ledger
- Distributions by period/destination type/category
- Regional/school summaries
- Teacher/student issue reports
- Loss/return rates
- Unconfirmed receipts exception report
- Audit trail by user/date/action

### Dashboard Cards (per distributor)
- Current stock count, this month's distributions, pending confirmations
- Recently received stock, low stock items, top distributed categories

### Global Admin Dashboards
- Total distributions this term, distributions by region
- Top categories issued, schools with lowest stock
- Unconfirmed distributions aging report

---

## Steps

### Phase 1: Discovery & Design (Foundation)
1. Document all business processes and distribution scenarios
2. Confirm item category hierarchy and reporting requirements
3. Define role/permission matrix and data restriction model
4. Map current entities to new domain model
5. Design database schema (EF Core migrations)
6. Define OpenEMIS integration mapping (EMIS entities → local cache tables)
7. Create API contract specifications (OpenAPI)

**Deliverables**: Business rules document, domain model, role/permission matrix, reporting catalogue, API specs

### Phase 2: Technical Foundation (*parallel with late Phase 1*)
8. Create .NET 10 solution with clean architecture projects (Api, Application, Domain, Infrastructure, Integrations, AI, Contracts, Shared)
9. Create React app (Vite + TypeScript) with project structure
10. Configure Azure AD authentication (MSAL React + Microsoft.Identity.Web)
11. Set up Supabase PostgreSQL and EF Core connection
12. Configure CI/CD pipeline
13. Configure Serilog logging, secrets management, environment configs
14. Set up OpenAPI generation and TypeScript client codegen
15. Create initial EF Core migrations and run against Supabase

**Deliverables**: Running skeleton backend+frontend, authenticated hello-world API, database migration pipeline

### Phase 3: Core Domain & Data Layer
16. Build organization entities (Region, Department, School, AcademicYear, SchoolTerm) — *depends on 15*
17. Build user/permission/restriction management — *depends on 16*
18. Build item category hierarchy (CategoryGroup → Category → Subcategory → Item) — *parallel with 17*
19. Build stock location and stock balance management — *depends on 18*
20. Build stock transaction ledger — *depends on 19*
21. Seed foundational lookup data — *depends on 16, 18*
22. Build reusable frontend components (AppDataGrid, AppFilterPanel, AppFormDialog, AppLookupSelect, AppStatCard, AppPageHeader, AppConfirmDialog) — *parallel with 16-21*
23. Build admin UI pages (users, roles, permissions) — *depends on 17, 22*
24. Build inventory UI pages (categories, items, stock locations) — *depends on 18-20, 22*

**Deliverables**: Initial database schema, admin APIs + UI, item/category/location management

### Phase 4: OpenEMIS Integration (*parallel with late Phase 3*)
25. Implement `OpenEmisApiClient` for Core v5 API — *depends on 15*
26. Implement initial bulk sync service (regions, institutions, grades, students, staff) — *depends on 25*
27. Implement scheduled nightly sync job (Hangfire) — *depends on 26*
28. Implement webhook receiver endpoint (`OpenEmisWebhookController`) — *depends on 25*
29. Build sync monitoring dashboard and audit logging — *depends on 26-28*
30. Build `ExternalIdentityResolver` for mapping EMIS IDs to local entities — *depends on 26*

**Deliverables**: EMIS data synced locally, webhook listener active, sync audit trail

### Phase 5: Distribution Engine (*depends on Phase 3 + 4*)
31. Build DistributionHeader + DistributionLine CRUD — *depends on 20, 30*
32. Implement distribution workflow: Create → Approve → Issue → Receive — *depends on 31*
33. Implement stock transaction ledger writes on each workflow step — *depends on 32*
34. Implement permission + restriction validation on all distribution actions — *depends on 17, 32*
35. Build Returns and Adjustments — *depends on 33*
36. Build distribution UI: list, create, detail, approve, receive flows — *depends on 22, 32*

**Deliverables**: Full end-to-end distribution workflow, audit entries, stock ledger

### Phase 6: Projects, Resource Intelligence & Alerts (*depends on Phase 5*)
37. Build Project/Program module (project CRUD, targeting, resource plans) — *depends on 31*
38. Build School Resource Snapshot feature (current inventory, distribution history, ownership breakdown, lifecycle insights) — *depends on 33, 30*
39. Build Resource Lifecycle Tracking (issue date, lifespan, condition, resource states) — *depends on 33*
40. Build pre-distribution intelligence warnings (duplicate detection, over-supply, aging devices) — *depends on 38, 39*
41. Build per-distributor stock alert management (AlertProfile, threshold rules, exclusions, notification channels) — *depends on 20*
42. Build project + resource intelligence UI — *depends on 22, 37-40*

**Deliverables**: Project-based distribution planning, school snapshots, smart warnings, alert management

### Phase 7: Dashboards, Reports & Notifications (*parallel with Phase 6*)
43. Build distributor dashboard (stock count, distributions, pending, low stock, trends) — *depends on 20, 33*
44. Build regional + national admin dashboards — *depends on 43*
45. Build core report endpoints (stock on hand, distribution history, movement ledger, category reports) — *depends on 33*
46. Build Excel/PDF export functionality — *depends on 45*
47. Implement SendGrid email notifications via background jobs (distribution created/approved/rejected, receipt pending, low stock alerts, monthly summaries) — *depends on 41*
48. Build dashboard + reports UI — *depends on 22, 43-46*

**Deliverables**: Operational dashboards, downloadable reports, email notifications

### Phase 8: Public Lookup & AI MVP (*depends on Phase 5*)
49. Build public recipient lookup endpoint (EMIS ID + DOB, rate limiting, CAPTCHA, audit logging) — *depends on 30*
50. Build public lookup UI page — *depends on 49*
51. Implement demand forecasting (basic statistical models using distribution history + enrollment) — *depends on 33, 30*
52. Implement stock depletion prediction — *depends on 20*
53. Implement anomaly detection (rules + statistics) — *depends on 33*
54. Build AI insights dashboard cards and summaries — *depends on 51-53*

**Deliverables**: Public lookup portal, MVP AI forecasting + anomaly detection

### Phase 9: Advanced AI (Post-MVP)
55. Enrollment-based allocation modeling
56. Return rate prediction
57. Redistribution/rebalancing recommendations
58. Procurement planning AI
59. Sufficiency scoring per school
60. Natural language query interface (LLM integration)

### Phase 10: Hardening & Rollout (*depends on Phase 7 + 8*)
61. Performance testing and optimization
62. Security testing (OWASP Top 10 review)
63. UAT with MOE stakeholders
64. Data migration from current system (items, categories, stock balances, distribution history, users, roles)
65. User training and documentation
66. Production deployment

**Deliverables**: Production-ready app, rollout checklist, user guides

---

## Relevant Files (to be created)

### Backend
- `src/ERDS.Api/Program.cs` — API entry point, DI, middleware, auth config
- `src/ERDS.Api/Controllers/` — DistributionController, InventoryController, ProjectController, ReportController, AdminController, WebhookController, PublicLookupController
- `src/ERDS.Application/` — Commands/Queries (MediatR handlers), Validators (FluentValidation)
- `src/ERDS.Domain/Entities/` — All domain entities listed above
- `src/ERDS.Domain/Enums/` — RecipientType, ResourceState, DistributionStatus, TransactionType, etc.
- `src/ERDS.Infrastructure/Persistence/ErdsDbContext.cs` — EF Core context
- `src/ERDS.Infrastructure/Persistence/Configurations/` — Entity type configurations
- `src/ERDS.Infrastructure/Persistence/Migrations/` — EF Core migrations
- `src/ERDS.Infrastructure/Services/` — EmailService (SendGrid), CurrentUserService, etc.
- `src/ERDS.Integrations.OpenEMIS/` — OpenEmisApiClient, SyncService, WebhookHandler
- `src/ERDS.AI/` — ForecastingService, AnomalyDetectionService, etc.

### Frontend
- `erds-web/src/api/` — OpenAPI-generated TypeScript clients
- `erds-web/src/auth/` — MSAL configuration and auth context
- `erds-web/src/components/` — Reusable primitives (AppDataGrid, AppFilterPanel, etc.)
- `erds-web/src/features/` — Feature modules (dashboard, inventory, distributions, projects, reports, admin, public-lookup, ai-insights)

---

## Verification

1. **Auth flow**: Verify Azure AD login from React → API call with JWT token → permission check succeeds/fails correctly
2. **EMIS sync**: Run initial sync against OpenEMIS demo API (https://api.openemis.org/core/v5/) and verify local cache populated
3. **Distribution workflow**: Create → Approve → Issue → Receive end-to-end test, verify stock transaction ledger entries
4. **Public lookup**: Test EMIS ID + DOB lookup with rate limiting, verify audit log entries, verify CAPTCHA triggers after threshold
5. **Reports**: Verify stock-on-hand, distribution history, and category reports return correct aggregated data
6. **Alerts**: Configure distributor thresholds, verify low-stock alerts fire correctly (dashboard + email)
7. **AI forecasting**: Feed historical data, verify demand forecast output is reasonable and explainable
8. **Security**: Run OWASP ZAP scan, verify no injection/XSS/CSRF vulnerabilities, verify public endpoint rate limiting
9. **Performance**: Load test distribution search and report endpoints under expected concurrent user load
10. **Data migration**: Migrate sample data from current system, verify integrity of items, categories, stock balances, distributions

---

## Decisions

- **EMIS-first master data principle**: ERDS consumes master education data from OpenEMIS and does not independently maintain parallel master records except for synchronized local caches
- **Verified self-service access principle**: Recipients query distribution records via EMIS ID + DOB without full authentication, with privacy/audit/anti-abuse controls
- **Decentralized stock governance**: Each distributor manages their own stock balances, dashboard visibility, and low-stock thresholds
- **AI assists, never controls**: All AI outputs are recommendations; users can override; no auto-execution of distributions
- **Supabase as managed PostgreSQL**: Use Supabase primarily for Postgres hosting, backups, and observability; keep auth and business logic in .NET
- **OpenAPI-first API contracts**: Generate TypeScript clients from .NET API OpenAPI specs; no hand-written fetch calls
- **Stock transaction ledger model**: Every inventory movement creates a StockTransaction entry for audit and reporting
- **Clean architecture**: Separate Api, Application, Domain, Infrastructure layers; no business logic in controllers

## Scope Boundaries

**In scope (MVP)**:
- Azure AD authentication, users/roles/permissions/restrictions
- OpenEMIS initial sync + webhook listener + scheduled sync
- Item categories, items, stock locations, stock balances, stock transactions
- Distribution workflow (create, approve, issue, receive, return, adjust)
- Per-distributor low-stock alert rules
- Distributor + admin dashboards
- Core reports with Excel/PDF export
- SendGrid email notifications
- Public EMIS ID + DOB recipient lookup
- Project/Program-based distribution planning
- School Resource Snapshot
- AI MVP (demand forecasting, stock depletion, anomaly detection, dashboard summaries)
- Audit logging for all key actions

**Excluded from MVP (future phases)**:
- Mobile app
- Offline mode
- Barcode/QR tracking
- IoT inventory tracking
- Procurement system integration
- Advanced ML models (return rate prediction, rebalancing)
- Full conversational AI assistant
- Auto-generated reports via LLM

---

## Further Considerations

1. **UI Component Library**: MUI vs Ant Design — recommend MUI for its Material Design alignment and strong React ecosystem, but Ant Design has richer data-heavy components (tables, forms). Decision should be based on team familiarity.
2. **OpenEMIS API Authentication**: The demo API is at https://api.openemis.org/core/v5/ — need to confirm production API credentials and webhook configuration with MOE IT. This could be a blocker for Phase 4.
3. **AI Infrastructure**: For MVP, ML.NET within the .NET backend is simplest. For Phase 3 conversational AI, Azure OpenAI is recommended. Budget approval for Azure OpenAI API costs may need to be secured early.
