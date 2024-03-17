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
    public partial class Compras : ContentPage
    {
        public Compras()
        {
            InitializeComponent();
        }
        private async void ButtonAgregar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarTareas());
        }
        private bool ultimaTareaEnIzquierda = true;

        public void AgregarTarea(string titulo, string descripcion, DateTime fecha, string estado, string categoria, string color)
        {
            var frame = new Frame
            {
                HeightRequest = 300,
                CornerRadius = 10,
                Margin = new Thickness(8),
                HasShadow = false,
                BackgroundColor = Color.White,
                Padding = new Thickness(22)
            };

            var stackLayout = new StackLayout();
            stackLayout.Children.Add(new Label { Text = titulo, FontSize = 16, TextColor = Color.Black, CharacterSpacing = 1 });
            stackLayout.Children.Add(new Label { Text = descripcion, FontSize = 13, TextColor = Color.FromHex("#CCCCCC"), CharacterSpacing = 1 });
            stackLayout.Children.Add(new Label { Text = $"Fecha: {fecha:d}", FontAttributes = FontAttributes.Bold, FontSize = 22, Margin = new Thickness(0, 10) });
            stackLayout.Children.Add(new Label { Text = $"Estado: {estado}", FontSize = 16, TextColor = Color.Black, CharacterSpacing = 1 });
            stackLayout.Children.Add(new Label { Text = $"Categoría: {categoria}", FontSize = 16, TextColor = Color.Black, CharacterSpacing = 1 });
            stackLayout.Children.Add(new Label { Text = $"Color: {color}", FontSize = 16, TextColor = Color.Black, CharacterSpacing = 1 });

            frame.Content = stackLayout;

            if (ultimaTareaEnIzquierda)
            {
                Izquierda.Children.Add(frame);
            }
            else
            {
                Derecha.Children.Add(frame);
            }
            ultimaTareaEnIzquierda = !ultimaTareaEnIzquierda;
        }




    }
}