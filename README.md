# Power Cell Escape

## Overview
In this game, you must control a player who must collect 3 power cells scattered around a compact level, then escape through an exit that unlocks once all cells are collected. There are monsters in the map which adds challenges, and the level is designed with accessibility in mind.

## Gameplay
- **Objective:** Collect all 3 power cells to unlock the exit and escape the level.
- **Threats:** Patrolling enemies would try to catch you.
- **Win condition:** Player reaches the exit after collecting all cells.
- **Lose condition:** If the player is caught by the monsters or the player drop into water, he would die.
- **Estimated playtime:** 3–5 minutes.

## Controls
| Action | Key |
|---|---|
| Move | WASD |
| shoot | left button of mouse |
| Pause | Esc |

## Accessibility Features
- List any accessibility considerations here (e.g. colorblind-friendly indicators, remappable controls, subtitles, adjustable difficulty).

## How to Build / Run
Run this game with the build file or download the final release package.

### Option 1: Run from source
1. Clone this repository.
2. Open the project in **Unity 2022.3.62f3** via Unity Hub.
3. Open the scene: `Assets/Scenes/MainLevel.unity`.
4. Press Play in the Editor.

### Option 2: Run the build
1. Download the latest build from the release page (tag: Final Release ).
2. Extract the zip file.
3. Run the executable (`.exe` for Windows / `.app` for Mac).

## Project Structure
```
Assets/
├── Scripts/     - All C# gameplay scripts
├── Scenes/      - Game scenes (MainLevel, MainMenu, etc.)
├── Prefabs/     - Reusable prefab objects
├── Art/         - Models, textures, sprites
└── Audio/       - Sound effects and music
Docs/            - Concept design docs and testing tables
DevelopmentLog/
├── DevelopmentLog.md- Ongoing development log
├── TestingTable.md - Ongoing testing Table, including at least 5 important tests
ProjectSettings/ - All project setting files
Packages/        - All packages
```

## External Assets & Credits
I have only used one external asset for this game
Asset Name: Water
Creator: danielshervheim (Name of creator in Unity Asset Store)
Source: https://github.com/danielshervheim/unity-stylized-water/tree/main/Assets/Stylized%20Water
Accessed: 2026-8-01
Modifications: Used as environmental prop


## AI Usage Disclosure

As part of the development and reporting process for *Power Cell Escape*, our team used AI tools in the following ways. This section discloses each tool used, its purpose, representative prompts, the type of output generated, and how we validated or modified that output before including it in our final submission.

## 1. Tools Used

- **Claude (Anthropic)** — used primarily for code review, debugging assistance, and helping improving structure for the report.
- 

# 2. Purpose and Representative Prompts

### 2.1 Code Debugging and Review
We used AI to review our Unity C# scripts (e.g. `BulletControl.cs`, `SpawnerControl.cs`) for logic errors, inefficiencies, and edge cases we may have overlooked.

**Representative prompt:**
> "Can you review this bullet collision script and point out any issues with how the Rigidbody component is being accessed, and whether the physics implementation matches what we intended?"

**Output type:** Written code critique identifying specific issues (e.g., `GetComponent<Rigidbody>()` being called every frame in `Update()` instead of cached once in `Start()`; missing null-check before calling `takeDamage()` on the enemy script; a discrepancy between our intended design — using `AddForce()` for bullet propulsion — and the actual implementation, which overwrites `rb.velocity` directly every frame).

**How we validated it:** We manually inspected the flagged lines in the Unity editor, reproduced the described behavior (e.g., confirmed the bullet trajectory does not respond to gravity because velocity is being overwritten, not force-applied), and decided which fixes to implement given our remaining time budget. We did not blindly apply every suggestion — for example, we chose to keep the current velocity-based movement because it gave us more predictable bullet trajectories, and documented this as an intentional design trade-off rather than a bug.

### 2.2 Improving structure of the report
We used AI to help us articulate *why* we made certain implementation choices, so we could explain our reasoning clearly in both the written report and the video.

**Representative prompt:**
> "We chose to use Coroutines to run multiple enemy spawners in parallel instead of using timers inside Update(). Can you help us explain the technical reasoning behind this choice in a way that's clear for a course report?"

**Output type:** Short explanatory paragraphs comparing our chosen approach (Coroutines, physical 3D bullets with Rigidbody, OnTriggerEnter for water death detection) against alternative approaches (per-object timers, Raycast-based hit detection, OnCollisionEnter), with the trade-offs of each.

**How we validated it:** We cross-checked every technical claim against Unity's official documentation (e.g., confirming that Coroutines run on the main thread and are not true multithreading, and that Trigger colliders do not produce physical collision response). We rewrote the AI-generated explanations in our own words for the final report to ensure the terminology matched our actual code and our own understanding.

### 2.3 Identifying Gaps in Our Own Code
We asked AI to point out inconsistencies between what we planned to say in our report and what our code actually does.

**Representative prompt:**
> "Our report says we used Force to propel bullets, but here's our actual script — does the code match that description?"

**Output type:** A direct comparison flagging that our script sets `rb.velocity` every frame rather than using `AddForce()`, which meant our report's wording did not accurately describe our implementation.

**How we validated it:** We corrected the wording in our report to accurately reflect the implementation, rather than changing the code to match the original claim, since the current behavior (stable, non-gravity-affected trajectories) was actually the behavior we wanted.

## 3. What Was NOT Generated by AI

- All game design decisions (core loop, resource collection mechanic, water-death mechanic, enemy scaling) were made independently by our team before consulting AI.
- All Unity scripts (`BulletControl.cs`, `SpawnerControl.cs`, `EnemyController.cs`, etc.) were originally written by our team. AI was used only to review, critique, and help debug existing code — not to generate new gameplay scripts from scratch.
- All art assets, prefabs, and scene design were created manually by the team.

## 4. Summary of AI-Assisted Content in Final Submission

| Section of Submission | AI Involvement | Team Verification |
|---|---|---|
| Written Report — "Programming Decisions" section | AI helped structure explanations of Coroutine usage, bullet physics, and trigger-based water detection | Rewritten in team's own words; all technical claims verified against Unity documentation and our own code |
| Debugging process | AI identified specific code issues (inefficient component caching, missing null checks, velocity vs. force discrepancy) | Each issue was manually reproduced and confirmed in the Unity editor before being fixed or documented as a known limitation |
| Video script (programming decisions segment) | AI helped draft talking points explaining *why* certain technical choices were made | Final script written and recorded by team members in their own voice |

No AI-generated code, art, or audio was included directly in the final game build.


## Author
Yuhang Chen
