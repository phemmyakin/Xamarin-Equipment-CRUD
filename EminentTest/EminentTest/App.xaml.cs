using EminentTest.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EminentTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new  NavigationPage(new EquipmentPage());
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
