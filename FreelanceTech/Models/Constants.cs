using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceTech.Models
{
    public class Constants
    {
        public enum status
        {
            Active,
            Suspended,
            Banned
        }
        public enum language
        {
            Amharic,
            Tigrinya,
            Oromifa,
            Soali
        }
        public enum englishProficiency
        {
            Beginner,
            Fluent,
            Native
        }

        public enum category
        {
            WebDeveloper,
            MobileApplication,
            DesktopApplication,            
        }
        public enum skill
        {
            dotNetCore,
            Angular,
            Flutter,
            Laravel,
            AndroidStudio
        }
    }
}
