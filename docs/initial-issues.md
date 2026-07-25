# Initial Issues

The first concrete slice of work to break ground on **Fourth & Fury**. These are scoped to get from an empty repo to a playable core-loop prototype (Roadmap Phases 0–1). Each is written to be filed directly as a GitHub issue.

Ordering is roughly dependency-first: do the ⚙️ Foundation issues before the 🎮 Prototype ones.

---

## ⚙️ Foundation

### #1 — Decide the engine and language
**Pillar:** all · **Phase:** 0

Evaluate Godot 4 (C#), Unity, and a custom Rust/bevy option against our needs: fast physics, deterministic simulation for future rollback netcode, cross-platform reach, and a content pipeline. Produce a short decision doc in `docs/` with the pick and the reasoning.

**Done when:** an engine is chosen and recorded, and a "hello world" scene runs.

---

### #2 — Stand up project skeleton + CI
**Pillar:** all · **Phase:** 0 · **Depends on:** #1

Create the engine project structure, a `.gitignore` for it, and a CI workflow that builds the project and runs any tests on every push.

**Done when:** a green CI run is visible on a pushed commit.

---

### #3 — Define the core data model for players and ratings
**Pillar:** Controlled Chaos, Fantasy Mayhem · **Phase:** 1 · **Depends on:** #2

Design the player entity: physical attributes, ratings (speed, strength, ball security, hands, tackling), and fatigue state. This is the backbone Controlled Chaos and Fantasy Mayhem both build on, so get the shape right early.

**Done when:** a documented player struct/resource exists with placeholder values and can be instantiated in-engine.

---

## 🎮 Core Loop Prototype

### #4 — Playable field with two placeholder teams
**Pillar:** all · **Phase:** 1 · **Depends on:** #3

A single field, a line of scrimmage, and two teams of capsule/placeholder players that can be positioned and moved. No rules yet — just bodies on a field.

**Done when:** you can spawn both teams and move a controlled player around the field.

---

### #5 — Basic offense: snap, run, hand-off, pass
**Pillar:** Counter-Play Defense (as the thing to beat) · **Phase:** 1 · **Depends on:** #4

Implement the minimal offensive verbs: snap the ball, run with the carrier, hand off, and throw a basic pass to a receiver.

**Done when:** a player can snap and advance the ball by run or pass.

---

### #6 — Basic defense: control a defender and tackle
**Pillar:** Counter-Play Defense · **Phase:** 1 · **Depends on:** #5

Let a player control a defender and make a tackle that stops the ball carrier. Tackling is the hook the whole defensive pillar hangs on.

**Done when:** a controlled defender can stop the ball carrier and end the play.

---

### #7 — Controlled Chaos v1: physics-driven fumbles
**Pillar:** Controlled Chaos · **Phase:** 1 · **Depends on:** #6

Fumbles come from **impact angle + force + ball security + fatigue** — never a pure random roll. Blindside hits at speed should jar the ball loose far more often than a front wrap-up.

**Done when:** fumbles occur, and their likelihood provably tracks the input systems (documented test cases), with zero RNG-only outcomes.

---

### #8 — Counter-Play Defense v1: one audible + the dive counter
**Pillar:** Counter-Play Defense · **Phase:** 1 · **Depends on:** #6

Implement at least one pre-snap defensive audible and the "dive counter" — committing a defender to blow up a specific gap/route at the risk of being wrong.

**Done when:** the defense can pre-snap adjust and gamble on a gap, with a real payoff and a real cost.

---

### #9 — Instant replay for chaos legibility
**Pillar:** Controlled Chaos · **Phase:** 1 · **Depends on:** #7

A simple replay of the last play so a player can *see why* a fumble or big hit happened. This is what makes chaos feel earned instead of unfair — it's a pillar requirement, not a nicety.

**Done when:** the previous play can be replayed and the cause of a chaos outcome is visible.

---

### #10 — Prototype playtest & pillar review
**Pillar:** all · **Phase:** 1 · **Depends on:** #7, #8, #9

Put the prototype in front of testers. The bar: can they run a play, get blown up by a well-timed hit, watch the replay, understand *why*, and want to run it again?

**Done when:** playtest notes exist and there's a go/no-go call on advancing to Phase 2.

---

## Filing These

These can be created as GitHub issues verbatim. Suggested labels to set up first: `foundation`, `prototype`, and one label per pillar (`pillar:defense`, `pillar:chaos`, `pillar:online`, `pillar:franchise`, `pillar:mayhem`).
