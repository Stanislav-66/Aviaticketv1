using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Aviaticketv1
{
    public class NewUser
    {
        private string l = "English";
        private int topic = 1;
        private string StartImage = Uri_Element.GetDirectory_files() + @"\Resources\Image\Users\Users.png";
        private Visibility[] list = new Visibility[9];
        public string Lang { get { return l; } set { l = value; } }
        public int theme { get { return topic; } set { topic = value; } }

        public Visibility[] favorites { get { return list; } set { list = value; } }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Avatar { get { return StartImage; } set { StartImage = value; } }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string state { get; set; }
        
        public bool Online { get; set; }
    }
}
