using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            string[] categorias = { "Trabajo", "Hogar", "Estudio", "Otro" };
            string[] colores = { "Azul", "Rojo", "Verde", "Amarillo", "Morado", "Blanco", "Negro" };

            // Asignar los arrays a los Pickers
            estadoPicker.ItemsSource = estados;
            categoriaPicker.ItemsSource = categorias;
            colorPicker.ItemsSource = colores;
        }
        private async void buttonRegreso(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Compras());
        }
        private async void ButtonAgregarTarea_Clicked(object sender, EventArgs e)
        {
            string titulo = tituloEntry.Text;
            string descripcion = descripcionEditor.Text;
            DateTime fecha = fechaDatePicker.Date;
            string estado = estadoPicker.SelectedItem as string;
            string categoria = categoriaPicker.SelectedItem as string;
            string color = colorPicker.SelectedItem as string;

            // Obtener la instancia de la página Tareas desde la pila de navegación
            Compras tareasPage = Navigation.NavigationStack.FirstOrDefault(page => page is Compras) as Compras;

            if (tareasPage != null)
            {
                // Llamar al método AgregarTarea de la página Tareas pasando los datos de la nueva tarea
                tareasPage.AgregarTarea(titulo, descripcion, fecha, estado, categoria, color);
            }

            // Volver a la página anterior
            await Navigation.PopAsync();
        }

    }
}