using InstagramApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InstagramApp.ViewModels
{
    public class PostsViewModel : INotifyPropertyChanged
    {
        public PostsViewModel()
        {
            Posts = new ObservableCollection<Post>();
            //AddPostCommand = new Command(OnAddPostCommand);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        //public ObservableCollection<Post> Posts { get; set; }
        private ObservableCollection<Post> _posts;
        public ObservableCollection<Post> Posts
        {
            get
            {
                return _posts;
            }

            set
            {
                if (_posts != value)
                {
                    _posts = value;
                    OnPropertyChanged(nameof(Posts));
                }
            }

        }

        public void RefreshList()
        {
            Posts.Clear();
            List<Post> postList = Task.Run(async () => await App.dbContext.Posts_GetPostsAsync()).Result;


            foreach (Post post in postList)
            {
                Posts.Add(post);
            }
        }

        /*
        public INavigation Navigation { get; set; }

        public ICommand AddPostCommand { get; private set; }

        private async void OnAddPostCommand()
        { 
            await Navigation.PushAsync(new AddPostPage
            {
                BindingContext = new Post()
            });
        }
        */
    }
}
