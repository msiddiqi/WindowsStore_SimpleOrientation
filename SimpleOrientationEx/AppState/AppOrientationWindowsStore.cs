namespace SimpleOrientationEx.AppState
{
    using SimpleOrientationEx.Portable;
    using SimpleOrientationEx.Portable.Enums;
    using System;
    using System.Reactive.Linq;
    using System.Threading;
    using Windows.Devices.Sensors;
    using Windows.Foundation;

    public class AppOrientationWindowsStore : AppOrientationBase
    {
        #region Fields

        private readonly SimpleOrientationSensor _simpleOrientationSensor;

        #endregion Fields

        #region Constructors
        
        public AppOrientationWindowsStore(SimpleOrientationSensor simpleOrientationSensor)
        {
            _simpleOrientationSensor = simpleOrientationSensor;

            Observable
                .FromEventPattern<TypedEventHandler<SimpleOrientationSensor, SimpleOrientationSensorOrientationChangedEventArgs>,
                    SimpleOrientationSensorOrientationChangedEventArgs>(
                        handler => _simpleOrientationSensor.OrientationChanged += handler,
                        handler => _simpleOrientationSensor.OrientationChanged -= handler)             
                .Throttle(TimeSpan.FromSeconds(1))
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(args => UpdateOrientation(MapOrientation(args.EventArgs.Orientation)));
        }

        #endregion Constructors

        private AppOrientationState MapOrientation(SimpleOrientation orientation)
        {
            AppOrientationState orientationState;
            switch(orientation)
            {
                case SimpleOrientation.NotRotated:
                    orientationState = AppOrientationState.Landscape;
                    break;
                
                case SimpleOrientation.Rotated90DegreesCounterclockwise:
                    orientationState = AppOrientationState.Portrait;
                    break;

                case SimpleOrientation.Rotated180DegreesCounterclockwise:
                    orientationState = AppOrientationState.ContraLandscape;
                    break;

                case SimpleOrientation.Rotated270DegreesCounterclockwise:
                    orientationState = AppOrientationState.ContraPortrait;
                    break;

                case SimpleOrientation.Faceup:
                    orientationState = AppOrientationState.Up;
                    break;

                case SimpleOrientation.Facedown:
                    orientationState = AppOrientationState.Down;
                    break;

                default:
                    orientationState = AppOrientationState.Landscape;
                    break;
            }

            return orientationState;
        }
    }
}
