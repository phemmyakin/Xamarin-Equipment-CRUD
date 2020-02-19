using EminentTest.Models;
using EminentTest.ViewModels;
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
    public partial class EquipmentDetailsPage : ContentPage
    {
        public EquipmentDetailsPage(Equipment equipment)
        {
            var editEquipmentVM = new EditEquipmentViewModel();
            editEquipmentVM.Equipment = equipment;
            BindingContext = editEquipmentVM;
            InitializeComponent();
            //var vm = BindingContext as EditEquipmentViewModel;
            //vm.Equipment = equipment;
        }
    }
}