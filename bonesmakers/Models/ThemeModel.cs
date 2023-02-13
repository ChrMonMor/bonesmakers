using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using bonesmakers.Singalton;
using System.IO;

namespace bonesmakers.Models
{
    [Serializable()]
    public class ThemeModel : ISerializable
    {
        enum Types
        {
            Logos,
            Mythos,
        }
        public ThemeModel(int id, string kindOf, string description, string type, string theme, string titel, GrowthModel[] attention, string identity, TagModel[] powerTags, TagModel[] weaknessTags, string[] improvements, string filpside)
        {
            Id = id;
            KindOf = kindOf;
            Description = description;
            Type = type;
            Theme = theme;
            Title = titel;
            Attention = attention;
            Identity = identity;
            PowerTags = powerTags;
            WeaknessTags = weaknessTags;
            Improvements = improvements;
            Filpside = filpside;
        }
        public ThemeModel(int id, bool type)
        {
            Id = id;
            KindOf = string.Empty;
            Description = string.Empty;
            Theme = string.Empty;
            Title = string.Empty;
            Identity = string.Empty;
            PowerTags = new TagModel[] { };
            WeaknessTags = new TagModel[] { };
            Improvements = new string[] { };
            Filpside = string.Empty;
            if (type)
            {
                Type = Types.Mythos.ToString();
                Attention = new GrowthModel[] { new GrowthModel(0, "Attention"), new GrowthModel(1, "Fade") };
            }
            else
            {
                Type = Types.Logos.ToString();
                Attention = new GrowthModel[] { new GrowthModel(0, "Attention"), new GrowthModel(1, "Crack") };
            }
        }

        public int Id { get; set; }
        public string KindOf { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Theme { get; set; }
        public string Title { get; set; }
        public GrowthModel[] Attention { get; set; }
        public string Identity { get; set; }
        public TagModel[] PowerTags { get; set; }
        public TagModel[] WeaknessTags { get; set; }
        public string[] Improvements { get; set; }
        public string Filpside { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("KindOf", KindOf);
            info.AddValue("Description", Description);
            info.AddValue("Type", Type);
            info.AddValue("Theme", Theme);
            info.AddValue("Title", Title);
            info.AddValue("Attention", Attention);
            info.AddValue("Identity", Identity);
            info.AddValue("PowerTags", PowerTags);
            info.AddValue("WeaknessTags", WeaknessTags);
            info.AddValue("Improvements", Improvements);
            info.AddValue("Filpside", Filpside);
        }
        public ThemeModel(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            KindOf = (string)info.GetValue("KindOf", typeof(string));
            Description = (string)info.GetValue("Description", typeof(string));
            Type = (string)info.GetValue("Type", typeof(string));
            Theme = (string)info.GetValue("Theme", typeof(string));
            Title = (string)info.GetValue("Title", typeof(string));
            Attention = (GrowthModel[])info.GetValue("Attention", typeof(GrowthModel[]));
            Identity = (string)info.GetValue("Identity", typeof(string));
            PowerTags = (TagModel[])info.GetValue("PowerTags", typeof(TagModel[]));
            WeaknessTags = (TagModel[])info.GetValue("WeaknessTags", typeof(TagModel[]));
            Improvements = (string[])info.GetValue("Improvements", typeof(string[]));
            Filpside = (string)info.GetValue("Filpside", typeof(string));
        }
        public void CreateOrOpen()
        {
            Stream stream = File.Open(Singleton.ThemeFile(), FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, this);
            stream.Close();
        }
        public ThemeModel GetBiInfo()
        {
            Stream stream = File.Open(Singleton.ThemeFile(), FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            ThemeModel model = (ThemeModel)bf.Deserialize(stream);
            stream.Close();
            return model;
        }
    }
}