using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bonesmakers.Models
{
    public class TrackingCardModel
    {
        enum Types
        {
            None,
            Story,  // 📖
            Status, // 🏷️
            Clue,   // 🔍
            Juice,  // 🔋
        }
        public TrackingCardModel(int id, string type, string title, string description, int level)
        {
            Id = id;
            Type = type;
            Title = title;
            Description = description;
            Level = level;
        }
        public TrackingCardModel(int id)
        {
            Id = id;
            Type = Types.None.ToString();
            Title = string.Empty;
            Description = string.Empty;
            Level = 0;
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
    }
}