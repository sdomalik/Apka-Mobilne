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
	public partial class MyCatchesPage : ContentPage
	{
        private List<Catch> _catches;
		public MyCatchesPage ()
		{
			InitializeComponent();
		}

        private async void InitializeListView()
        {
            _catches = await App.LocalDB.GetItems<Catch>();
            lvCatches.ItemsSource = _catches;
            lvCatches.ItemTapped -= lvCatches_ItemTapped;
            lvCatches.ItemTapped += lvCatches_ItemTapped;
        }

        private async void lvCatches_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedCatch = (Catch)e.Item;
            await Navigation.PushAsync(new CatchPage(selectedCatch));
        }

        async void AddCatch_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewCatchPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializeListView();
        }
    }
}