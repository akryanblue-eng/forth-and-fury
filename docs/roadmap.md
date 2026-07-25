# Roadmap

A phased plan to get **Fourth & Fury** from a design doc to a shipped game. Each phase has a clear question it needs to answer before the next begins. We do **not** move forward on schedule — we move forward on proof.

The guiding principle: **prove the pillars in the smallest possible slice before building breadth.** A prototype that proves Counter-Play Defense and Controlled Chaos are fun is worth more than a feature-complete menu system.

---

## Phase 0 — Foundation (current)

**Question:** *What are we building, and what won't we compromise on?*

- [x] Define the five design pillars
- [x] Establish the "lines we won't cross" for each pillar
- [x] Write this roadmap
- [ ] Choose an engine and language (see [Tech Direction](#tech-direction))
- [ ] Stand up a build/CI skeleton so the first prototype has somewhere to live

**Exit criteria:** an empty-but-running project skeleton, and agreement on the tech stack.

---

## Phase 1 — The Core Loop Prototype

**Question:** *Is one play of Fourth & Fury fun?*

This is the most important phase. Everything else is optional until this is proven.

- [ ] A single field, two teams of placeholder players
- [ ] Basic offense: snap, hand-off / pass, run
- [ ] Basic defense: control a defender, tackle
- [ ] **Controlled Chaos v1** — fumbles driven by impact angle + ball security (no RNG-only outcomes)
- [ ] **Counter-Play Defense v1** — at least one defensive audible and the dive counter
- [ ] Instant replay so chaos outcomes are legible

**Exit criteria:** a playtester can run a play, get blown up by a well-timed hit, watch the replay, and understand *why* — and want to run it again.

---

## Phase 2 — A Full Game

**Question:** *Does a full match hold up?*

- [ ] Downs, scoring, clock, quarters
- [ ] A small but real playbook on both sides of the ball
- [ ] Fatigue system feeding into Controlled Chaos
- [ ] Anti-spam adaptation v1 — repeated plays get measurably harder to run
- [ ] Local couch multiplayer (1v1)
- [ ] Basic UI: play select, HUD, score

**Exit criteria:** two people can play a complete, satisfying game on one couch, and the person spamming a play loses.

---

## Phase 3 — Online Rivalries

**Question:** *Does it hold up against strangers, over time?*

- [ ] Netcode (rollback preferred for a fast arcade game)
- [ ] Ranked matchmaking + seasons
- [ ] Persistent stat tracking and head-to-head records
- [ ] Rematch flow and rival surfacing
- [ ] Private leagues (invite, schedule, standings)

**Exit criteria:** a small closed beta produces recurring rivalries and a functioning ladder.

---

## Phase 4 — Fury Franchise

**Question:** *Can the sandbox generate stories?*

- [ ] Draft + scouting with absurd athlete generation
- [ ] Season simulation, injuries, suspensions, weather
- [ ] Stadium upgrades and home-field effects
- [ ] Owner demands and firing conditions
- [ ] Rivalry development across seasons

**Exit criteria:** a franchise playthrough produces at least one memorable, emergent story a player would tell a friend.

---

## Phase 5 — Fantasy Mayhem & Polish

**Question:** *Is it worth showing the world?*

- [ ] Player creator (cosmetic + stat)
- [ ] Mutant stat build archetypes
- [ ] Destructible props and environmental hazards
- [ ] Cosmetic/uniform system
- [ ] Audio, VFX, juice, and game-feel pass
- [ ] Accessibility and options pass

**Exit criteria:** a vertical slice good enough for a public trailer.

---

## Tech Direction

*Not yet decided — this is a starting-point recommendation, to be confirmed in Phase 0.*

The needs: fast 3D-or-stylized physics, deterministic simulation for rollback netcode, cross-platform reach, and a content pipeline for lots of players/stadiums.

Candidate stacks to evaluate:

| Option | Strength | Risk |
| --- | --- | --- |
| **Godot 4 (C#)** | Open, lightweight, great for a small team | Physics determinism needs care for rollback |
| **Unity** | Mature tooling, huge ecosystem, DOTS for perf | Heavier, licensing considerations |
| **Custom (Rust/bevy or C++)** | Full control over deterministic sim | Highest cost, slowest to first playable |

**Recommendation:** start Phase 1 in **Godot 4** for speed to a playable prototype, and re-evaluate before committing to Phase 3 netcode. The prototype's job is to prove fun, not to be the shipping engine.

---

## How We Prioritize

1. **Pillars over features.** A feature that doesn't serve a pillar waits.
2. **Fun before breadth.** Prove the core loop before building modes on top of it.
3. **Readable over realistic.** When in doubt, favor the option the player can understand.
