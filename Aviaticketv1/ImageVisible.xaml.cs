using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aviaticketv1
{
    /// <summary>
    /// Логика взаимодействия для ImageVisible.xaml
    /// </summary>
    public partial class ImageVisible : Window
    {
        NewUser user;
        Page predpage;
        public ImageVisible(ref NewUser us, ref Page pag)
        {
            InitializeComponent();
            user = us;
            predpage = pag;
            CreateImage();

        }
        private void CreateImage()
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(user.Avatar));
            if(brush.ImageSource.Width > 800 || brush.ImageSource.Height > 800)
            {
                Width = brush.ImageSource.Width / 2;
                Height = brush.ImageSource.Height / 2;
            }
            else
            {
                Width = brush.ImageSource.Width;
                Height = brush.ImageSource.Height;
            }
            ImageMax.Source = brush.ImageSource;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
            predpage.Effect = null;
        }
    }
}
