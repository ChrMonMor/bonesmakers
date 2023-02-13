using bonesmakers.Models;
using bonesmakers.Singalton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace bonesmakers.Controllers
{
    public class HomeController : Controller
    {
        public void OpenFile(CharacterModel thing)
        {
            Stream stream = System.IO.File.Open(Singleton.CharacterFile(), FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, thing);
            stream.Close();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AllYourThemes()
        {
            CharacterModel character = new CharacterModel(1);
            OpenFile(character);
            ViewBag.Themes = character.Themes;
            return View();
        }
    }
}