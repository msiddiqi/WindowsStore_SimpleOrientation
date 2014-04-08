namespace SimpleOrientationEx.Portable.Interfaces
{
    using SimpleOrientationEx.Portable.Enums;

    public interface IAppOrientation
    {
        AppOrientationState CurrentOrientation { get; }
    }
}
