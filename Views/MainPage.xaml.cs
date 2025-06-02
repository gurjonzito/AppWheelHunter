using AppWheelHunter.Views;

namespace AppWheelHunter.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            var app = (App)Application.Current;
        }

        private async void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pgCadCarro());
        }

        private async void btnListar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pgListaCarros());

        }

        private async void btnPrincipal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pgPrincipal());
        }
    }

}
