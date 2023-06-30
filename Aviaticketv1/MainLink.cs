using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Aviaticketv1
{
    public class MainLink
    {
        //onestring
        public string namehotels { get; set; }
        public string images { get; set; }
        public string linurl { get; set; }
        public string addre { get; set; }
        public string comments { get; set; }
        public string continents { get; set; }
        public string countrys { get; set; }
        public string citys { get; set; }
        public int roomss { get; set; }

        private Uri noi = new Uri(Uri_Element.GetDirectory_files() + @"\Resources\Image\Advertisement\NoImage.jpg");
        public Uri noimage { get { return noi; } set { noi = value; } }
        public double rates{ get; set; }

        private List<string> urls = new List<string>();
        public List<string> url { get { return urls; } set { urls = value; } }

        private List<string> imagelist = new List<string>();
        public List<string> image { get { return imagelist; } set { imagelist = value; } }

        private List<int> id_hotel = new List<int>();
        public List<int> id { get { return id_hotel; } set {id_hotel = value; } }

        private List<string> hoteln = new List<string>();
        public List<string> hotel_name { get { return hoteln; } set { hoteln = value; } }

        private List<string> descr = new List<string>();
        public List<string> comment { get { return descr; } set { descr = value; } }

        private List<string> countryt = new List<string>();
        public List<string> country { get { return countryt; } set { countryt = value; } }

        private List<string> cityt = new List<string>();
        public List<string> city { get { return cityt; } set { cityt = value; } }

        private List<string> adresslist = new List<string>();
        public List<string> adress { get { return adresslist; } set { adresslist = value; } }


        private List<string> listcontinent = new List<string>();
        public List<string> continent { get { return listcontinent; } set { listcontinent = value; } }

        private List<int> rooms = new List<int>();
        public List<int> room { get { return rooms; } set { rooms = value; } }

        private List<double> startratelist = new List<double>();
        public List<double> startrate { get { return startratelist; } set { startratelist = value; } }
        public string texts { get; set; }
        public string butstr { get; set; }
        public Brush fortext { get; set; }
        public string FIO { get; set; }
        public string state { get; set; }
        public string butstate { get; set; }
        public string Avatarh { get; set; }
        public string Setting { get; set; }
        public string Aviatickets { get; set; }
        public string favorites { get; set; }
        public string Registration { get; set; }
        public string Exit { get; set; }
        public Brush Backgr { get; set; }
        public Brush Backgr2 { get; set; }

    }
}
