using Godot;

namespace PowerLever.scripts.gui.puzzles;

public partial class TurnValve : Control
{
	[Export] private Valve _valve;
	[Export] private RingSector _targetSector;

	public void SetTargetSector(float startAngle, float endAngle)
	{
		_targetSector.StartAngleDeg = startAngle;
		_targetSector.EndAngleDeg = endAngle;
	}

	public void SetAngleDegrees(float angle)
	{
		_valve.SetAngleDegrees(angle);
	}

	public bool IsSolved()
	{
		return _targetSector.StartAngleDeg < _valve.GetAngleDegrees() &&
		       _valve.GetAngleDegrees() < _targetSector.EndAngleDeg;
	}
}