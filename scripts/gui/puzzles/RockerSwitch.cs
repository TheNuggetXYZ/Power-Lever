using Godot;

namespace PowerLever.scripts.gui.puzzles;

public partial class RockerSwitch : Control
{
	[Export] private BaseButton _button;
	
	public bool IsSolved()
	{
		return _button.ButtonPressed;
	}
}