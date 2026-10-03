using Godot;
using System;
using PowerLever.scripts.gui.puzzles;

namespace PowerLever.scripts.gui;

public partial class Canvas : CanvasLayer
{
	[Export] private world.Environment _environment;
	[Export] private PackedScene[] _puzzleScenes;
	[Export] private Control _puzzleParent;
	
	private bool _lightsOn = true;
	
	private Game _game;
	
	public override void _Ready()
	{
		_game = GetTree().CurrentScene as Game;
		_game.OnLightsOn += OnLightsOn;
		_game.OnLightsOff += OnLightsOff;
		
		_environment.OnPowerBoxInteract += TryShowPuzzle;
	}

	private void OnLightsOff()
	{
		_lightsOn = false;
	}

	private void OnLightsOn()
	{
		_lightsOn = true;
	}

	private void TryShowPuzzle()
	{
		if (_lightsOn)
			return;

		var puzzle = _puzzleScenes[GD.RandRange(0, _puzzleScenes.Length - 1)].Instantiate() as Puzzle;
		puzzle.OnSolved += OnSolved;
		_puzzleParent.AddChild(puzzle);
		_puzzleParent.Show();
	}

	private void OnSolved()
	{
		_game.OnPuzzleSolved();
	}
}
