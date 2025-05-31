using AppWheelHunter.Views;

namespace AppWheelHunter
{
    public partial class App : Application
    {
        public static App CurrentApp => (App)Current;

        public event Action<bool> ThemeChanged;

        public App()
        {
            InitializeComponent();
            bool darkMode = Preferences.Get("DarkMode", false);
            AplicarTema(darkMode);
        }

        public void AlterarTema(bool isDark)
        {
            Preferences.Set("DarkMode", isDark);
            AplicarTema(isDark);
            ThemeChanged?.Invoke(isDark);
            RecarregarPaginas();
        }

        private void AplicarTema(bool isDark)
        {
            Resources.MergedDictionaries.Clear();
            var theme = isDark ?
                (ResourceDictionary)Resources["DarkTheme"] :
                (ResourceDictionary)Resources["LightTheme"];
            Resources.MergedDictionaries.Add(theme);

            if (MainPage is NavigationPage navPage &&
            navPage.CurrentPage is MainPage mainPage)

            {
                mainPage.ThemeSwitch.IsToggled = isDark;
            }

            if (Current?.MainPage is AppShell shell)
            {
                shell.ThemeSwitch.IsToggled = isDark;
            }
        }

        private void RecarregarPaginas()
        {
            if (MainPage is NavigationPage navPage)
            {
                foreach (var page in navPage.Navigation.NavigationStack)
                {
                    if (page is ContentPage contentPage)
                    {
                        contentPage.Resources = null;
                        contentPage.Resources = Application.Current.Resources;
                    }
                }
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

            window.Height = 800;
            window.Width = 400;

            return window;
        }
    }
}