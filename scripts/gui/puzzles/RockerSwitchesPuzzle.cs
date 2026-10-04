using System.Linq;
using Godot;

namespace PowerLever.scripts.gui.puzzles;

public partial class RockerSwitchesPuzzle : Puzzle
{
	[Export] private RockerSwitch[] _switches;

	public override bool IsSolved()
	{
		return _switches.All(rockerSwitch => rockerSwitch.IsSolved());
	}
}