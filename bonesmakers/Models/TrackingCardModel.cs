using bonesmakers.Singalton;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Web;

namespace bonesmakers.Models
{
    [Serializable()]
    public class TrackingCardModel : ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Tag", Type);
            info.AddValue("Title", Title);
            info.AddValue("Description", Description);
            info.AddValue("Level", Level);
        }
        public TrackingCardModel(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Type = (string)info.GetValue("Type", typeof(string));
            Title = (string)info.GetValue("Title", typeof(string));
            Description = (string)info.GetValue("Description", typeof(string));
            Level = (int)info.GetValue("Level", typeof(int));
        }
        public void CreateOrOpen()
        {
            Stream stream = File.Open(Singleton.TrackingCardFile(), FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, this);
            stream.Close();
        }
        public TrackingCardModel GetBiInfo()
        {
            Stream stream = File.Open(Singleton.TrackingCardFile(), FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            TrackingCardModel model = (TrackingCardModel)bf.Deserialize(stream);
            stream.Close();
            return model;
        }
    }
}