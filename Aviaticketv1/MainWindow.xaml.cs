using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aviaticketv1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public NewUser user = new NewUser();
        MainWindow mainWindow;
        SettingsUser setting = new SettingsUser();
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            setting.startuser = user;
            if(Users.OnlineUser(ref user))
            {
                NextPage.Next(this, new Main(ref mainWindow, user, ref setting), WinM);
            }
            else
            {
                NextPage.Next(this, new Autorization(ref mainWindow, ref user, ref setting), WinM);
            }
            
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Users.OffUsers(user);
            Users.SaveAllDataUsers(user);
        }
    }
}
