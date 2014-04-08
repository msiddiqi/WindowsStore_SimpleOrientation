
namespace SimpleOrientationEx.Portable
{
    using SimpleOrientationEx.Portable.Enums;
    using SimpleOrientationEx.Portable.Interfaces;

    public abstract class AppOrientationBase : NotifyPropertyChanged, IAppOrientation
    {
        AppOrientationState _currentOrientation;
        public AppOrientationState CurrentOrientation
        {
            get { return _currentOrientation;}
            private set
            {
                if (_currentOrientation == value)
                {
                    return;
                }

                _currentOrientation = value;
                OnPropertyChanged(() => CurrentOrientation);
            }
        }

        protected void UpdateOrientation(AppOrientationState orientation)
        {
            CurrentOrientation = orientation;
        }
    }
}
