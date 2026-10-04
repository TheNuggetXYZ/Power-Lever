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

	public bool IsSolved()
	{
		return _targetSector.StartAngleDeg < _valve.RotationDegrees &&
		       _valve.RotationDegrees < _targetSector.EndAngleDeg;
	}
}