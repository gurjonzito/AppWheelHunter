using AppWheelHunter.Views;

namespace AppWheelHunter
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pgCadCarro());
        }

        private async void btnListar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pgListaCarros());

        }
    }

}
