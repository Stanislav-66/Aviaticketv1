using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Windows;

namespace Aviaticketv1
{
    public static class Json
    {
        public static void CreateUser(List<NewUser> user)
        {
            string path_create = Directory.GetCurrentDirectory() + @"\Account\" + "Users.json";
            var json = JsonConvert.SerializeObject(user);
            if (File.Exists(path_create))
            {
                File.Delete(path_create);
            }
            File.WriteAllText(path_create, json);
        }
        public static Localization LoadLocalization(string Lang)
        {
            string path_load = Directory.GetCurrentDirectory() + @"\Localization\" + Lang + ".json";
            if (File.Exists(path_load) == true)
            {
                var listitem = JsonConvert.DeserializeObject<Localization>
                    (File.ReadAllText(path_load));
                if (listitem != null)
                {
                    return listitem;
                }
                else
                {
                    MessageBox.Show("Данное действие невозможно", "System", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
            }
            else
            {
                var json = JsonConvert.SerializeObject(new Localization());
                File.WriteAllText(path_load, json);
                var listitem = JsonConvert.DeserializeObject<Localization>
                    (File.ReadAllText(path_load));
                return listitem;
            }
        }
        public static HotelsData LoadHotel()
        {
            string path_load = Directory.GetCurrentDirectory() + @"\Data\" + "hotels.json";
            if (File.Exists(path_load) == true)
            {
                var listitem = JsonConvert.DeserializeObject<HotelsData>
                    (File.ReadAllText(path_load));
                if (listitem != null)
                {
                    return listitem;
                }
                else
                {
                    MessageBox.Show("Данное действие невозможно", "System", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
            }
            else
            {

                return null;
            }
        }
        public static Ticket LoadTicket()
        {
            string path_load = Directory.GetCurrentDirectory() + @"\Data\" + "Aviatickets.json";
            if (File.Exists(path_load) == true)
            {
                var listitem = JsonConvert.DeserializeObject<Ticket>
                    (File.ReadAllText(path_load));
                if (listitem != null)
                {
                    return listitem;
                }
                else
                {
                    MessageBox.Show("Данное действие невозможно", "System", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public static List<NewUser> LoadUsers()
        {
            string path_load = Directory.GetCurrentDirectory() + @"\Account\" + "Users.json";
            if (File.Exists(path_load) == true)
            {
                var listitem = JsonConvert.DeserializeObject<List<NewUser>>
                    (File.ReadAllText(path_load));
                if (listitem != null)
                {
                    return listitem;
                }
                else
                {
                    MessageBox.Show("Данное действие невозможно", "System", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return null;
                }
            }
            else
            {
                var json = JsonConvert.SerializeObject(new List<NewUser>());
                File.WriteAllText(path_load, json);
                var listitem = JsonConvert.DeserializeObject<List<NewUser>>
                    (File.ReadAllText(path_load));
                return listitem;
            }
        }
    }
}
