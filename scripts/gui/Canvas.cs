using Godot;
using System;

namespace PowerLever.scripts.gui;

public partial class Canvas : CanvasLayer
{
	[Export] private world.Environment _environment;
	
	public override void _Ready()
	{
		_environment.OnPowerBoxInteract += TryShowPuzzle;
	}

	private void TryShowPuzzle()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
