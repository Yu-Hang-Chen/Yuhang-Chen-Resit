# Power Cell Escape

## Overview
In this game, you must control a player who must collect 3 power cells scattered around a compact level, then escape through an exit that unlocks once all cells are collected. There are monsters patrolling in the map which adds challenges, and the level is designed with accessibility in mind.

## Gameplay
- **Objective:** Collect all 3 power cells to unlock the exit and escape the level.
- **Threats:** Patrolling enemies would try to catch you.
- **Win condition:** Player reaches the exit after collecting all cells.
- **Lose condition:** If the player is caught by the monsters or the time is up, this game would be over.
- **Estimated playtime:** 3–5 minutes.

## Controls
| Action | Key |
|---|---|
| Move | WASD |
| Jump | Space |
| Interact | E |
| Pause | Esc |

## Accessibility Features
- List any accessibility considerations here (e.g. colorblind-friendly indicators, remappable controls, subtitles, adjustable difficulty).

## How to Build / Run

### Option 1: Run from source
1. Clone this repository.
2. Open the project in **Unity [insert version, e.g. 2022.3.x LTS]** via Unity Hub.
3. Open the scene: `Assets/Scenes/MainLevel.unity`.
4. Press Play in the Editor.

### Option 2: Run the build
1. Download the latest build from the [Releases](../../releases) page (tag: `resit-submission`).
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
DevelopmentLog.md - Ongoing development log
```

## External Assets & Credits
List every third-party asset used, with source and license info. Example format:

| Asset | Source | License |
|---|---|---|
| Character sprite | [Kenney.nl](https://kenney.nl) | CC0 |
| Background music | [Freesound](https://freesound.org) | CC-BY 4.0 |

*(Remove this section if you created all assets yourself, but state that explicitly instead.)*

## AI Usage Disclosure
*(If you used any AI tools during development, briefly state what was used and for what purpose — e.g. "ChatGPT was used to help debug a collision detection issue in PlayerController.cs." Full disclosure details go in the final report.)*

## Author
Yuhang Chen
