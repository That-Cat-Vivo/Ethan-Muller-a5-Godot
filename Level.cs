using Godot;
using System;

public partial class Level : Node2D
{
	// Called when the node enters the scene tree for the first time.
	
	[Export]
	PackedScene BallScene;

	[Export]
	Area2D LossBox;

	[Export]
	Node2D BallCollection;

	[Export]
	Marker2D Marker;

	[Export]
	Vector2 Fire;

	[Export]
	Label BallCounter;



    int BallCount;

	bool IsBallAvailable;


    public override void _Ready()
	{
		BallCount = 3;
		IsBallAvailable = true;

        LossBox.BodyEntered += LossBox_BodyEntered;
		RigidBody2D NewBall = BallScene.Instantiate<RigidBody2D>();
            NewBall.Position = Marker.Position;
            BallCollection.AddChild(NewBall);
            NewBall.ApplyCentralImpulse(Fire);
    }

    private void LossBox_BodyEntered(Node2D body)
    {
		if(IsBallAvailable)
		{
            RigidBody2D NewBall = BallScene.Instantiate<RigidBody2D>();
            NewBall.Position = Marker.Position;
            BallCollection.AddChild(NewBall);
            NewBall.ApplyCentralImpulse(Fire);
        }

        body.QueueFree();

		if(BallCount >= 1)
		{
			BallCount--;
		}

		if(BallCount == 0)
		{
			IsBallAvailable = false;
		}
    }
	
	

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
