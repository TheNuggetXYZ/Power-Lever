using System.Linq;
using Godot;

namespace PowerLever.scripts;

public partial class Flashlight : Node3D
{
	[Export] private Light3D[] _lights;
	[Export] private Node3D _volumetricLight;

	public void Toggle(bool on)
	{
		foreach (var light in _lights)
			light.Visible = on;
		
		_volumetricLight.Visible = on;
	}
}