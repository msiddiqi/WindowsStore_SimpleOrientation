namespace SimpleOrientationEx.Portable.Enums
{
    using System.ComponentModel;

    [DefaultValue(Landscape)]
    public enum AppOrientationState
    {
        Down,
        Up,
        Landscape,
        Portrait,
        ContraLandscape,
        ContraPortrait
    }
}
