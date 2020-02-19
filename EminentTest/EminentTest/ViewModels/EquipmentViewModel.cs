using EminentTest.Models;
using EminentTest.Services;
using EminentTest.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EminentTest.ViewModels
{
    class EquipmentViewModel : INotifyPropertyChanged
    {
        EquipmentService service = new EquipmentService();
       
        public string Name { get; set; }
        public int Quantity { get; set; }

        //public int Status { get; set; }

        public string StatusName { get; set; }

        public int Type { get; set; }

        public string TypeName { get; set; }

        EquipmentService equipmentService { get; } = new EquipmentService();

        public List<Equipment> _equipment { get; set; }
        public List<Equipment> equipmenT
        {
            get { return _equipment; }
            set
            {
                _equipment = value;
                OnPropertyChanged();
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }


        public ICommand RefreshCommand
        {
            get {
                return new Command(async () =>
          {
              IsRefreshing = true;

              List<Equipment> equipment = await equipmentService.GetEquipment();
              equipmenT = new List<Equipment>(equipment);
              IsRefreshing = false;
          });
                   
            
            }
        }

        private ICommand _search;
        public ICommand SearchCommand
        {
            get
            {
                return _search ?? (_search = new Command <string>(async (text) =>
               {
                   if (text.Length >= 1)
                   {
                    
                    
                       var suggestion = equipmenT.Where(x => x.Name.ToLower().StartsWith(text.ToLower())).ToList();
                       
                       equipmenT = suggestion;
                   }
                   else
                   {
                       List<Equipment> equipment = await equipmentService.GetEquipment();
                       equipmenT = new List<Equipment>(equipment);
                   }
                   

               }));
            }
        }



        
        public EquipmentViewModel()
        {
            ExecuteGetEquipmentCommand();
           
        }
        public ICommand CreateEquipment
        {
            get
            {
                return new Command(async () =>
                {
                    var item = new Equipment
                    {
                        Name = Name,
                        TypeName = TypeName,
                        StatusName = StatusName,
                        Quantity = Quantity
                    };
                    await service.CreateEquipment(item);
                    await Application.Current.MainPage.DisplayAlert("Message", item.Name + " Added Successfully", "Ok");
                    await Application.Current.MainPage.Navigation.PushModalAsync(new EquipmentPage());
                   


                });
            }

        }

        

       

        public event PropertyChangedEventHandler PropertyChanged;
     
      

        private ICommand command;
     

        public ICommand GetAllEquipment=>
            command ??
            (command = new Command(() => ExecuteGetEquipmentCommand()));

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

        public  async void ExecuteGetEquipmentCommand()
        {
          
            try
            {

                List<Equipment> equipment = await  equipmentService.GetEquipment();
                equipmenT = new List<Equipment>(equipment);
            }
            catch (Exception)
            {

                throw;
            }
        }

       





        //void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var typeList = new List<string>();
        //    typeList.Add("Indoor");
        //    typeList.Add("Outdoor");
         

        //    var picker = new Picker { Title = "Select a type", TitleColor = Color.Red };
        //    picker.ItemsSource = typeList;
        //    var typeNameLabel = new Label();
        //    typeNameLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: picker));
        //     picker = (Picker)sender;
        //    int selectedIndex = picker.SelectedIndex;

        //    if (selectedIndex != -1)
        //    {
        //        typeNameLabel.Text = (string)picker.ItemsSource[selectedIndex];
        //    }
        //}



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
        public int StatusSelectedIndex
        {
            get
            {
                return statusSelectedIndex;
            }
            set
            {
                if (statusSelectedIndex != value)
                {
                    statusSelectedIndex = value;

                    // trigger some action to take such as updating other labels or fields
                    OnPropertyChanged(nameof(StatusSelectedIndex));
                    Status = Statues[statusSelectedIndex];
                }
            }
        }

     
        
        private int statusSelectedIndex;
        private string _status;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

      

       





    }

  
}
