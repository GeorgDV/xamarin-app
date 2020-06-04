using InstagramApp.Models;
using InstagramApp.ViewModels;
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
    public partial class PostDetailsPage : ContentPage
    {
        public PostDetailsPage()
        {
            InitializeComponent();
        }

        /*
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as CommentsViewModel)?.RefreshList();
        }
        */

        private async void DeletePostBtn_Clicked(object sender, EventArgs e)
        {
            var post = (Post)BindingContext;
            await App.dbContext.Posts_DeletePostAsync(post);
            await Navigation.PopAsync();
        }
    }
}