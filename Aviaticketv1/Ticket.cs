using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Aviaticketv1
{
    public class Ticket
    {
        public ObservableCollection<AviaticketData> data { get; set; }
    }
}
