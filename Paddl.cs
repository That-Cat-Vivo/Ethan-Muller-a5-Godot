using Godot;
using System;

public partial class Paddl : AnimationPlayer
{
	[Export] AnimationPlayer animPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (Input.IsActionJustPressed("paddle_left"))
        {
            animPlayer.Play("paddle");
        }
    }

  
}
