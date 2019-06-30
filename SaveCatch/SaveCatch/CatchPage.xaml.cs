using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveCatch.Models.Sqlite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SaveCatch
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CatchPage : ContentPage
	{
        private List<Fish> _fish;
        private Catch _pickedCatch { get; set; }

        public CatchPage (Catch pickedCatch)
		{
            _pickedCatch = pickedCatch;
			InitializeComponent ();
		}

        private async void InitializeListView()
        {
            _fish = await App.LocalDB.GetFishes(_pickedCatch.ID);
            lvFish.ItemsSource = _fish;
            lvFish.ItemTapped -= lvFish_ItemTapped;
            lvFish.ItemTapped += lvFish_ItemTapped;

        }
        

        private async void lvFish_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var pickedFish = (Fish)e.Item;
            await Navigation.PushAsync(new FishPage(pickedFish));

    }

    private async void AddFish_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewFishPage(_pickedCatch));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializeListView();
        }

        private async void DeleteCatch_Clicked(object sender, EventArgs e)
        {
            await App.LocalDB.DeleteItemAsync<Catch>(_pickedCatch);
            await DisplayAlert("Sukces", "Połów został usunięty", "OK");
            await Navigation.PopAsync();

        }
    }
}