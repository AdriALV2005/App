using App1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

    
        

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                tarea tar = new tarea()
                {
                    Titulo = txtTitulo.Text,
                    Descripcion = txtDescripcion.Text,
                };

                await App.SQLiteDB.SaveTareasAsync(tar);

                txtTitulo.Text = "";
                txtDescripcion.Text = "";

                await DisplayAlert("registro", "se guardo la tarea", "ok");
                var tareaList = await App.SQLiteDB.GetTareasAsync();

                if (tareaList != null) 
                {
                    lstTareas.ItemsSource = tareaList;
                }

            }
            else
            {
                await DisplayAlert("error", "ingresar todos los datos", "ok");
            }
        }


        // aqui me falata poner mas datos del models
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}