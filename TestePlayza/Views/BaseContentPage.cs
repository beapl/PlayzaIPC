using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace Playza.Views
{
    public class BaseContentPage : ContentPage
    {
        protected Image BackgroundImage;
        protected ContentView ContentHolder { get; }

        public BaseContentPage()
        {
            BackgroundImage = new Image
            {
                Aspect = Aspect.AspectFill,
                Opacity = 1,
                ZIndex = -1,
                Source = Preferences.Get("SelectedBackground", "wallpaper.jpg")
            };

            var mainGrid = new Grid();
            mainGrid.Add(BackgroundImage);

            ContentHolder = new ContentView();
            mainGrid.Add(ContentHolder);

            base.Content = mainGrid;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BackgroundImage.Source = Preferences.Get("SelectedBackground", "wallpaper.jpg");
        }
    }
}

