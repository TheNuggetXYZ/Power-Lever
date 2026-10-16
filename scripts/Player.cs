using Godot;
using PowerLever.scripts.gui;
using PowerLever.scripts.world;

namespace PowerLever.scripts;

public partial class Player : Camera3D
{
	[Export] private Canvas _canvas;
	[Export] private float _sensitivity = 0.005f;
	[Export] private Vector2 _lookUpDownRange = new Vector2(-45, 60);
	[Export] private Flashlight _flashlight;
	[Export] private RayCast3D _rayCast;

	public override void _Ready()
	{
		_canvas.OnFlashlightToggle += _flashlight.Toggle;
		
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("interact"))
			InteractRayCastCheck();
	}

	private void InteractRayCastCheck()
	{
		if (!_rayCast.IsColliding())
			return;
		
		var collider = (CollisionObject3D)_rayCast.GetCollider();
		var owner = collider.Owner;

		if (owner is PowerBox powerBox)
		{
			GD.Print("power box");
			powerBox.OnInteract?.Invoke();
		}
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