using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class elemento : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private int IdSeleccionado;
        IEnumerable<Models.estudiante> Eliminar;
        IEnumerable<Models.estudiante> Actualizar;
        public elemento(int id, string nombre, string usuario, string contrasenia)
        {
            InitializeComponent();
            IdSeleccionado = id;
            txtNombre.Text = nombre;
            txtUsuario.Text = usuario;
            txtContrasenia.Text = contrasenia;
        }

        public static IEnumerable<estudiante> delete(SQLiteConnection db, int ID)
        {
            return db.Query<estudiante>("delete from estudiante where id=?", ID);
        }

        public static IEnumerable<estudiante> update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int ID)
        {
            return db.Query<estudiante>("update estudiante set nombre=?, usuario=?, contrasenia=? where id=?", nombre, usuario, contrasenia,ID);
        }

        private void bntActualizar_Clicked(object sender, EventArgs e)
        {
            try { 
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "semana7.db3");
                var _db = new SQLiteConnection(databasePath);
                Actualizar = update(_db,txtNombre.Text,txtUsuario.Text,txtContrasenia.Text,IdSeleccionado);
                DisplayAlert("Aviso","Datos actualzados con éxito","Ok");
                Navigation.PushAsync(new ConsultarRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("ERROR", "Error al actualizar. " + ex, "OK");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "semana7.db3");
                var _db = new SQLiteConnection(databasePath);
                Eliminar = delete(_db, this.IdSeleccionado);
                DisplayAlert("Aviso", "Dato eliminado con éxito", "Ok");
                Navigation.PushAsync(new ConsultarRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("ERROR", "Error al eliminar. " + ex, "OK");
            }
        }
    }
}