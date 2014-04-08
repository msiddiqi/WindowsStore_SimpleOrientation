WindowsStore_SimpleOrientation
==============================

The code for the blogpost introducing App orientation transitions for Windows Store App. It uses SimpleOrientationSensor for these transitions.

The project uses Prism for Windows Store App for restoring application state for resuming from suspension state and auto-wiring view model to MainPage. 

Reactive Extensions (Rx) is used to throttle the orientation changed events from the sensor.

Behavior SDK (XAML)'s DataTriggerBehavior triggers the state transitions based on the orientation changed notifications from the sensor. It uses GoToStateAction from the same extension SDK to transition the the appropriate state.
