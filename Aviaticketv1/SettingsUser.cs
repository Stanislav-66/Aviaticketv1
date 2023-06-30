using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Aviaticketv1
{
    public class SettingsUser
    {
        
        public string Code { get; set; }
        public delegate void predContext();
        public delegate void delindex(int i);
        public delindex delticket { get; set; }
        public NewUser startuser { get; set; }
        public predContext predcontex { get; set; }

        public Page[] predpage = new Page[2];
        public int chekerlog { get; set; }

    }
}
