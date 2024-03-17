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
            string[] colores = { "Azul", "Rojo", "Verde", "Amarillo", "Morado" };

            // Asignar los arrays a los Pickers
            estadoPicker.ItemsSource = estados;
            categoriaPicker.ItemsSource = categorias;
            colorPicker.ItemsSource = colores;
        }
        private async void buttonRegreso(object sender, EventArgs e)
        {
            string titulo = tituloEntry.Text;
            string descripcion = descripcionEditor.Text;
            DateTime fecha = fechaDatePicker.Date;
            string estado = estadoPicker.SelectedItem as string;
            string categoria = categoriaPicker.SelectedItem as string;
            string color = colorPicker.SelectedItem as string;


        }

        private async void ButtonAgregarTarea_Clicked(object sender, EventArgs e)
        {
            string titulo = tituloEntry.Text;
            string descripcion = descripcionEditor.Text;
            DateTime fecha = fechaDatePicker.Date;
            string estado = estadoPicker.SelectedItem as string;
            string categoria = categoriaPicker.SelectedItem as string;
            string color = colorPicker.SelectedItem as string;

            // Crear una instancia de DescripcionTareas con los datos recopilados
            DescripcionTareas descripcionPage = new DescripcionTareas(titulo, descripcion, fecha, estado, categoria, color);

            // Mostrar la página DescripcionTareas
          

            // Obtener la página de Tareas para agregar la tarea
            Tareas tareasPage = Navigation.NavigationStack.FirstOrDefault(page => page is Tareas) as Tareas;

            // Verificar si la página de Tareas existe y agregar la tarea
            if (tareasPage != null)
            {
                tareasPage.AgregarTarea(titulo, descripcion, fecha, estado, categoria, color);
            }

            // Pop la página actual (AgregarTareas)
            await Navigation.PopAsync();
        }



    }
}