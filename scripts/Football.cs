using Godot;

namespace FourthAndFury;

/// <summary>
/// Attract-screen prop: one football bouncing around the viewport. This is
/// cosmetic proof-of-life only — there is no physics, fatigue, ball security,
/// or any gameplay system here. Those belong to later work items, not F2.
/// </summary>
public partial class Football : Node2D
{
    private static readonly Color Leather = new(0.55f, 0.27f, 0.10f);
    private static readonly Color Lace = new(0.95f, 0.95f, 0.90f);

    private readonly Vector2 _halfExtents = new(34f, 22f);
    private Vector2 _velocity = new(260f, 190f);

    public override void _Process(double delta)
    {
        Vector2 bounds = GetViewportRect().Size;
        Position += _velocity * (float)delta;

        // Reflect off each edge, only when actually heading outward.
        if ((Position.X - _halfExtents.X <= 0f && _velocity.X < 0f) ||
            (Position.X + _halfExtents.X >= bounds.X && _velocity.X > 0f))
        {
            _velocity.X = -_velocity.X;
        }

        if ((Position.Y - _halfExtents.Y <= 0f && _velocity.Y < 0f) ||
            (Position.Y + _halfExtents.Y >= bounds.Y && _velocity.Y > 0f))
        {
            _velocity.Y = -_velocity.Y;
        }

        QueueRedraw();
    }

    public override void _Draw()
    {
        // Ellipse body, approximated by a 32-gon (Godot has no DrawEllipse).
        const int segments = 32;
        var body = new Vector2[segments];
        for (int i = 0; i < segments; i++)
        {
            float angle = Mathf.Tau * i / segments;
            body[i] = new Vector2(Mathf.Cos(angle) * _halfExtents.X, Mathf.Sin(angle) * _halfExtents.Y);
        }
        DrawColoredPolygon(body, Leather);

        // Laces.
        DrawLine(new Vector2(-14f, 0f), new Vector2(14f, 0f), Lace, 2f);
        for (int i = -2; i <= 2; i++)
        {
            DrawLine(new Vector2(i * 6f, -5f), new Vector2(i * 6f, 5f), Lace, 2f);
        }
    }
}
