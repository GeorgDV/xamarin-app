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
	public partial class AddPostPage : ContentPage
	{
		public AddPostPage()
		{
			InitializeComponent ();
		}

        private async void TakePictureBtn_Clicked(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
            var photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                PhotoImage.Source = photo.Path;
        }

        private async void SavePostBtn_Clicked(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";

            if ((PostTitleEntry.Text == "" && PhotoImage.Source.ToString() == "File: ") ||
                (PostTitleEntry.Text == "" || PhotoImage.Source.ToString() == "File: "))
            {
                ErrorLabel.Text = "Title and Picture are required!";
            }
            else
            {

                //var post = (Post)BindingContext;
                var post = new Post();
                var user = (User)BindingContext;
                post.Title = PostTitleEntry.Text;
                string currentPath = PhotoImage.Source.ToString();
                string formattedPath = currentPath.Substring(6);
                post.ImgPath = formattedPath;
                post.Date = DateTime.Now;
                post.UserPhotoPath = user.ProfilePhotoPath;
                post.UserName = user.UserName;

                await App.dbContext.Posts_SavePostAsync(post);
                await Navigation.PopAsync();
            }

        }
    }
}