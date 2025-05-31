using AppWheelHunter.Views;

namespace AppWheelHunter.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            bool isDarkMode = Preferences.Get("DarkMode", false);
            ThemeSwitch.IsToggled = isDarkMode;

            ((App)Application.Current).ThemeChanged += OnThemeChanged;
        }

        private void OnThemeChanged(bool isDark)
        {
            ThemeSwitch.IsToggled = isDark;
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

        private void OnThemeSwitchToggled(object sender, ToggledEventArgs e)
        {
            var app = (App)Application.Current;
            app.AlterarTema(e.Value);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((App)Application.Current).ThemeChanged -= OnThemeChanged;
        }
    }

}
