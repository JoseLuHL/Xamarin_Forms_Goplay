﻿using PropertyApp;
using PropertyApp.VistaModelo;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;

namespace WorkingWithMaps
{
    public partial class PinPage : ContentPage
    {
        //List<Pin> boardwalkPin;
        MainPageVistaModel contexto => ((MainPageVistaModel)BindingContext);
        public PinPage()
        {
            InitializeComponent();
            //contexto.PropertyTypeList
            map.IsShowingUser = true;
            
            //Pin boardwalkPin = new Pin
            //{
            //    Position = new Position(5.687629, -76.659698),
            //    Label = "Chocó",
            //    Address = "Quibdo",
            //    Type = PinType.Place
            //};

            //map.Pins.Add(boardwalkPin);
        
        }

        protected override void OnAppearing()
        {
            Cargar();
            
            base.OnAppearing();
        }

        public void Cargar ()
        {
            Pin boardwalkPin = new Pin();
            Pin listPin = new Pin();
            foreach (var item in contexto.PropertyList)
            {
                listPin = new Pin
                {
                    Position = new Position(item.Lat, item.Lng),
                    BindingContext = item,
                    AutomationId = item.Id,
                    Label = item.Price,
                    Address = item.Space,
                    Type = PinType.Place
                };

                //listPin.MarkerClicked += OnMarkerClickedAsync;
                listPin.InfoWindowClicked += OnInfoWindowClickedAsync;
                map.Pins.Add(listPin);
            }


            //boardwalkPin.MarkerClicked += OnMarkerClickedAsync;


            //Pin wharfPin = new Pin
            //{
            //    Position = new Position(5.6845709, -76.6540463),
            //    Label = "Chocó",
            //    Address = "Quibdo",
            //    Type = PinType.Place
            //};

            // wharfPin = new Pin
            //{
            //    Position = new Position(5.68628372017091, -76.66052389815435),
            //    Label = "Chocó",
            //    Address = "Quibdo",
            //    Type = PinType.Place
            //};
            //wharfPin.InfoWindowClicked += OnInfoWindowClickedAsync;


            ////map.Pins.Add(wharfPin);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Cargar();
        }

        async void OnMarkerClickedAsync(object sender, PinClickedEventArgs e)
        {
            e.HideInfoWindow = true;
            string pinName = ((Pin)sender).Label;
            await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
        }

        async void OnInfoWindowClickedAsync(object sender, PinClickedEventArgs e)
        {
            var property = (sender as View).BindingContext as WorkingWithMaps.Modelo.Property;
            string pinName = ((Pin)sender).Label;
            await DisplayAlert("", property.Price , "Ok");
            await Navigation.PushAsync(new DetailsPage(property));
        }
    }
}
