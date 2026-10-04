using System;
using Godot;

namespace PowerLever.scripts.gui.puzzles;

public abstract partial class Puzzle : Control
{
    public abstract bool IsSolved();
}