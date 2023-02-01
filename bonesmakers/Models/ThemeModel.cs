using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace bonesmakers.Models
{
    public class ThemeModel
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
    }
}