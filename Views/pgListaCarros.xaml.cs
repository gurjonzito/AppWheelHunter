using AppWheelHunter.Controllers;
using AppWheelHunter.Models;

namespace AppWheelHunter.Views;

public partial class pgListaCarros : ContentPage
{
    CarroController carroController;
    public pgListaCarros()
	{
		InitializeComponent();
        var app = (App)Application.Current;
        carroController = new CarroController();
        picker.SelectedIndex = 0;
        AtualizarListView();
        FiltrarListView();
    }
    private void FiltrarListView()
    {
        var textoBusca = searchBar.Text;
        var status = picker.SelectedItem?.ToString();

        bool? obtido = status == "Obtido" ? true :
                      status == "Desejado" ? false : null;

        bool? desejado = status == "Desejado" ? true : null;

        lsvLista.ItemsSource = carroController.Filtrar(textoBusca, obtido, desejado);
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        FiltrarListView();
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        FiltrarListView();
    }

    private void AtualizarListView()
    {
        picker.SelectedIndex = 0;
        lsvLista.ItemsSource = null;
        lsvLista.ItemsSource = carroController.GetAll();
        OnPropertyChanged(nameof(lsvLista));
    }

    private void OnObtidoTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Carro carro)
        {
            bool novoEstado = !carro.Obtido;
            carro.Obtido = novoEstado;
            carro.Desejado = !novoEstado;  

            carroController.Update(carro);
            AtualizarListView();
        }
    }
    private void OnDesejadoTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Carro carro)
        {
            bool novoEstado = !carro.Desejado;
            carro.Desejado = novoEstado;
            carro.Obtido = !novoEstado;  

            carroController.Update(carro);
            AtualizarListView();
        }
    }

    private async void OnExcluidoTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Carro carro)
        {
            bool confirmacao = await DisplayAlert(
                "Excluir",
                $"Deseja realmente excluir {carro.Modelo}?",
                "Sim", "Não"
            );

            if (confirmacao)
            {
                bool sucesso = carroController.Delete(carro);

                if (sucesso)
                {
                    await DisplayAlert("Sucesso", "Carrinho excluído!", "OK");
                    AtualizarListView();
                }
                else
                {
                    await DisplayAlert("Erro", "Falha ao excluir. Tente novamente.", "OK");
                }
            }
        }
    }
}