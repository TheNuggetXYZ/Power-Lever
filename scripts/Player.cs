using Godot;

namespace PowerLever.scripts;

public partial class Player : Camera3D
{
	[Export] private float _sensitivity = 0.005f;
	[Export] private Vector2 _lookUpDownRange = new Vector2(-45, 60);

	public override void _Ready()
	{
		Input.EmulateTouchFromMouse = true;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventScreenDrag screenDrag)
		{
			RotateY(-screenDrag.Relative.X * _sensitivity);

			Vector3 rot = Rotation;
			rot.X -= screenDrag.Relative.Y * _sensitivity;
			rot.X = Mathf.Clamp(rot.X, Mathf.DegToRad(_lookUpDownRange.X), Mathf.DegToRad(_lookUpDownRange.Y));
            
			Rotation = rot;
		}
	}
}