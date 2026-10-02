using System;
using Godot;

namespace PowerLever.scripts;

public partial class Game : Node3D
{
	[Export] private Timer _lightTimer;
	[Export] private Vector2 _lightCooldownRange;
	[Export] private float _initialLightCooldown;
	
	public Action OnLightsOn;
	public Action OnLightsOff;

	public override void _Ready()
	{
		_lightTimer.Timeout += LightTimerOnTimeout;
		_lightTimer.Start(_initialLightCooldown);
	}

	public override void _Process(double delta)
	{
		
	}

	private void LightTimerOnTimeout()
	{
		OnLightsOff?.Invoke();
	}

	public void OnPuzzleSolved()
	{
		_lightTimer.Start(GD.RandRange(_lightCooldownRange.X, _lightCooldownRange.Y));
		OnLightsOn?.Invoke();
	}
}