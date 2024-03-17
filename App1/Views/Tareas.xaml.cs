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

            // Configurar el contenido del frame
            var stackLayout = new StackLayout();
            stackLayout.Children.Add(new Label { Text = titulo, FontSize = 20, TextColor = Color.Black, CharacterSpacing = 1 });
            stackLayout.Children.Add(new Label { Text = descripcion, FontSize = 13, TextColor = Color.Gray, CharacterSpacing = 1 });

            // Crear una nueva etiqueta para mostrar el estado con el prefijo "Estado:"
            var estadoStackLayout = new StackLayout();

            // Etiqueta para "Estado:"
            estadoStackLayout.Children.Add(new Label
            {
                Text = "Estado:",
                FontSize = 16,
                TextColor = Color.Black,
                CharacterSpacing = 1
            });

            // Frame para el estado con borde redondeado
            var estadoFrame = new Frame
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(5, 3),
                CornerRadius = 5 // Radio del borde
            };

            // Verificar el estado y establecer el color en consecuencia
            Color estadoColor;
            switch (estado)
            {
                case "Pendiente":
                    estadoColor = Color.Red;
                    break;
                case "En Progreso":
                    estadoColor = Color.Orange;
                    break;
                case "Completada":
                    estadoColor = Color.Green;
                    break;
                default:
                    estadoColor = Color.Default;
                    break;
            }

            estadoFrame.BackgroundColor = estadoColor; // Establecer el color del fondo del Frame

            estadoFrame.Content = new Label
            {
                Text = estado,
                FontSize = 14,
                TextColor = Color.White
            };

            estadoStackLayout.Children.Add(estadoFrame);
            stackLayout.Children.Add(estadoStackLayout);

            // Agregar botones (puedes agregar lógica para estos botones según tus necesidades)
            var buttonEditar = new Button
            {
                Text = "Editar",
                HeightRequest = 54,
                WidthRequest = 200,
                CornerRadius = 40,
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                Margin = new Thickness(0, 30, 0, 10) // Margen en la parte superior para separar del contenido
            };

            buttonEditar.Clicked += (s, e) => { /* Lógica del botón 1 */ };
            stackLayout.Children.Add(buttonEditar);

            frame.Content = stackLayout;

            // Agregar TapGestureRecognizer al Frame para manejar el toque y navegar a DescripcionTareas
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                // Navegar a DescripcionTareas y pasar los datos necesarios
                await Navigation.PushAsync(new DescripcionTareas(titulo, descripcion, fecha, estado, categoria, color));
            };
            frame.GestureRecognizers.Add(tapGestureRecognizer);

            // Agregar el frame al StackLayout correspondiente según la categoría
            if (categoria == "Tareas Principales")
            {
                Izquierda.Children.Add(frame);
            }
            else if (categoria == "Tareas Secundarias")
            {
                Izquierda1.Children.Add(frame);
            }

            // Configurar el color de fondo del frame según el color seleccionado
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
        }


        private async void ButtonAgregar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarTareas());
        }
        private void MostrarBL(object sender, EventArgs e)
        {
            // Acceder al Grid por su nombre
            Grid stackLayout1 = this.FindByName<Grid>("StackLayout1");

            // Verificar si el Grid no es nulo y cambiar la visibilidad
            if (stackLayout1 != null)
            {
                stackLayout1.IsVisible = false;
            }

            // Busca el StackLayout por su nombre
            StackLayout stackLayout = this.FindByName<StackLayout>("StackLayout2");

            // Verifica si se encontró el StackLayout
            if (stackLayout != null)
            {
                // Si el StackLayout está visible, lo oculta; si está oculto, lo muestra
                stackLayout.IsVisible = !stackLayout.IsVisible;
            }
        }


        private void OcultarBL(object sender, EventArgs e)
        {
            // Acceder al StackLayout por su nombre
            StackLayout stackLayout = this.FindByName<StackLayout>("StackLayout2");

            // Verificar si el StackLayout no es nulo y cambiar la visibilidad
            if (stackLayout != null)
            {
                stackLayout.IsVisible = !stackLayout.IsVisible;
            }

            // Acceder al Grid por su nombre
            Grid grid = this.FindByName<Grid>("StackLayout1");

            // Verificar si el Grid no es nulo y cambiar la visibilidad
            if (grid != null)
            {
                grid.IsVisible = !grid.IsVisible;
            }
        }

    }
}

    

