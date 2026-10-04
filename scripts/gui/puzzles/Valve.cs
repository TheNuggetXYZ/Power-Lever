using Godot;

namespace PowerLever.scripts.gui.puzzles;

public partial class Valve : Control
{
	[Export] private TextureRect _texture;
	private bool _isDragging;
	private float _previousAngle = 0.0f;
	
	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventScreenTouch eventScreenTouch)
		{
			_isDragging = eventScreenTouch.Pressed;
			
			Vector2 globalMousePos = _texture.GetGlobalMousePosition();
			Vector2 direction = globalMousePos - GlobalPosition;
			_previousAngle = direction.Angle();
		}
		else if (@event is InputEventMouseButton eventMouseButton)
		{
			_isDragging = eventMouseButton.Pressed;
			
			Vector2 globalMousePos = _texture.GetGlobalMousePosition();
			Vector2 direction = globalMousePos - GlobalPosition;
			_previousAngle = direction.Angle();
		}

		if (_isDragging && (@event is InputEventMouseMotion eventMouseMotion ||
		                    @event is InputEventScreenDrag eventScreenDrag))
		{
			Vector2 globalMousePos = _texture.GetGlobalMousePosition();
            
			Vector2 direction = globalMousePos - GlobalPosition;

			float currentAngle = direction.Angle();
                
			float angleDelta = currentAngle - _previousAngle;
                
			// angle wrapping
			if (angleDelta > Mathf.Pi) angleDelta -= Mathf.Tau;
			if (angleDelta < -Mathf.Pi) angleDelta += Mathf.Tau;

			_texture.Rotation += angleDelta;

			_previousAngle = currentAngle;
		}
	}
}