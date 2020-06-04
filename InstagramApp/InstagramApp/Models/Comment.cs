using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramApp.Models
{
    public class Comment
    {
        //POST INFO
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int PostId { get; set; }

        //USER INFO
        public string UserPhotoPath { get; set; }
        public string UserName { get; set; }

        //COMMENT INFO
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
