using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MessageRegistration.xaml
    /// </summary>
    public partial class MessageRegistration : Window
    {
        MainWindow win;
        SettingsUser setting;
        NewUser user;
        MessageRegistrationLink link;
        public MessageRegistration(ref MainWindow window, ref SettingsUser set, ref NewUser us)
        {
            InitializeComponent();
            setting = set;
            win = window;
            user = us;
            link = new MessageRegistrationLink();
            DataContext = link;
            LoadingLocal.MessageRegistrationLoad(user, link);
            link.Label = Users.LoadThemeLab(user, link.Label);
            link.Backgr = Users.LoadThemeBg(user, link.Backgr, 1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            NextPage.Next(win, new Registration(ref win,ref user, ref setting),win.WinM);
        }
    }
}
