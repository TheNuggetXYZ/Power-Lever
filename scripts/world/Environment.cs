using System;
using Godot;

namespace PowerLever.scripts.world;

public partial class Environment : Node3D
{
	[Export] private Lamp _lamp;
	[Export] private PowerBox _powerBox;

	public Action OnPowerBoxInteract;
	
	public override void _Ready()
	{
		var game = GetTree().CurrentScene as Game;
		game.OnLightsOn += OnLightsOn;
		game.OnLightsOff += OnLightsOff;

		_powerBox.OnInteract += () => { OnPowerBoxInteract?.Invoke(); };
	}

	private void OnLightsOn()
	{
		_lamp.TurnOnOff(true);
	}

	private void OnLightsOff()
	{
		_lamp.TurnOnOff(false);
	}
}