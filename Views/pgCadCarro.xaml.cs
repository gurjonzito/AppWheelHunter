using AppWheelHunter.Models;
using AppWheelHunter.Services;
using AppWheelHunter.Controllers;

namespace AppWheelHunter.Views;

public partial class pgCadCarro : ContentPage
{
    private CarroController carroController;
    private string sImagemSelecionada;
    public pgCadCarro()
	{
		InitializeComponent();
        var app = (App)Application.Current;
        carroController = new CarroController();
        AtualizarVisibilidadeBotoes();

    }

    private void AtualizarVisibilidadeBotoes()
    {
        btnRemover.IsVisible = !string.IsNullOrEmpty(sImagemSelecionada);
    }

    private void LimparCampos()
    {
        txtModelo.Text = "";
        txtAno.Text = "";
        pckrLote.SelectedIndex = -1;
        radDesejado.IsChecked = false;
        radObtido.IsChecked = false;
        imgCarro.Source = null;
        sImagemSelecionada = null;
        AtualizarVisibilidadeBotoes();
    }

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        string modelo = txtModelo.Text?.Trim() ?? "";
        string lote = pckrLote.SelectedItem?.ToString()?.Trim();
        bool obtido = radObtido.IsChecked;
        bool desejado = radDesejado.IsChecked;

        if (string.IsNullOrEmpty(sImagemSelecionada))
        {
            await DisplayAlert("Atenção", "Selecione uma imagem para o carro.", "OK");
            return;
        }

        if (string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(lote))
        {
            await DisplayAlert("Atenção", "Informe todos os campos corretamente.", "OK");
            return;
        }

        if (!int.TryParse(txtAno.Text?.Trim() ?? "", out int ano) || ano <= 0 || txtAno.Text?.Trim()?.Length != 4)
        {
            await DisplayAlert("Atenção", "Ano inválido. Digite um número positivo.", "OK");
            return;
        }

        if (!radObtido.IsChecked && !radDesejado.IsChecked)
        {
            await DisplayAlert("Atenção", "Selecione 'Obtido' ou 'Desejado'.", "OK");
            return;
        }

        if (pckrLote.SelectedIndex != -1)
        {
            lote = pckrLote.Items[pckrLote.SelectedIndex];
        }

        Carro carro = new Carro();
        carro.Modelo = modelo;
        carro.Lote = lote;
        carro.Ano = ano;
        carro.Obtido = obtido;
        carro.Desejado = desejado;
        carro.DirImagem = sImagemSelecionada;

        if (carroController.Insert(carro))
        {
            await DisplayAlert("Sucesso", "Carrinho salvo!", "OK");
            LimparCampos();
            MessagingCenter.Send(this, "CarrosAtualizados");
        }
        else
        {
            await DisplayAlert("Erro", "Falha ao salvar. Tente novamente.", "OK");
        }
    }

    private async void btnSelecionar_Clicked(object sender, EventArgs e)
    {
        sImagemSelecionada = await ImageService.SelecionarImagem();
        imgCarro.Source = sImagemSelecionada;
        AtualizarVisibilidadeBotoes();
    }
    private void btnRemover_Clicked(object sender, EventArgs e)
    {
        imgCarro.Source = null;
        sImagemSelecionada = null;
        AtualizarVisibilidadeBotoes();
    }
}