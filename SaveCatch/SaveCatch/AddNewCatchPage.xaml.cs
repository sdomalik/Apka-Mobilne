using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SaveCatch.Models.Sqlite;

namespace SaveCatch
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewCatchPage : ContentPage
	{
		public AddNewCatchPage ()
		{
			InitializeComponent();
		}

        internal async void AddCatchButton_Clicked(object sender, EventArgs e)
        {
            var name = entryName.Text;
            var location = entryLocation.Text;
            DateTime date = entryDate.Date;            
            var type = entryType.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(type))
            {
                await DisplayAlert("Błąd", "Wprowadzono niepełne dane", "OK");
                return;
            }

            var newCatch = new Catch()
            {
                Name = name,
                Location = location,
                Date = date.ToShortDateString(),
                Type = type
            };

            await App.LocalDB.SaveItemAsync(newCatch);
            await DisplayAlert("Sukces", "Dane zostały dodane", "OK");

            await Navigation.PushAsync(new MyCatchesPage());

        }
    }
}