using bonesmakers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bonesmakers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CharacterModel character = new CharacterModel(0);
            character.Themes[0].Attention[0].Current += 2;
            foreach (var item in character.Themes)
            {
                item.KindOf = "test";
            }
            ViewBag.Themes = character.Themes;
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
    }
}