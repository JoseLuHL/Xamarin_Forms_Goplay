using MvvmHelpers;
using Xamarin.Forms;

namespace TailwindTraders.Mobile.Framework
{
    public abstract class BaseContentPage<T> : ContentPage
        where T : BaseViewModel
    {
        private bool isAlreadyInitialized;
        private bool isAlreadyUninitialized;

        protected virtual T ViewModel => BindingContext as T;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!isAlreadyInitialized)
            {
                isAlreadyInitialized = true;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (!isAlreadyUninitialized)
            {
                isAlreadyUninitialized = true;
            }
        }
    }
}
