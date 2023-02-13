using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bonesmakers.Singalton
{
    public class Singleton
    {
        private static readonly string _characterFile = "/CharacterData.dat";
        private static readonly string _crewFile = "/CrewData.dat";
        private static readonly string _growthFile = "/GrowthData.dat";
        private static readonly string _tagFile = "/TagData.dat";
        private static readonly string _themeFile = "/ThemeData.dat";
        private static readonly string _trackingCardFile = "/TrackingCardData.dat";
        public static string CharacterFile()
        {
            return _characterFile;
        }
        public static string CrewFile()
        {
            return _crewFile;
        }
        public static string GrowthFile()
        {
            return _growthFile;
        }
        public static string TagFile()
        {
            return _tagFile;
        }
        public static string ThemeFile()
        {
            return _themeFile;
        }
        public static string TrackingCardFile()
        {
            return _trackingCardFile;
        }
    }
}