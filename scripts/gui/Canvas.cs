using Godot;
using System;
using PowerLever.scripts.gui.puzzles;

namespace PowerLever.scripts.gui;

public partial class Canvas : CanvasLayer
{
	[Export] private world.Environment _environment;
	[Export] private PackedScene[] _puzzleScenes;
	[Export] private Control _puzzleParent;
	[Export] private BaseButton _submitButton;
	
	private bool _lightsOn = true;
	private bool _puzzleOpen = false;
	private Puzzle _puzzle;
	
	private Game _game;
	
	public override void _Ready()
	{
		_game = GetTree().CurrentScene as Game;
		_game.OnLightsOn += OnLightsOn;
		_game.OnLightsOff += OnLightsOff;
		
		_environment.OnPowerBoxInteract += TryShowPuzzle;
		_submitButton.Pressed += SubmitButtonOnPressed;
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
		if (_lightsOn || _puzzleOpen)
			return;

		_puzzle = _puzzleScenes[GD.RandRange(0, _puzzleScenes.Length - 1)].Instantiate() as Puzzle;
		_puzzleParent.AddChild(_puzzle);
		_puzzleParent.Show();
		_puzzleOpen = true;
	}

	private void SubmitButtonOnPressed()
	{
		if (!_puzzle.IsSolved())
			return;
		
		OnPuzzleSolved();
	}

	private void OnPuzzleSolved()
	{
		_puzzleParent.Hide();
		_puzzleOpen = false;
		_puzzle.QueueFree();
		_puzzle = null;
		_game.OnPuzzleSolved();
	}
}
