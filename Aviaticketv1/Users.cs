using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Security;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Linq;
using System.IO;

namespace Aviaticketv1
{
    public static class Users
    {
        public static void SaveAllDataUsers(NewUser user)
        {
            List<NewUser> users = Json.LoadUsers();
            for(int i = 0; i < users.Count; i++)
            {
                if (users[i].Login == user.Login)
                {
                    users[i] = user;
                    Json.CreateUser(users);
                    break;
                }
            }
            
        }
        public static bool OnlineUser(ref NewUser user)
        {
            foreach (var items in Json.LoadUsers())
            {
                if (items.Online || items.Login == user.Login)
                {
                    user = items;
                    return true;
                }
            }
            return false;
        }
        public static void OffUsers(NewUser user)
        {
            foreach(var items in Json.LoadUsers())
            {
                items.Online = false;
            }
            user.Online = true;
        }
        public static Brush LoadThemeBg(NewUser user,Brush bg, int count)
        {
            switch (user.theme)
            {
                case 0:
                    if(count == 2)
                    {
                        bg = new SolidColorBrush(Color.FromRgb(214, 238, 248));
                    }
                    else
                    {
                        bg = Brushes.LightSkyBlue;
                    }

                    return bg;

                case 1:
                    if (count == 2)
                    {
                        bg = new SolidColorBrush(Color.FromRgb(201, 192, 187));
                    }
                    else
                    {
                        bg = Brushes.Gray;
                    }
                    
                    return bg;
            }
            return bg;
        }
        public static Brush LoadThemeLab(NewUser user, Brush lab)
        {
            switch (user.theme)
            {
                case 0:
                    lab = Brushes.Black;
                    return lab;
                    
                case 1:
                    lab = Brushes.White;
                    return lab;
            }
            return lab;
        }

        public static void LoadUserAvatar(NewUser user, Button Avatar)
        {
            ImageBrush brush = new ImageBrush();
            if (user.Avatar != null && File.Exists(user.Avatar))
            {
                
                brush.ImageSource = new BitmapImage(new Uri(user.Avatar));
            }
            else
            {
                user.Avatar = Uri_Element.GetDirectory_files() + @"\Resources\Image\Users\Users.png";
                brush.ImageSource = new BitmapImage(new Uri(user.Avatar));
            }
            Avatar.Background = brush;

        }
        public static bool EmailAnalizing(string Login)
        {
            foreach(var items in Json.LoadUsers())
            {
                if(items.Login == Login)
                {
                    return true;
                }
            }
            return false;
        }
        public static string LoadUserState(NewUser user, string state)
        {
            if (user.state != null)
            {
                //MessageBox.Show(user.state);
                state = user.state;
                
            }
            return state;
        }
        public static string LoadUserFIO(NewUser user, string FIO)
        {
            if (user.LastName != null && user.Name != null)
            {
                FIO = user.LastName + ' ' + user.Name + ' ' + user.FirstName;
            }
            return FIO;
        }
        public static bool SendMessageUser(string email, string password, SettingsUser setting, NewUser user, Page pred)
        {
            Localization loc = Json.LoadLocalization(user.Lang);
            if (!CheckErrors.RegistrationInit(email, password, loc))
            {
                string subject = loc.MailSendMessage[0];
                Random random = new Random();
                int code = random.Next(100000, 999999);
                string body = loc.MailSendMessage[1] + code;
                MailAddress from = new MailAddress("serafimraser@gmail.com", "Serafim");
                MailAddress To = new MailAddress(email, "User");
                MailMessage mes = new MailMessage(from, To);
                mes.Subject = subject;
                mes.Body = body;

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("serafimraser@gmail.com", "dezhavgsvovcdllu");
                try
                {
                    client.Send(mes);
                    setting.Code = code.ToString();
                    user.Login = email;
                    user.Password = password;
                    setting.predpage[0] = pred;
                    return true;
                }
                catch
                {
                    MessageBox.Show(loc.MailSendMessage[2], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return false;
        }
    }
}
