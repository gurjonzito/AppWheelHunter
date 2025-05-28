using AppWheelHunter.Views;

namespace AppWheelHunter
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new pgCadCarro());
        }

        private void btnListar_Clicked(object sender, EventArgs e)
        {

        }
    }

}
