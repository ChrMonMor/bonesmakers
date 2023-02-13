using Antlr.Runtime.Tree;
using bonesmakers.Singalton;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.NetworkInformation;

namespace bonesmakers.Models
{
    [Serializable()]
    public class CharacterModel : ISerializable
    {
        public CharacterModel(int id, string name, string description, ThemeModel[] themes, CrewModel[] crew, TrackingCardModel[] storyTags, int buildUp, int momenteOfEvolution, string[] nemeses)
        {
            Id = id;
            Name = name;
            Description = description;
            Themes = themes;
            Crew = crew;
            StoryTags = storyTags;
            BuildUp = buildUp;
            MomenteOfEvolution = momenteOfEvolution;
            Nemeses = nemeses;
        }
        public CharacterModel(int id) 
        { 
            Id = id;
            Name = string.Empty;
            Description = string.Empty;
            Themes = new ThemeModel[] { new ThemeModel(0, false), new ThemeModel(1, false), new ThemeModel(2, true), new ThemeModel(3, true) };
            Crew = new CrewModel[] { new CrewModel(0) };
            StoryTags = new TrackingCardModel[] { new TrackingCardModel(0) };
            BuildUp = 0;
            MomenteOfEvolution = -1;
            Nemeses = new string[4];
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ThemeModel[] Themes { get; set; }
        public CrewModel[] Crew { get; set; }
        public TrackingCardModel[] StoryTags { get; set; }
        public int BuildUp { get; set; }
        public int MomenteOfEvolution { get; set; }
        public string[] Nemeses { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Description", Description);
            info.AddValue("Themes", Themes);
            info.AddValue("Crew", Crew);
            info.AddValue("StoryTags", StoryTags);
            info.AddValue("BuildUp", BuildUp);
            info.AddValue("MomenteOfEvolution", MomenteOfEvolution);
            info.AddValue("Nemeses", Nemeses);
        }

        public CharacterModel(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));
            Description = (string)info.GetValue("Description", typeof(string));
            Themes = (ThemeModel[])info.GetValue("Themes", typeof(ThemeModel[]));
            Crew = (CrewModel[])info.GetValue("Crew", typeof(CrewModel[]));
            StoryTags = (TrackingCardModel[])info.GetValue("StoryTags", typeof(TrackingCardModel[]));
            BuildUp = (int)info.GetValue("BuildUp", typeof(int));
            MomenteOfEvolution = (int)info.GetValue("MomenteOfEvolution", typeof(int));
            Nemeses = (string[])info.GetValue("Nemeses", typeof(string[]));
        }
        public void CreateOrOpen()
        {
            Stream stream = File.Open(Singleton.CharacterFile(), FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, this);
            stream.Close();
        }
        public CharacterModel GetBiInfo()
        {
            Stream stream = File.Open(Singleton.CharacterFile(),FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            CharacterModel model = (CharacterModel)bf.Deserialize(stream);
            stream.Close();
            return model;
        }
    }
}