using AppWheelHunter.Views;

namespace AppWheelHunter
{
    public partial class App : Application
    {
        public static App CurrentApp => (App)Current;

        public App()
        {
            InitializeComponent();
        }

        private void RecarregarPaginas()
        {
            if (MainPage is NavigationPage navPage)
            {
                foreach (var page in navPage.Navigation.NavigationStack)
                {
                    if (page is ContentPage contentPage)
                    {
                        var temp = contentPage.Title;
                        contentPage.Title = string.Empty;
                        contentPage.Title = temp;
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