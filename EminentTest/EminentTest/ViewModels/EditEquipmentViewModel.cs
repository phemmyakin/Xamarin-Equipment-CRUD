using EminentTest.Models;
using EminentTest.Services;
using EminentTest.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EminentTest.ViewModels
{
   public class EditEquipmentViewModel
    {
        Equipment equip = new Equipment();
        public  Equipment Equipment { get; set; }
        EquipmentService services = new EquipmentService();



        public List<string> status = new List<string>
            {
                "Active",
                "Declined",
            };

        public List<string> Statues => status;





        public List<string> type = new List<string>
            {
                "Indoor",
                "Outdoor",
            };

        public List<string> Types => type;
        public ICommand EditEquipment
        {
            get
            {
                return new Command(async () =>
                {
                    await services.UpdateEquipment(Equipment);

                    await Application.Current.MainPage.DisplayAlert("Message", Equipment.Name + " Updated Successfully", "Ok");
                    await Application.Current.MainPage.Navigation.PushModalAsync(new EquipmentPage());
                });
            }
        }


        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await services.DeleteEquipment(Equipment);
                    await Application.Current.MainPage.DisplayAlert("Message", Equipment.Name + " Deleted Successfully", "Ok");
                    await Application.Current.MainPage.Navigation.PushModalAsync(new EquipmentPage());


                });
            }
        }

    }
}
