using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SaveCatch.Models.Sqlite;
using Xamarin.Essentials;

namespace SaveCatch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FishPage : ContentPage
    {
        private Fish _pickedFish { get; set; }

        public FishPage(Fish pickedfish)
        {
            _pickedFish = pickedfish;

            InitializeComponent();
            var layout = new StackLayout();
            var button = new Button { Text = "Udostępnij", HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.Start,  };
            var label = new Label
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Text = "Gatunek: " + _pickedFish.Species + "\nWaga: " + _pickedFish.Weight + " gram" + "\nDługość: " + _pickedFish.Length + " cm",
                    FontSize=28
            };
            button.Clicked += async(sender, args) => await ShareText();

            layout.Children.Add(button);
            layout.Children.Add(label);
            layout.Spacing = 10;
            Content = layout;
        }
        public async Task ShareText()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "Gatunek: " + _pickedFish.Species + "\nWaga: " + _pickedFish.Weight + " gram" + "\nDługość: " + _pickedFish.Length + " cm",
                Title = "Share Text"
            });
        }
        




    }
}