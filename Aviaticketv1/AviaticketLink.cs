using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Aviaticketv1
{
    public class AviaticketLink
    {
        private List<string> liststartDate = new List<string>();
        private List<string> listendCity = new List<string>();
        private List<string> listendDate = new List<string>();
        private List<string> liststartCity = new List<string>();
        private List<string> listprice = new List<string>();
        private Visibility[] listbut = new Visibility[9];
       

        public List<string> startCity { get { return liststartCity; } set { liststartCity = value; } }
        public List<string> endCity { get { return listendCity; } set { listendCity = value; } }

        public List<string> startDate { get { return liststartDate; } set { liststartDate = value; } }
        public List<string> endDate { get { return listendDate; } set { listendDate = value; } }
        public ObservableCollection<ListBoxItem> listbiitem { get; set; }
        public List<string> price { get { return listprice; } set { listprice = value; } }

        public Visibility[] but { get { return listbut; } set { listbut = value; } }
        public string Title { get; set; }
        public string fromcity { get; set; }
        public string tocity { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string strprice { get; set; }
        public string butticket { get; set; }

        public string TitleFav { get; set; }
        public Brush Label { get; set; }
        public Brush Backgr { get; set; }




    }
}
