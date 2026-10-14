using Godot;
using System;
using PowerLever.scripts.gui.puzzles;

namespace PowerLever.scripts.gui;

public partial class Canvas : CanvasLayer
{
	[Export] private world.Environment _environment;
	[Export] private PackedScene[] _puzzleScenes;
	[Export] private Control _puzzleParent;
	[Export] private Control _puzzlePanel;
	[Export] private Control _flashlightPanel;
	[Export] private BaseButton _flashlightButton;
	[Export] private SubmitLever _submitLever;
	
	private bool _lightsOn = true;
	private bool _puzzleOpen = false;
	private Puzzle _puzzle;

	public Action<bool> OnFlashlightToggle;
	
	private Game _game;
	
	public override void _Ready()
	{
		_game = GetTree().CurrentScene as Game;
		_game.OnLightsOn += OnLightsOn;
		_game.OnLightsOff += OnLightsOff;
		
		_environment.OnPowerBoxInteract += TryShowPuzzle;
		_submitLever.OnPressed += SubmitLeverOnPressed;
		_flashlightButton.Toggled += FlashlightButtonOnToggled;
		
		FlashlightButtonOnToggled(_flashlightButton.ButtonPressed);
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
		_puzzlePanel.Show();
		_flashlightPanel.Hide();
		_puzzleOpen = true;
	}

	private void SubmitLeverOnPressed()
	{
		if (_puzzle != null && _puzzle.IsSolved())
			OnPuzzleSolved();
	}

	private void FlashlightButtonOnToggled(bool on)
	{
		OnFlashlightToggle?.Invoke(on);
	}

	private void OnPuzzleSolved()
	{
		_puzzlePanel.Hide();
		_flashlightPanel.Show();
		_puzzleOpen = false;
		_puzzle.QueueFree();
		_puzzle = null;
		_game.OnPuzzleSolved();
	}
}
