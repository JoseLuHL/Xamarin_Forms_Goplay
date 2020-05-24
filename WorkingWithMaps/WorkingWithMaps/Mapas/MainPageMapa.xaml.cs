using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WorkingWithMaps
{
    public partial class MainPageMapa : ContentPage
    {
        public ICommand NavigateCommand { get; set; }

        public MainPageMapa()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });

            BindingContext = this;
        }
    }
}