using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramApp.Models
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //POST INFO
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public DateTime Date { get; set; }

        // USER INFO
        public string UserPhotoPath { get; set; }
        public string UserName { get; set; }

        // LIKE INFO
        public int LikeCount { get; set; }

        [TextBlob("LikedUsersBlobbed")]
        public List<User> LikedUsers { get; set; }
        public string LikedUsersBlobbed { get; set; }

        [TextBlob("CommentsBlobbed")]
        public List<Comment> Comments { get; set; }
        public string CommentsBlobbed { get; set; }
        
    }
}
