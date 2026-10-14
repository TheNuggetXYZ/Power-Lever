using Godot;
using System;

namespace PowerLever.scripts.world;

public partial class PowerBox : Node3D
{
	[Export] private Area3D _interactArea;

	public Action OnInteract;

	public override void _Ready()
	{
		_interactArea.InputEvent += InteractAreaOnInputEvent;
	}

	private void InteractAreaOnInputEvent(Node camera, InputEvent @event, Vector3 eventPosition, Vector3 normal, long shapeIdx)
	{
		// Mouse input doesn't get fired when mouse mode is set to captured
		// TODO: Implement this with a raycast
		// if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed && mouseButton.ButtonIndex == MouseButton.Left)
		// {
		// 	TriggerTap();
		// }
		
		if (@event is InputEventScreenTouch screenTouch && screenTouch.Pressed)
		{
			TriggerTap();
		}
	}

	private void TriggerTap()
	{
		OnInteract?.Invoke();
	}
}
