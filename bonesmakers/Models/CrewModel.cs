using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Dynamic;
using bonesmakers.Singalton;
using System.IO;

namespace bonesmakers.Models
{
    [Serializable()]
    public class CrewModel : ISerializable
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Name", Name);
            info.AddValue("Description", Description);
            info.AddValue("Help", Help);
            info.AddValue("Hurt", Hurt);
        }
        public CrewModel(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));
            Description = (string)info.GetValue("Description", typeof(string));
            Help = (int)info.GetValue("Help", typeof(int));
            Hurt = (int)info.GetValue("Hurt", typeof(int));
        }
        public void CreateOrOpen()
        {
            Stream stream = File.Open(Singleton.CrewFile(), FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, this);
            stream.Close();
        }
        public CrewModel GetBiInfo()
        {
            Stream stream = File.Open(Singleton.CrewFile(), FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            CrewModel model = (CrewModel)bf.Deserialize(stream);
            stream.Close();
            return model;
        }
    }
}