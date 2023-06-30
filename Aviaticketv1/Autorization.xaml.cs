using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        private MainWindow pForm;
        private NewUser user;
        private AutorizationLink link;
        private SettingsUser setting;
        public Autorization(ref MainWindow win, ref NewUser us, ref SettingsUser set)
        {
            InitializeComponent();
            pForm = win;
            user = us;
            setting = set;
            link = new AutorizationLink();
            DataContext = link;
            LoadingLocal.AutorizationLoad(user,link);
            link.Label = Users.LoadThemeLab(user, link.Label);
            link.Backgr = Users.LoadThemeBg(user, link.Backgr, 1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Localization loc = Json.LoadLocalization(user.Lang);
            if (CheckErrors.AutorizationInit(Login.Text, Password.Password, user, pForm, setting, this, loc) == false)
            {
                setting.predpage[0] = this;
                //Users.OnlineUser(ref user);
                user.Online = true;
                NextPage.Next(pForm, new Main(ref pForm, user, ref setting), pForm.WinM);
            }
           
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            setting.predpage[0] = this;
            NextPage.Next(pForm, new Registration(ref pForm, ref user, ref setting), pForm.WinM);
        }
        bool trigers;
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            if(trigers)
            {
                HideVisiblePassword.Visible(PassworVis, Password, but, user);
                trigers = false;
            }
            else
            {
                HideVisiblePassword.Hidden(PassworVis, Password, but, user);
                trigers = true;
            }
            
        }
    }
}
