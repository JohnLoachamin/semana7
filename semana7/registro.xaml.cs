using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace semana7.Models
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registroxaml : ContentPage
    {
        private SQLiteAsyncConnection conn;
        public registroxaml()
        {
            InitializeComponent();
            conn = DependencyService.Get<db>().GetConnection();
        }

        private void btnCrear_Clicked(object sender, EventArgs e)
        {
            var datosRegistro = new Models.estudiante { nombre = txtNombre.Text, usuario = txtUsuario.Text, contrasenia = txtContrasenia.Text };
            conn.InsertAsync(datosRegistro);
            this.txtNombre.Text = "";
            this.txtUsuario.Text = "";
            this.txtContrasenia.Text = "";
            DisplayAlert("Aviso","Se agregó correctamente","OK");
            Navigation.PushAsync(new login());
        }
    }
}