using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeautifulButtonsXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Sharpnado.CollectionView.Initializer.Initialize(true, false);
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
