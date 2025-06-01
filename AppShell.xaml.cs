using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace AppWheelHunter
{
    public partial class AppShell : Shell
    {
        public AppShell()
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

        private void OnThemeSwitchToggled(object sender, ToggledEventArgs e)
        {
            ((App)Application.Current).AlterarTema(e.Value);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((App)Application.Current).ThemeChanged -= OnThemeChanged;
        }
    }
}
