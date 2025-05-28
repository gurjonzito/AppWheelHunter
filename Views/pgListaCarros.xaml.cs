using AppWheelHunter.Controllers;
using AppWheelHunter.Models;

namespace AppWheelHunter.Views;

public partial class pgListaCarros : ContentPage
{
    CarroController carroController;
    public pgListaCarros()
	{
		InitializeComponent();
        carroController = new CarroController();
        AtualizarListView();
    }
    private void AtualizarListView()
    {
        lsvLista.ItemsSource = carroController.GetAll();
    }

    private void OnObtidoTapped(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped = (TappedEventArgs)e;

        if (tapped.Parameter is Carro registro)
        {
            registro.Obtido = !registro.Obtido;
            carroController.Update(registro);
            AtualizarListView();
        }
    }

    private void OnDesejadoTapped(object sender, TappedEventArgs e)
    {
        TappedEventArgs tapped = (TappedEventArgs)e;

        if (tapped.Parameter is Carro registro)
        {
            registro.Desejado = !registro.Desejado;
            carroController.Update(registro);
            AtualizarListView();
        }
    }
}