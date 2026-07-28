using Godot;

namespace FourthAndFury;

/// <summary>
/// Hello-world "attract screen" that completes work item F1's proof-of-life:
/// a running Godot 4 C# scene. This is deliberately NOT gameplay — F2 stops at
/// the project skeleton. All it does is show the logo, a blinking "PRESS START",
/// and one bouncing football (see <see cref="Football"/>).
/// </summary>
public partial class AttractScreen : Control
{
    private static readonly Color FuryGold = new(1f, 0.78f, 0.15f);
    private static readonly Color Ghost = new(0.75f, 0.78f, 0.85f);

    private Label _pressStart = null!;
    private double _elapsed;

    public override void _Ready()
    {
        var background = new ColorRect { Color = new Color(0.05f, 0.06f, 0.12f) };
        background.SetAnchorsPreset(LayoutPreset.FullRect);
        AddChild(background);

        // One bouncing football behind the text — the "38% more thunder" prop.
        AddChild(new Football { Position = GetViewportRect().Size * 0.5f });

        // Centered logo + prompt stack.
        var stack = new VBoxContainer { Alignment = BoxContainer.AlignmentMode.Center };
        stack.SetAnchorsPreset(LayoutPreset.FullRect);
        stack.AddThemeConstantOverride("separation", 28);
        AddChild(stack);

        var title = new Label
        {
            Text = "FOURTH & FURY",
            HorizontalAlignment = HorizontalAlignment.Center,
        };
        title.AddThemeFontSizeOverride("font_size", 72);
        title.AddThemeColorOverride("font_color", FuryGold);
        stack.AddChild(title);

        _pressStart = new Label
        {
            Text = "PRESS START",
            HorizontalAlignment = HorizontalAlignment.Center,
        };
        _pressStart.AddThemeFontSizeOverride("font_size", 28);
        _pressStart.AddThemeColorOverride("font_color", Ghost);
        stack.AddChild(_pressStart);
    }

    public override void _Process(double delta)
    {
        // Blink the prompt ~ once per second (visible 0.6s, dark 0.4s).
        _elapsed += delta;
        _pressStart.Visible = Mathf.PosMod((float)_elapsed, 1.0f) < 0.6f;
    }
}
