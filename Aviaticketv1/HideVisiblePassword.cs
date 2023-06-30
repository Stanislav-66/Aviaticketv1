using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Aviaticketv1
{
    public static class HideVisiblePassword
    {
        public static void Visible(TextBox pasv, PasswordBox pass,Button but, NewUser user)
        {
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(Uri_Element.GetDirectory_files() + @"\Resources\Image\Icons\Password\Hide.png"));
                but.Background = brush;
                pasv.Visibility = Visibility.Hidden;
                pass.Visibility = Visibility.Visible;
                user.Password = pasv.Text;
                pass.Password = pasv.Text;
            
        }
        public static void Hidden(TextBox pasv, PasswordBox pass, Button but, NewUser user)
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(Uri_Element.GetDirectory_files() + @"\Resources\Image\Icons\Password\Visible.png"));
            but.Background = brush;
            pass.Visibility = Visibility.Hidden;
            pasv.Visibility = Visibility.Visible;
            user.Password = pass.Password;
            pasv.Text = user.Password;
        }
        public static string GetPassText(bool trigers, string vis, string hid)
        {
            if (trigers)
            {
                return vis;
            }
            else
            {
                return hid;
            }
        }
    }
}
