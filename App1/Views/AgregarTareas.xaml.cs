using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarTareas : ContentPage
    {
        public AgregarTareas()
        {
            InitializeComponent();

            // Arrays para los Pickers
            string[] estados = { "Pendiente", "En Progreso", "Completada" };
            string[] categorias = { "Tareas Principales", "Tareas Secundarias" };
            string[] colores = { "Azul", "Rojo", "Verde", "Amarillo", "Morado" };

            // Asignar los arrays a los Pickers
            estadoPicker.ItemsSource = estados;
            categoriaPicker.ItemsSource = categorias;
            colorPicker.ItemsSource = colores;
        }


        private async void ButtonAgregarTarea_Clicked(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            string titulo = tituloEntry.Text;
            string descripcion = descripcionEditor.Text;
            DateTime fecha = fechaDatePicker.Date;
            string estado = estadoPicker.SelectedItem as string;
            string categoria = categoriaPicker.SelectedItem as string;
            string color = colorPicker.SelectedItem as string;

            // Crear una instancia del ViewModel para interactuar con la API REST
            ViewModels.ViewModels viewModel = new ViewModels.ViewModels();

            try
            {
                // Llamar al método del ViewModel para agregar una nueva tarea
                string resultado = await viewModel.CrearDatos(titulo, descripcion, fecha, estado, categoria, color);

                // Mostrar mensaje de éxito
                await DisplayAlert("Éxito", resultado, "OK");

                // Limpiar los campos del formulario
                LimpiarCampos();

                // Regresar a la página anterior (pop)
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra
                await DisplayAlert("Error", "Hubo un error al agregar la tarea: " + ex.Message, "OK");
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            tituloEntry.Text = string.Empty;
            descripcionEditor.Text = string.Empty;
            fechaDatePicker.Date = DateTime.Now;
            estadoPicker.SelectedIndex = -1;
            categoriaPicker.SelectedIndex = -1;
            colorPicker.SelectedIndex = -1;
        }
    }
}