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

	public override void _Ready()
	{
        LossBox.BodyEntered += LossBox_BodyEntered;
		RigidBody2D NewBall = BallScene.Instantiate<RigidBody2D>();
            NewBall.Position = Marker.Position;
            BallCollection.AddChild(NewBall);
            NewBall.ApplyCentralImpulse(Fire);
    }

    private void LossBox_BodyEntered(Node2D body)
    {
        RigidBody2D NewBall = BallScene.Instantiate<RigidBody2D>();
        NewBall.Position = Marker.Position;
        BallCollection.AddChild(NewBall);
        NewBall.ApplyCentralImpulse(Fire);

        body.QueueFree();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		
	}
}
