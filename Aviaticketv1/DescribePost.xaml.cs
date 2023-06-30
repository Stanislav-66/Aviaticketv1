using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aviaticketv1
{
    /// <summary>
    /// Логика взаимодействия для DescribePost.xaml
    /// </summary>
    public partial class DescribePost : Window
    {
        NewUser user;
        MainLink link;
        public DescribePost(ref NewUser us,ref MainLink mainlink)
        {
            InitializeComponent();
            user = us;
            link = mainlink;
            
            link.Backgr = Users.LoadThemeBg(user, link.Backgr, 1);
            link.fortext = Users.LoadThemeLab(user, link.fortext);
            DataContext = link;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = link.linurl,
                UseShellExecute = true
            });
            Close();
        }
    }
}
