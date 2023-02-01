using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bonesmakers.Models
{
    public class TagModel
    {
        public TagModel(int id, string tag, string title, bool burn)
        {
            Id = id;
            Tag = tag;
            Title = title;
            Burn = burn;
        }
        public TagModel(int id)
        {
            Id = id;
            Tag = string.Empty;
            Title = string.Empty;
            Burn = false;
        }

        public int Id { get; set; }
        public string Tag { get; set; }
        public string Title { get; set; }
        public bool Burn { get; set; }

    }
}