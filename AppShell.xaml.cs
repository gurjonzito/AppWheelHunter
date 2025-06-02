namespace AppWheelHunter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            var app = (App)Application.Current;
        }
    }
}
