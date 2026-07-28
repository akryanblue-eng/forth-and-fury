# ADR 0001 — Prototype Engine & Language

- **Status:** Accepted
- **Work item:** F1 — Decide the engine and language
- **Phase:** 0 (Foundation)
- **Date:** 2026-07-25

> This decision record captures a **ratified** choice and the reasoning behind it, so the pick is deliberate and can be revisited against the explicit criteria below. F1's `Done when` also requires a running "hello world" scene; that proof ships with the F2 project skeleton (the attract screen).

## Context

Fourth & Fury needs an engine for its **Phase 1 core-loop prototype** (see `docs/roadmap.md`). The prototype's only job is to answer one question: *is one play of Fourth & Fury fun?* The engine choice for the prototype should optimize for **speed to a playable, legible core loop**, not for being the final shipping engine.

The requirements that actually matter, ranked:

1. **Fast to first playable.** The sooner we can hit, fumble, and replay, the sooner we learn.
2. **Physics we can reason about.** Controlled Chaos is a pillar — fumbles come from impact angle, force, ball security, and fatigue. We need a physics/collision model we can inspect and tune, not a black box.
3. **Determinism-friendly.** Phase 3 wants rollback netcode, which needs a deterministic simulation. We don't need full determinism *in the prototype*, but we shouldn't pick a stack that makes it impossible later.
4. **Small-team ergonomics.** Fast iteration, readable scenes, low ceremony.
5. **Cross-platform reach.** Desktop first; console/web later.

## Options Considered

### Option A — Godot 4 (C#)
- **Pros:** Open source, lightweight, fast iteration loop, readable scene model, good 2.5D/3D support, C# gives us a typed language for the ratings/fatigue data model. Zero licensing friction for a small team.
- **Cons:** Built-in physics (Godot Physics / Jolt) is **not deterministic out of the box** — rollback netcode in Phase 3 will require a custom fixed-step deterministic layer or a deterministic physics library. Smaller ecosystem than Unity for niche middleware.

### Option B — Unity
- **Pros:** Mature tooling, enormous ecosystem, DOTS/ECS available for performance, strong console pipeline.
- **Cons:** Heavier to stand up, more ceremony per iteration, licensing/pricing considerations for a small experimental project, and its default physics is likewise non-deterministic (deterministic paths exist but add weight). Overkill for answering "is one play fun?"

### Option C — Custom (Rust + Bevy, or C++)
- **Pros:** Full control over a deterministic fixed-step simulation — the cleanest long-term path to rollback netcode.
- **Cons:** Highest cost, slowest to first playable, and it front-loads engineering before we've proven the game is fun. Wrong altitude for Phase 1.

## Decision

**Use Godot 4 with C# for the Phase 1 prototype.**

Rationale: it wins decisively on requirements #1, #2, and #4 — the ones that determine how fast we learn whether the game is fun. The determinism gap (#3) is a **Phase 3** concern, and the prototype is explicitly disposable: proving fun is its whole job, not shipping.

To keep the Phase 3 door open without paying for it now, the prototype will observe two cheap disciplines from day one:
- **Fixed-timestep simulation** — game logic runs on a fixed tick, rendering interpolates. This is good practice regardless and is the foundation any future rollback layer needs.
- **Simulation/render separation** — gameplay state (positions, ratings, fatigue, ball security) lives in plain C# data the sim owns, not smeared across engine nodes. This keeps the door open to swapping the physics/authority layer later.

## Consequences

- Phase 1 moves quickly; the team iterates on feel, not tooling.
- The Controlled Chaos systems (fumbles from angle/force/security/fatigue) are implemented in inspectable C# on top of Godot collisions — which is exactly what the "no RNG-only outcomes" guardrail needs.
- **A determinism spike is owed before Phase 3 commits to netcode.** We will re-evaluate Godot's physics determinism vs. a custom deterministic sim layer at that point. The prototype being disposable means switching engines for the shipping build remains on the table at low sunk cost.

## Revisit Criteria (re-open this ADR if…)

- Phase 1 proves fun **and** a determinism spike shows Godot's physics can't be made rollback-safe at acceptable cost → evaluate a custom deterministic sim layer or engine swap for the shipping build.
- The prototype hits a hard performance wall the built-in physics can't clear.
- Team composition changes such that Unity's ecosystem or a custom engine becomes clearly cheaper overall.
