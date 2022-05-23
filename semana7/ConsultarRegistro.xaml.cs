using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using semana7.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace semana7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarRegistro : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private ObservableCollection<Models.estudiante> tablaEstudiante;
        public ConsultarRegistro()
        {
            InitializeComponent();
            conn = DependencyService.Get<db>().GetConnection();
            this.get();
        }
        
        public async void get()
        {
            var resultado = await conn.Table<Models.estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Models.estudiante>(resultado);
            ListarUsuarios.ItemsSource = tablaEstudiante;

        }
        private void ListarUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (estudiante)e.SelectedItem;
            var Item = obj.id.ToString();
            int id = Convert.ToInt32(Item);
            var _Nombre = obj.nombre.ToString();
            string nombre = _Nombre.ToString();

            var _Usuario= obj.usuario.ToString();
            string usuario = _Usuario.ToString();

            var _Contrasenia = obj.contrasenia.ToString();
            string contrasenia = _Contrasenia.ToString();
            Navigation.PushAsync(new elemento(id, nombre,usuario, contrasenia));

        }
    }
}