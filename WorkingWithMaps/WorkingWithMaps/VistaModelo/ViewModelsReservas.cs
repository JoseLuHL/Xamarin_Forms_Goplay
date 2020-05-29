namespace PlacesApp.ViewModels
{
    class ViewModelsReservas : MvvmHelpers.BaseViewModel
    {
        public ViewModelsReservas()
        {

        }
        private string nombre="Hola Soy una prueba";

        public string Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }

        
    }
}
