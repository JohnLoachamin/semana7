using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using semana7.Models;
using System.IO;

namespace semana7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        private SQLiteAsyncConnection conn;
        public login()
        {
            InitializeComponent();
            conn = DependencyService.Get<db>().GetConnection();
        }

        public static IEnumerable<estudiante> SELECT_WHERE(SQLiteConnection db,string usuario,string contrasenia)
        {
            return db.Query<estudiante>("Select * from estudiante where usuario=? and contrasenia=?",usuario,contrasenia);

        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "semana7.db3");
                var db = new SQLiteConnection(documentPath);
                db.CreateTable<estudiante>();
                IEnumerable<estudiante> resultado = SELECT_WHERE(db,txtUser.Text,txtContrasenia.Text);
                if(resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultarRegistro());
                }
                else
                {
                    DisplayAlert("Aviso", "Usuario incorrecto", "OK");
                }

            }
            catch (Exception ex)
            {
                DisplayAlert("ERROR",ex.Message,"OK");
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new registroxaml());
        }
    }
}