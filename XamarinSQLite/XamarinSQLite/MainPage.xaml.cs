using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinSQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            //Get All Persons
            var personList = await App.SQLiteDb.GetItemsAsync();
            if(personList!=null)
            {
                lstPersons.ItemsSource = personList;
            }
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                Person person = new Person()
                {
                    Name = txtName.Text,
                    Date = Convert.ToDateTime(txtdate.Date),
                    DesignNo = txtDesignno.Text,
                    Machine = txtMachine.Text,
                    Shift = txtShift.Text,
                    Stiches = Convert.ToInt32(txtStiches.Text),
                    Frame = Convert.ToInt32(txtFrame.Text),
                    Tb = Convert.ToInt32(txtTb.Text),
                    Hajri = Convert.ToDouble(txtHajri.Text),
                    Pagar = Convert.ToInt32(txtPagar.Text),
                    Bonus = Convert.ToInt32(txtBonus.Text),
                    Total = Convert.ToInt32(txtTotal.Text),
                    Remark = txtRemark.Text,
                };

                //Add New Person
                await App.SQLiteDb.SaveItemAsync(person);
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Person added Successfully", "OK");
                //Get All Persons
                var personList = await App.SQLiteDb.GetItemsAsync();
                if (personList != null)
                {
                    lstPersons.ItemsSource = personList;
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter name!", "OK");
            }
        }

        private async void BtnRead_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                //Get Person
                var person = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtPersonId.Text));
                if(person!=null)
                {
                    txtName.Text = person.Name;
                    await DisplayAlert("Success","Person Name: "+ person.Name, "OK");
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                Person person = new Person()
                {
                    PersonID = Convert.ToInt32(txtPersonId.Text),
                    Name = txtName.Text,
                    Date = Convert.ToDateTime(txtdate.Date),
                    DesignNo = txtDesignno.Text,
                    Machine = txtMachine.Text,
                    Shift = txtShift.Text,
                    Stiches = Convert.ToInt32(txtStiches.Text),
                    Frame = Convert.ToInt32(txtFrame.Text),
                    Tb = Convert.ToInt32(txtTb.Text),
                    Hajri = Convert.ToDouble(txtHajri.Text),
                    Pagar = Convert.ToInt32(txtPagar.Text),
                    Bonus = Convert.ToInt32(txtBonus.Text),
                    Total = Convert.ToInt32(txtTotal.Text),
                    Remark = txtRemark.Text,
                };

                //Update Person
                await App.SQLiteDb.SaveItemAsync(person);

                txtPersonId.Text = string.Empty;
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Person Updated Successfully", "OK");
                //Get All Persons
                var personList = await App.SQLiteDb.GetItemsAsync();
                if (personList != null)
                {
                    lstPersons.ItemsSource = personList;
                }

            }
            else
            {
                await DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonId.Text))
            {
                //Get Person
                var person = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtPersonId.Text));
                if (person != null)
                {
                    //Delete Person
                    await App.SQLiteDb.DeleteItemAsync(person);
                    txtPersonId.Text = string.Empty;
                    await DisplayAlert("Success", "Person Deleted", "OK");
                    
                    //Get All Persons
                    var personList = await App.SQLiteDb.GetItemsAsync();
                    if (personList != null)
                    {
                        lstPersons.ItemsSource = personList;
                    }
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }
    }
}
