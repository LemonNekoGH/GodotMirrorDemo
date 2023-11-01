using Godot;

namespace SimpleMirrorDemo;

public partial class Main : Node3D
{
    private Camera3D _mirrorCamera;
    private Camera3D _playerCamera;
    private Node3D _mirror;

    public override void _Ready()
    {
        _mirrorCamera = FindChild("SingleCamera") as Camera3D;
        _playerCamera = FindChild("PlayerCamera") as Camera3D;

        _mirror = FindChild("Mirror") as Node3D;
    }

    public override void _Process(double delta)
    {
        _mirrorCamera.Rotation = new Vector3(0, Mathf.Pi - _playerCamera.GlobalRotation.Y, 0);

        var lengthToMirror = (_mirror.GlobalPosition - _playerCamera.GlobalPosition).Dot(_mirror.Transform.Basis.Z);
        var normalVectorScaled = _mirror.Transform.Basis.Z * - lengthToMirror; 
        
        _mirrorCamera.GlobalPosition = _playerCamera.GlobalPosition - normalVectorScaled * 2;
    }
}