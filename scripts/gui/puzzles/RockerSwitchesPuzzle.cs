using System.Linq;
using Godot;

namespace PowerLever.scripts.gui.puzzles;

public partial class RockerSwitchesPuzzle : Puzzle
{
	[Export] private RockerSwitch[] _switches;

	public override void _Ready()
	{
		foreach (RockerSwitch r in _switches)
		{
			r.SetState(GD.Randf() < 0.5f);
		}
	}

	public override bool IsSolved()
	{
		return _switches.All(rockerSwitch => rockerSwitch.IsSolved());
	}
}