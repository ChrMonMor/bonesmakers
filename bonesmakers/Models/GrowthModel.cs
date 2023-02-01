using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bonesmakers.Models
{
    public class GrowthModel
    {
        public GrowthModel(int id, string name, int current, int goal)
        {
            Id = id;
            Name = name;
            Current = current;
            Goal = goal;
        }
        public GrowthModel(int id, string name)
        {
            Id = id;
            Name = name;
            Current = 0;
            Goal = 3;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Current { get; set; }
        public int Goal { get; set; }
    }
}