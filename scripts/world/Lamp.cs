using Godot;

namespace PowerLever.scripts.world;

public partial class Lamp : Node3D
{
	[Export] private Light3D[] _lights;
	[Export] private Node3D _bulbOn;
	[Export] private Node3D _bulbOff;
	
	public void TurnOnOff(bool on)
	{
		foreach (var l in _lights)
			l.Visible = on;
		
		_bulbOn.Visible = on;
		_bulbOff.Visible = !on;
	}
}