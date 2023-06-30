using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Aviaticketv1
{
    public class SettingsLink
    {
        public string Title { get; set; }
        public string butUpdate { get; set; }
        public string langues { get; set; }
        public string theme { get; set; }
        public string ExitAccount { get; set; }

        public string dark { get; set; }
        public string light { get; set; }

        public Brush Label { get; set; }
        public Brush Backgr { get; set; }
    }
}
