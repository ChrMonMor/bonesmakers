using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using bonesmakers.Singalton;

namespace bonesmakers.Models
{
    [Serializable()]
    public class GrowthModel : ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Current", Current);
            info.AddValue("Goal", Goal);
        }
        public GrowthModel(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));
            Current = (int)info.GetValue("Current", typeof(int));
            Goal = (int)info.GetValue("Goal", typeof(int));
        }
        public void CreateOrOpen()
        {
            Stream stream = File.Open(Singleton.GrowthFile(), FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, this);
            stream.Close();
        }
        public GrowthModel GetBiInfo()
        {
            Stream stream = File.Open(Singleton.GrowthFile(), FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            GrowthModel model = (GrowthModel)bf.Deserialize(stream);
            stream.Close();
            return model;
        }
    }
}