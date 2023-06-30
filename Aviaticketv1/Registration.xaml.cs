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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Net;
using System.Linq.Expressions;
using System.Configuration;
using System.Windows.Markup;

namespace Aviaticketv1
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        MainWindow mainwin;
        NewUser user;
        SettingsUser setting;
        RegistrationLink link;
        public Registration(ref MainWindow win, ref NewUser us, ref SettingsUser set)
        {
            InitializeComponent();
            mainwin = win;
            user = us;
            setting = set;
            link = new RegistrationLink();
            DataContext = link;
            LoadingLocal.RegistrationLoad(user, link);
            link.Label = Users.LoadThemeLab(user, link.Label);
            link.Backgr = Users.LoadThemeBg(user, link.Backgr, 1);

        }
        string pass;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pass = HideVisiblePassword.GetPassText(trigers,passwordvis.Text, password.Password);
            if(Users.SendMessageUser(email.Text, pass, setting, user, this))
            {
                NewUser us = CreateUser();
                NextPage.Next(mainwin, new CodeEmail(ref setting, ref mainwin, ref user, ref us), mainwin.WinM);
            }
            
            
        }
        private NewUser CreateUser()
        {
            NewUser reguser = new NewUser();
            reguser.theme = user.theme;
            reguser.Lang = user.Lang;
            reguser.Login = email.Text;
            reguser.Password = pass;
            return reguser;
        }
        bool trigers;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            if (trigers)
            {
                HideVisiblePassword.Visible(passwordvis, password, but, user);
                trigers = false;
            }
            else
            {
                HideVisiblePassword.Hidden(passwordvis, password, but, user);
                trigers = true;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            user.Online = true;
            setting.predcontex.Invoke();
            NextPage.Next(mainwin, setting.predpage[0], mainwin.WinM);
        }
    }
}
