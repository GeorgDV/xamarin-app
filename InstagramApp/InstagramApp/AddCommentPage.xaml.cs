using InstagramApp.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
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
    public partial class AddCommentPage : ContentPage
    {
        public AddCommentPage()
        {
            InitializeComponent();
        }

        private async void SaveCommentBtn_Clicked(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";

            if (CommentContentEntry.Text == "")
            {
                ErrorLabel.Text = "Comment Content is required!";
            }
            else
            {
                var comment = new Comment();
                var bindingPost = (Post)BindingContext;
                var conn = new SQLiteConnection(App.dbContext.GetDatabasePath());

                var postList = conn.GetAllWithChildren<Post>();
                var selectedPost = postList.Find(x => x.Id == bindingPost.Id);
                if (selectedPost.Comments == null)
                {
                    selectedPost.Comments = new List<Comment>();
                }

                comment.PostId = bindingPost.Id;
                comment.UserName = "TestUserName";
                //comment.UserPhotoPath = "";
                comment.Content = CommentContentEntry.Text.ToString();
                comment.Date = DateTime.Now;
                selectedPost.Comments.Add(comment);

                conn.UpdateWithChildren(selectedPost);
                await App.dbContext.Comments_SaveCommentAsync(comment);
                await Navigation.PopAsync();
            }
        }
    }
}