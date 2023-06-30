using System;
using System.Collections.Generic;
using System.Text;

namespace Aviaticketv1
{
    public class AviaticketData
    {
        public string startCity { get; set; }
        public string endCity { get; set; }
        public string startCityCode { get; set; }
        public string searchToken { get; set; }
        public string endCityCode { get; set; }

        public string startDate { get; set; }
        public string endDate { get; set; }

        public int price { get; set; }

    }
}
