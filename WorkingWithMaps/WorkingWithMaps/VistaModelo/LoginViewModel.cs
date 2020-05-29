using PropertyApp.Servicio;
using PropertyApp.url;
using System.Threading.Tasks;
using WSGOPLAY.Models.red;

namespace PropertyApp.VistaModelo
{

    public static class  LoginViewModel 
    {
        public static GoPlayServicio servicio { get; set; }

        //public static ObservableCollection<WoUsers> Usuarios { get; set; }

        private static WoUsers usuarios;


        public static WoUsers Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }


      public  static async Task<WoUsers> CargarUsuarioAsync(Usuario usuario)
        {
            servicio = new GoPlayServicio();
            if (usuario != null)
            {
                var usuarios = await servicio.GetDatoAsync<WoUsers>($"{Url.urlUsuario}{usuario.Name}");
                if (usuarios!=null)
                {
                    if (usuarios.Password == usuario.Contraseña)
                    {
                        Usuarios = usuarios;
                    }
                }
            }
            return Usuarios;
        }

    }
}
