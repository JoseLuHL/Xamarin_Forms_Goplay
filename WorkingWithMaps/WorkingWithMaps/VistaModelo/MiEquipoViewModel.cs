using System.Collections.ObjectModel;
using WSGOPLAY.Models.red;
using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms;
using System.Windows.Input;
using PropertyApp.Servicio;
using PropertyApp.url;

namespace PlacesApp.ViewModels.Equipo
{
    public class MiEquipoViewModel : BaseViewModel
    {//MvvmHelpers.BaseViewModel

        private ObservableCollection<WoGroupMembers> groups;

        public ObservableCollection<WoGroupMembers> Groups
        {
            get => groups;
            set => SetProperty(ref groups, value);
        }


        private WoGroups group;
        private bool ocupado;

        public bool Ocupado
        {
            get => ocupado;
            set => SetProperty(ref ocupado, value);
        }

        public WoGroups Group
        {
            get => group;
            set => SetProperty(ref group, value);
        }


        public ICommand EqipoComando
        {
            get
            {
                return new Command<WoGroupMembers>(async (WoGroupMembers group) =>
                {
                    Group = new WoGroups { GroupTitle = group.Grupo.GroupTitle };

                });
            }
        }

        public MiEquipoViewModel()
        {
            load();
            //Group = new WoGroups { Id = 12222 }; 
        }



        private async Task load()
        {
            Ocupado = true;
           GoPlayServicio miEquipo = new GoPlayServicio();
            Groups = await miEquipo.GetDatosAsync<WoGroupMembers>(Url.urlGroup);
            Ocupado = false;
            if (Groups.Count > 0)
            {
                Group = new WoGroups
                {
                    GroupTitle = Groups[0].Grupo.GroupTitle,
                    Avatar = Groups[0].Grupo.Avatar,
                    About = Groups[0].Grupo.About,
                    Id = Groups[0].Id,
                    Cover = Groups[0].Grupo.Cover,
                };
            }
           
            //await Application.Current.MainPage.DisplayAlert("",miEquipo.Error,"OK");
        }
    }
}
