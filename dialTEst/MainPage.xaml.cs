using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace dialTEst {
    public sealed partial class MainPage : Page {
        RadialController radial;
        public MainPage() {
            this.InitializeComponent();

            radial = RadialController.CreateForCurrentView();
            var icon = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/StoreLogo.png"));
            var item = RadialControllerMenuItem.CreateFromKnownIcon("ITWORKS", RadialControllerMenuKnownIcon.Volume);
            radial.Menu.Items.Add(item);

            radial.ButtonClicked += Radial_ButtonClicked;
            radial.RotationChanged += Radial_RotationChanged;
        }

        private void Radial_RotationChanged(RadialController sender, RadialControllerRotationChangedEventArgs args) {
            RadialGaugeControl.Value = Math.Clamp(RadialGaugeControl.Value + args.RotationDeltaInDegrees, 0, 100);
        }

        private void Radial_ButtonClicked(RadialController sender, RadialControllerButtonClickedEventArgs args) {

        }
    }
}
