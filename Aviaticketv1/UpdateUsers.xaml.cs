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

namespace Aviaticketv1
{
    /// <summary>
    /// Логика взаимодействия для UpdateUsers.xaml
    /// </summary>
    public partial class UpdateUsers : Page
    {
        MainWindow mainwin;
        SettingsUser setting;
        UpdateUsersLink link;
        NewUser user;
        public UpdateUsers(ref MainWindow main, ref SettingsUser set, ref NewUser us)
        {
            InitializeComponent();
            mainwin = main;
            setting = set;
            user = us;
            link = new UpdateUsersLink();
            DataContext = link;
            LoadDataUsers();
            LoadingLocal.UpdateUserLoad(user, link);
            link.Label = Users.LoadThemeLab(user, link.Label);
            link.Backgr = Users.LoadThemeBg(user, link.Backgr, 1);
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            if(!CheckErrors.MessageUpdate(nam.Text, sur.Text, otch.Text, local))
            {
                user.Name = nam.Text;
                user.LastName = sur.Text;
                user.FirstName = otch.Text;
                NextPage.Next(mainwin, setting.predpage[0], mainwin.WinM);
            }
        }
        private void LoadDataUsers()
        {
            if(user.Name != null && user.LastName != null)
            {
                nam.Text = user.Name;
                sur.Text = user.LastName;
                otch.Text = user.FirstName;
            }
            
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
            NextPage.Next(mainwin, setting.predpage[0], mainwin.WinM);
        }
        bool trigers;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            if (trigers)
            {
                HideVisiblePassword.Visible(passv, pass, but, user);
                trigers = false;
            }
            else
            {
                HideVisiblePassword.Hidden(passv, pass, but, user);
                trigers = true;
            }
        }
        int threestadies = 0;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Localization loc = Json.LoadLocalization(user.Lang);
            Button isbutton = sender as Button;
            string passt;
            if(threestadies == 0)
            {
                isbutton.Content = loc.UpdateUsers[5];
                passv.IsReadOnly = false;
                pass.IsEnabled = true;
                eye.Visibility = Visibility.Visible;
                threestadies++;
            }
            else if (threestadies == 1)
            {
                passt = HideVisiblePassword.GetPassText(trigers, passv.Text, pass.Password);
                if (passt == user.Password)
                {
                    threestadies++;
                    pass.Password = null;
                    passv.Text = null;
                    isbutton.Content = loc.UpdateUsers[6];
                    
                }
                else
                {
                    MessageBox.Show(loc.MessageUpdateUser[6], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if(threestadies == 2)
            {
                passt = HideVisiblePassword.GetPassText(trigers, passv.Text, pass.Password);
                if (!CheckErrors.UpdatePassword(passt, user, loc))
                {
                    user.Password = passt;
                    pass.Password = null;
                    passv.Text = null;
                    isbutton.Content = loc.UpdateUsers[7];
                    threestadies++;
                }
            }
            else if(threestadies == 3)
            {
                passt = HideVisiblePassword.GetPassText(trigers, passv.Text, pass.Password);
                if (user.Password == passt)
                {
                    pass.Password = null;
                    passv.Text = null;
                    isbutton.Content = loc.UpdateUsers[4];
                    MessageBox.Show(loc.MessageUpdateUser[5], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            
        }
    }
}
