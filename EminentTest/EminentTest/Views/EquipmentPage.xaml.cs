using EminentTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EminentTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquipmentPage : ContentPage
    {
        public EquipmentPage()
        {
            InitializeComponent();
        }
        private async void AddEquipment(Object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddEquipmentPage());
        }



        private async void selectedequipment(Object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Equipment;
            await Navigation.PushModalAsync(new EquipmentDetailsPage(item));
        }
        
    }
}