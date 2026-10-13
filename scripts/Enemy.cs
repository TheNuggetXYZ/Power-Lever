using Godot;

namespace PowerLever.scripts;

public partial class Enemy : Node3D
{
	[Export] private world.Environment _environment;
	[Export] private double _moveCooldown;
	private Marker3D[] _enemyPositions;

	private int _currentPosition;
	private double _moveTimer;
	
	private Game _game;

	public override void _Ready()
	{
		_game = GetTree().CurrentScene as Game;
		_enemyPositions = _environment.EnemyPositions;
	}

	public override void _Process(double delta)
	{
		if (!_game.IsLightOn)
		{
			_moveTimer -= delta;

			if (_moveTimer <= 0)
			{
				Move(1);
				_moveTimer = _moveCooldown;
			}
		}
	}

	private void Move(int indexDelta)
	{
		if (_enemyPositions.Length > 0)
		{
			_currentPosition = Mathf.Clamp(_currentPosition + indexDelta, 0, _enemyPositions.Length - 1);
			GlobalPosition = _enemyPositions[_currentPosition].GlobalPosition;
		}
	}
}