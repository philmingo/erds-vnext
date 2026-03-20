# ERDS vNext Product and Engineering Process Guide

## 1. Purpose

This document defines the structured process for designing, building, and delivering the ERDS vNext application.

It ensures that development is:

* Systematic
* Aligned with business outcomes
* Scalable and maintainable
* Coordinated between frontend and backend
* Suitable for AI-assisted development

This guide is intended for:

* Developers (Frontend & Backend)
* Technical Leads
* Product Owners
* AI Development Agents

---

## 2. Core Philosophy

ERDS vNext must be built using a **feature-based, vertical-slice approach**.

### Key Principle

Each feature must be delivered as a complete, working capability that includes:

* Business logic
* UI
* API
* Validation
* Permissions
* Audit logging
* Testing

Avoid:

* Building all UI first
* Building all backend first
* Building disconnected components

---

## 3. Development Model

Each feature follows three structured layers:

### 1. Define

* Understand the problem
* Identify users
* Clarify business rules

### 2. Design

* Create process flow
* Draft UI
* Define API contract

### 3. Deliver

* Build backend
* Build frontend
* Integrate and test

---

## 4. Feature Delivery Lifecycle

### Phase A: Business Definition

Every feature must clearly define:

* Goal
* Users
* Business value
* Required data
* Business rules
* Permissions
* Audit requirements
* Reporting implications

---

### Phase B: Process Mapping

Define the full workflow:

* Trigger
* Steps
* Decision points
* Outputs
* Exceptions

---

### Phase C: UI Draft

Create a draft UI (not final design):

* Screens
* Layout
* Actions
* Required fields
* States (loading, empty, error)

---

### Phase D: API Contract

Define clearly before development:

* Endpoints
* Request structure
* Response structure
* Validation rules
* Error cases

---

### Phase E: Backend Development (.NET)

Build in order:

1. Domain rules
2. Data models
3. Services / logic
4. API endpoints
5. Integrations
6. Tests

---

### Phase F: Frontend Development (React)

Build in order:

1. Page structure
2. Forms / data views
3. API integration
4. UI states
5. Role-based visibility
6. Mobile responsiveness

---

### Phase G: Testing

Test all scenarios:

* Valid flow
* Invalid input
* Permission restrictions
* Stock conflicts
* Integration failures

---

### Phase H: Demo & Sign-off

Feature is demonstrated to stakeholders and approved.

---

## 5. Definition of Ready

A feature is ready when:

* Business purpose is clear
* Process is defined
* UI draft exists
* API contract is defined
* Permissions identified
* Dependencies known

---

## 6. Definition of Done

A feature is complete when:

* Backend works
* Frontend works
* API integration works
* Permissions enforced
* Audit logging implemented
* Edge cases handled
* Mobile considered
* Stakeholder approved

---

## 7. System Build Order

### Milestone 0: Foundation

* Authentication
* Authorization
* App structure
* Logging
* Design system

### Milestone 1: EMIS Integration

* School sync
* Student sync
* Webhooks

### Milestone 2: Inventory

* Items
* Stock tracking

### Milestone 3: Distribution

* Create and manage distributions
* Approvals
* Stock updates

### Milestone 4: Visibility

* School resource views
* History tracking

### Milestone 5: Projects

* Programme-based distributions

### Milestone 6: Alerts

* Low stock
* Notifications

### Milestone 7: Public Access

* Resource verification

### Milestone 8: AI Layer

* Forecasting
* Recommendations

---

## 8. Frontend & Backend Coordination

Development must be synchronized:

1. Define feature together
2. Agree on API contract
3. Build backend logic
4. Build frontend UI
5. Integrate early
6. Test together

---

## 9. UI Development Levels

### Level 1: Wireframe

Basic layout

### Level 2: Functional UI

Working interface

### Level 3: Polished UI

Final design refinement

---

## 10. Roles & Responsibilities

### Product Lead

Defines business needs

### Technical Lead

Ensures architecture consistency

### Backend Developer

Implements logic and APIs

### Frontend Developer

Builds UI and interactions

### QA / Reviewer

Tests workflows

---

## 11. Required Documentation

Maintain:

* Product vision
* Module descriptions
* Feature definitions
* API contracts
* Design system (design.md)
* Decision log
* Test scenarios

---

## 12. Feature Template

Each feature must include:

* Name
* Goal
* Users
* Business value
* Process flow
* Inputs
* Outputs
* Permissions
* Alerts
* Reports
* Integrations
* UI screens
* API endpoints
* Acceptance criteria
* Test scenarios

---

## 13. Development Rules

1. No UI without process
2. No API without purpose
3. No feature without permissions
4. No feature without audit logging
5. No AI without clean data
6. No partial feature considered complete

---

## 14. Delivery Strategy

Build in vertical slices:

* Complete one feature at a time
* Ensure it works end-to-end
* Then move to next feature

---

## 15. Final Guiding Principle

The system must always evolve from:

Reactive → Structured → Intelligent

ERDS vNext is not just a system.
It is a national platform for resource intelligence.
