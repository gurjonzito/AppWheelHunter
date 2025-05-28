using AppWheelHunter.Controllers;
using AppWheelHunter.Models;

namespace AppWheelHunter.Views;

public partial class pgCadCarro : ContentPage
{
    private CarroController carroController;
	public pgCadCarro()
	{
		InitializeComponent();
	}

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        string modelo = txtModelo.Text.Trim();
        string lote = pckrLote.SelectedItem?.ToString()?.Trim();
        int ano = int.Parse(txtAno.Text.Trim());

        if (string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(lote) || string.IsNullOrEmpty(lote))
        {
            await DisplayAlert(
                "Atenção",
                "Informe todos os dados corretamente.",
                "OK");
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

        if (carroController.Insert(carro))
        {
            await DisplayAlert(
                "Informação",
                "Registro salvo com sucesso!",
                "OK");

            txtModelo.Text = "";
            txtAno.Text = "";
            pckrLote.SelectedIndex = -1;

        }
        else
            await DisplayAlert(
                "Erro",
                "Falha ao salvar o registro no banco de dados.",
                "OK");
    }

    private void btnSelecionar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnRemover_Clicked(object sender, EventArgs e)
    {

    }
}