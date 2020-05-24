using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WorkingWithMaps
{
    public partial class MapPropertiesPage : ContentPage
    {
        public MapPropertiesPage()
        {
            InitializeComponent();

            scrollEnabledCheckBox.CheckedChanged += OnCheckBoxCheckedChanged;
            zoomEnabledCheckBox.CheckedChanged += OnCheckBoxCheckedChanged;
            moveRegionCheckBox.CheckedChanged += OnCheckBoxCheckedChanged;
            var po = new Position(39.8283459, -98.5794797);
            var MapSpan = new MapSpan(po, 39.8283459, -98.5794797);
            map.MoveToRegion(MapSpan);
            var pin = new Pin();
            pin.Position = po; ;
            var defaultPin = new Pin { Type = PinType.Place, Label = "This is my home", Address = "Here", Position = new Position(-23.68, -46.87) };
            map.Pins.Add(defaultPin);
        }
            //map.reg.Center.Latitude = 0;

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }

        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.StyleId)
            {
                case "scrollEnabledCheckBox":
                    map.HasScrollEnabled = !map.HasScrollEnabled;
                    break;
                case "zoomEnabledCheckBox":
                    map.HasZoomEnabled = !map.HasZoomEnabled;
                    break;
                case "showUserCheckBox":
                    map.IsShowingUser = !map.IsShowingUser;
                    break;
                case "moveRegionCheckBox":
                    map.MoveToLastRegionOnLayoutChange = !map.MoveToLastRegionOnLayoutChange;
                    break;
            }
        }
    }
}
