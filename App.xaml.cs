﻿namespace AppWheelHunter
{
    public partial class App : Application
    {
        public static App CurrentApp => (App)Current;

        public App()
        {
            InitializeComponent();
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