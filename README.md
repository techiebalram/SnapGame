# Snap! Card Game Simulation (C# .NET)

A console-based simulation of the classic **Snap!** card game, written in C# with .NET.  
Two computer players compete to declare "Snap!" first when two consecutive cards match.

This repository also includes **MSTest unit tests** for game logic.

---

## Project Structure
SnapGame/ → Console application (main game)
├─ Program.cs → Game logic
├─ Card.cs → Card model

SnapGame.Tests/ → MSTest project
├─ SnapGameTests.cs → Unit tests for deck, shuffle, and match logic
├─ PlaySnapTests.cs → Integration tests for full game flow

## Features
- Supports **N packs** of standard playing cards (52 per pack).
- User chooses **matching rule**:
  - `face` → match by rank (e.g., 7♥ and 7♣).
  - `suit` → match by suit (e.g., 3♦ and 9♦).
  - `both` → exact match (e.g., Q♥ and Q♥).
- Deck is shuffled randomly before play.
- When two consecutive cards match:
  - A random player (Player 1 or Player 2) is chosen as winner of that pile.
- Game ends when deck is exhausted.
- Final scores and **winner (or draw)** are displayed.
- MSTest suite verifies deck creation, shuffling, matching, and game flow.

## How to Run

### Requirements
- Visual Studio 2022

### Run the Game
1. Open the solution in Visual Studio 2022.
2. Run the SnapGame project (F5 or Ctrl+F5).

Enter inputs:
Number of packs (N)
Matching condition (face, suit, or both)