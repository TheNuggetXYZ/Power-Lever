using Godot;

namespace PowerLever.scripts.gui.puzzles;

public partial class Valve : Control
{
	[Export] private TextureRect _texture;
	private bool _isDragging;
	
	public override void _GuiInput(InputEvent @event)
	{
		if (@event is InputEventScreenTouch eventScreenTouch)
		{
			_isDragging = eventScreenTouch.Pressed;
		}
		else if (@event is InputEventMouseButton eventMouseButton)
		{
			_isDragging = eventMouseButton.Pressed;
		}

		if (_isDragging && (@event is InputEventMouseMotion eventMouseMotion ||
		                    @event is InputEventScreenDrag eventScreenDrag))
		{
			Vector2 globalMousePos = _texture.GetGlobalMousePosition();
            
			Vector2 direction = globalMousePos - GlobalPosition;

			_texture.Rotation = direction.Angle();
		}
	}
}