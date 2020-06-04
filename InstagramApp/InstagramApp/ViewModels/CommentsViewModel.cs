using InstagramApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace InstagramApp.ViewModels
{
    public class CommentsViewModel : INotifyPropertyChanged
    {

        //MAYBE WILL BE USED AT SOME POINT
        public CommentsViewModel()
        {
            Comments = new ObservableCollection<Comment>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        //public ObservableCollection<Post> Comments { get; set; }
        private ObservableCollection<Comment> _comments;
        public ObservableCollection<Comment> Comments
        {
            get
            {
                return _comments;
            }

            set
            {
                if (_comments != value)
                {
                    _comments = value;
                    OnPropertyChanged(nameof(Comments));
                }
            }

        }

        public void RefreshList()
        {
            Comments.Clear();
            List<Comment> commentList = Task.Run(async () => await App.dbContext.Comments_GetCommentsAsync()).Result;


            foreach (Comment comment in commentList)
            {
                Comments.Add(comment);
            }
        }
    }
}
