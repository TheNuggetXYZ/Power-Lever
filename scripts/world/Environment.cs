using Godot;

namespace PowerLever.scripts.world;

public partial class Environment : Node3D
{
	[Export] private Lamp _lamp;
	
	public override void _Ready()
	{
		var game = GetTree().CurrentScene as Game;
		game.OnLightsOn += OnLightsOn;
		game.OnLightsOff += OnLightsOff;
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