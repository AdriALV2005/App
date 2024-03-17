using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tareas : ContentPage
    {
        private bool ultimaTareaEnIzquierda = true;

        public Tareas()
        {
            InitializeComponent();
        }

        public void AgregarTarea(string titulo, string descripcion, DateTime fecha, string estado, string categoria, string color)
        {
            var frame = new Frame
            {
                HeightRequest = -1,
                CornerRadius = 10,
                Margin = new Thickness(8),
                HasShadow = false,
                Padding = new Thickness(22)
            };

            // Establecer el color de fondo del Frame según el color seleccionado
            switch (color)
            {
                case "Azul":
                    frame.BackgroundColor = Color.FromHex("#dcffff");
                    break;
                case "Rojo":
                    frame.BackgroundColor = Color.FromHex("#ffbfaf");
                    break;
                case "Verde":
                    frame.BackgroundColor = Color.FromHex("#BDECB6");
                    break;
                case "Amarillo":
                    frame.BackgroundColor = Color.FromHex("#FDFD96");
                    break;
                case "Morado":
                    frame.BackgroundColor = Color.FromHex("#CCA9DD");
                    break;
                default:
                    frame.BackgroundColor = Color.Default;
                    break;
            }

            var stackLayout = new StackLayout();
            stackLayout.Children.Add(new Label { Text = titulo, FontSize = 20, TextColor = Color.Black, CharacterSpacing = 1 });
            stackLayout.Children.Add(new Label { Text = descripcion, FontSize = 13, TextColor = Color.Gray, CharacterSpacing = 1 });
            stackLayout.Children.Add(new Label { Text = $"Estado: {estado}", Margin = new Thickness(0, 10, 0, 0) ,FontSize = 16, TextColor = Color.Black, CharacterSpacing = 1 });

            // Agregar botones (puedes agregar lógica para estos botones según tus necesidades)
            var buttonEditar = new Button
            {
                Text = "Editar",
                HeightRequest = 54,
                WidthRequest = 200,
                CornerRadius = 40,
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                Margin = new Thickness(0, 30,0, 10) // Margen en la parte superior para separar del contenido
            };

            buttonEditar.Clicked += (s, e) => { /* Lógica del botón 1 */ };
          

            stackLayout.Children.Add(buttonEditar);


            frame.Content = stackLayout;

            // Agregar TapGestureRecognizer al Frame para manejar el toque y navegar a DescripcionTareas
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                // Navega a DescripcionTareas y pasa los datos necesarios
                await Navigation.PushAsync(new DescripcionTareas(titulo, descripcion, fecha, estado, categoria, color));
            };

            frame.GestureRecognizers.Add(tapGestureRecognizer);

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

        private async void ButtonAgregar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarTareas());
        }
    }
}
