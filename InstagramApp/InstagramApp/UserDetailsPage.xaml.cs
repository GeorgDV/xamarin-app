using InstagramApp.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        public UserDetailsPage()
        {
            InitializeComponent();
        }

        private async void TakePictureBtn_Clicked(object sender, EventArgs e)
        {
            var photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                ProfilePhoto.Source = photo.Path;
        }

        private async void SaveProfileBtn_Clicked(object sender, EventArgs e)
        {
            ErrorOutput.Text = "";
            var user = (User)BindingContext;
            if (UserNameEntry.Text != "" && ProfilePhoto.Source != null)
            {
                string currentPath = ProfilePhoto.Source.ToString();
                string formattedPath = currentPath.Substring(6);
                user.UserName = UserNameEntry.Text.ToString();
                user.ProfilePhotoPath = formattedPath;
                UserName.Text = UserNameEntry.Text.ToString();

                await App.dbContext.Users_SaveUserAsync(user);
            }
            else
            {
                ErrorOutput.Text = "Username/Profile Photo can't be empty!";
            }
        }

        private async void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            await App.dbContext.Users_DeleteUserAsync(user);
            await Navigation.PopAsync();
        }
    }
}