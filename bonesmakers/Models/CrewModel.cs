using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bonesmakers.Models
{
    public class CrewModel
    {
        public CrewModel(int id, string name, string description, int help, int hurt)
        {
            Id = id;
            Name = name;
            Description = description;
            Help = help;
            Hurt = hurt;
        }
        public CrewModel(int id)
        {
            Id = id;
            Name = string.Empty;
            Description = string.Empty;
            Help = 0;
            Hurt = 0;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Help { get; set; }
        public int Hurt { get; set; }
        
    }
}