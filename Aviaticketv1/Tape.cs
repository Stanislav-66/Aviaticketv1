using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Aviaticketv1
{
    public static class Tape
    {
        public static void LoadTape(MainLink link)
        {
            HotelsData hotels = Json.LoadHotel();
            Random r = new Random();
            List<int> top4 = new List<int>() { r.Next(hotels.data.Count), r.Next(hotels.data.Count) , r.Next(hotels.data.Count) , r.Next(hotels.data.Count) };
            foreach (var items in top4)
            {
                //image
                int res = r.Next(1, 5);
                switch(res)
                {
                    case 1:
                        link.image.Add(hotels.data[items].photo1);
                        break;
                    case 2:
                        link.image.Add(hotels.data[items].photo2);
                        break;
                    case 3:
                        link.image.Add(hotels.data[items].photo3);
                        break;
                    case 4:
                        link.image.Add(hotels.data[items].photo4);
                        break;
                    case 5:
                        link.image.Add(hotels.data[items].photo5);
                        break;
                }
                
                //id
                link.id.Add(hotels.data[items].hotel_id);
                //name
                link.hotel_name.Add(hotels.data[items].hotel_name);
                link.comment.Add(hotels.data[items].overview);
                //city
                link.continent.Add(hotels.data[items].continent_name);
                link.country.Add(hotels.data[items].country);
                link.city.Add(hotels.data[items].city);
                //adress
                link.adress.Add(hotels.data[items].addressline1);
                
                //room
                link.room.Add(hotels.data[items].numberrooms);
                //rating
                link.startrate.Add(hotels.data[items].rating_average);
                //link
                link.url.Add(hotels.data[items].url);

            }
            
        }
    }
}
