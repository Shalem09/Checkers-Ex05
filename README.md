# Checkers (C# / OOP)

Checkers game implemented in C# with a separated game engine (library) and UIs (console + windows app).

## Projects
- **CheckersLibrary** – game engine (rules, board, move validation)
- **CheckersConsoleUI** – console UI
- **CheckersWindowsApp** – windows UI

## How to Run
1. Open `CheckersLibrary.sln` in Visual Studio
2. Choose startup project: `CheckersConsoleUI` or `CheckersWindowsApp`
3. Run

## Architecture (high level)
- Engine is independent from UI (separation of concerns)
- UI only handles input/output and calls the engine

## Next steps
- Add unit tests for the engine
- Add CI (build + tests) with GitHub Actions
