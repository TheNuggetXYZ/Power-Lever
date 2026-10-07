using Godot;
using System;

namespace PowerLever.scripts.gui.puzzles;

public partial class SubmitLever : Control
{
	[Export] private TextureRect _textureRect;
	[Export] private VSlider _slider;
	[Export] private Texture2D[] _textures;
	[Export] private int _pressedTextureIndex;
	
	[Export] private double _moveBackCooldown;
	private double _moveBackTimer;

	[Export] private double _sliderStoppedThreshold;
	private double _timeSinceLastMovement;
	private bool _isMoving;
	
	private int _textureIndex;
	
	public Action OnPressed;

	public override void _Ready()
	{
		_slider.MaxValue = _textures.Length - 1;
		_slider.Value = _textures.Length - 1;
		_slider.Rounded = true;
		
		_textureRect.Texture = _textures[0];
		
		_slider.ValueChanged += SliderOnValueChanged;
	}

	public override void _Process(double delta)
	{
		_timeSinceLastMovement += delta;
		
		if (_timeSinceLastMovement > _sliderStoppedThreshold)
			_isMoving = false;
		else
			_isMoving = true;

		if (!_isMoving)
		{
			_moveBackTimer -= delta;
			if (_moveBackTimer <= 0)
			{
				MoveLeverBack();
				_moveBackTimer = _moveBackCooldown;
			}
		}

		if (_textureIndex >= _pressedTextureIndex)
			OnPressed?.Invoke();
	}

	private void MoveLeverBack()
	{
		_textureIndex--;
		if (_textureIndex < 0)
			_textureIndex = 0;
		
		_textureRect.Texture = _textures[_textureIndex];
	}

	private void SliderOnValueChanged(double value)
	{
		// reverse the value, because first texture is when lever is up which is when slider is at its max value
		_textureIndex = _textures.Length - 1 - (int)value;
		_textureRect.Texture = _textures[_textureIndex];
		_timeSinceLastMovement = 0;
	}
}
