using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarTareas : ContentPage
    {
        public EditarTareas(string titulo, string descripcion, DateTime fecha, string estado, string categoria, string color)
        {
            InitializeComponent();

            // Usar los datos pasados como parámetros para inicializar el formulario
            txtTitulo.Text = titulo;
            txtDescripcion.Text = descripcion;
            datePickerFecha.Date = fecha;
            pickerEstado.SelectedItem = estado;
            pickerCategoria.SelectedItem = categoria;
            pickerColor.SelectedItem = color;
        }
    }
}
