using bonesmakers.Singalton;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Xml.Linq;

namespace bonesmakers.Models
{
    [Serializable()]
    public class TagModel : ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Tag", Tag);
            info.AddValue("Title", Title);
            info.AddValue("Burn", Burn);
        }
        public TagModel(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Tag = (string)info.GetValue("Tag", typeof(string));
            Title = (string)info.GetValue("Title", typeof(string));
            Burn = (bool)info.GetValue("Burn", typeof(bool));
        }
        public void CreateOrOpen()
        {
            Stream stream = File.Open(Singleton.TagFile(), FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, this);
            stream.Close();
        }
        public TagModel GetBiInfo()
        {
            Stream stream = File.Open(Singleton.TagFile(), FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            TagModel model = (TagModel)bf.Deserialize(stream);
            stream.Close();
            return model;
        }
    }
}