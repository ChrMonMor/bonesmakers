using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;

namespace bonesmakers.Models
{
    public class CharacterModel
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
    }
}