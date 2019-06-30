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
    public partial class AddNewFishPage : ContentPage
    {
        public Catch _pickedCatch { get; set; }

        public AddNewFishPage(Catch pickedCatch)
        {
            _pickedCatch = pickedCatch;
            InitializeComponent();
        }
        
        internal async void AddFishButton_Clicked(object sender, EventArgs e)
        {
            var species = entrySpecies.Text;
            var weigth = entryWeight.Text;
            var lenght = entryLength.Text;

            if (string.IsNullOrWhiteSpace(species))
            {
                await DisplayAlert("Błąd", "Wprowadzono niepełne dane", "OK");
                return;
            }

            var newFish = new Fish()
            {
                Species = species,
                Weight = Convert.ToInt32(weigth),
                Length = Convert.ToInt32(lenght),
                CatchID = _pickedCatch.ID
            };



            await App.LocalDB.SaveItemAsync(newFish);
            await DisplayAlert("Sukces", "Dane zostały dodane", "OK");

            await Navigation.PopAsync();
        }
    }
}