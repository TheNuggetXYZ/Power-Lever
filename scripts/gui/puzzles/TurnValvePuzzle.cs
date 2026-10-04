using System.Linq;
using Godot;

namespace PowerLever.scripts.gui.puzzles;

public partial class TurnValvePuzzle : Puzzle
{
	[Export] private TurnValve[] _turnValves;

	public override void _Ready()
	{
		foreach (TurnValve turnValve in _turnValves)
		{
			float angleRange = GD.RandRange(30, 90);
			float startAngle = (float)GD.RandRange(0f, 360f - angleRange);
			turnValve.SetTargetSector(startAngle, startAngle + angleRange);

			float angle = GD.RandRange(0, 360);
			turnValve.SetAngleDegrees(angle);
		}
	}

	public override bool IsSolved()
	{
		return _turnValves.All(x => x.IsSolved());
	}
}