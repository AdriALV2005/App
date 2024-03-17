using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescripcionTareas : ContentPage
    {
        public DescripcionTareas()
        {
        }

        public DescripcionTareas(string titulo, string descripcion, DateTime fecha, string estado, string categoria, string color)
        {
            InitializeComponent();

            // Usa los datos recibidos para inicializar los controles en esta página
            tituloLabel.Text = titulo;
            descripcionLabel.Text = descripcion;
            fechaLabel.Text = fecha.ToString("D");
            estadoLabel.Text = estado;
            categoriaLabel.Text = categoria;
            colorLabel.Text = color;
        }

        // Otros constructores, métodos y propiedades de la clase...
    



    private async void buttonRegreso(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tareas());
        }
    }
}
