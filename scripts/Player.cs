using Godot;
using PowerLever.scripts.gui;

namespace PowerLever.scripts;

public partial class Player : Camera3D
{
	[Export] private Canvas _canvas;
	[Export] private float _sensitivity = 0.005f;
	[Export] private Vector2 _lookUpDownRange = new Vector2(-45, 60);
	[Export] private Flashlight _flashlight;

	public override void _Ready()
	{
		_canvas.OnFlashlightToggle += _flashlight.Toggle;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventScreenDrag screenDrag)
		{
			HandleRotation(screenDrag.Relative);
		}

		if (@event is InputEventMouseMotion mouseMotion)
		{
			HandleRotation(mouseMotion.Relative);
		}
			
	}

	private void HandleRotation(Vector2 relative)
	{
		RotateY(-relative.X * _sensitivity);

		Vector3 rot = Rotation;
		rot.X -= relative.Y * _sensitivity;
		rot.X = Mathf.Clamp(rot.X, Mathf.DegToRad(_lookUpDownRange.X), Mathf.DegToRad(_lookUpDownRange.Y));
            
		Rotation = rot;
	}
}