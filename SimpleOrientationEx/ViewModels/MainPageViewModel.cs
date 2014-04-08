namespace SimpleOrientationEx.ViewModels
{
    using Microsoft.Practices.Prism.StoreApps;
    using SimpleOrientationEx.AppState;
    using SimpleOrientationEx.Portable.Interfaces;
    using Windows.Devices.Sensors;

    public class MainPageViewModel : ViewModel
    {
        #region Fields

        private string _textEntered;
        
        #endregion Fields
        //Update to use unity container
        public MainPageViewModel() : this(new AppOrientationWindowsStore(SimpleOrientationSensor.GetDefault()))
        {
        }

        private MainPageViewModel(IAppOrientation appOrientation)
        {
            Orientation = appOrientation;
        }

        #region Properties

        public IAppOrientation Orientation { get; private set; }

        [RestorableState]
        public string TextEntered
        {
            get { return _textEntered; }
            set
            {
                this.SetProperty<string>(ref _textEntered, value);
            }
        }

        #endregion
    }
}
