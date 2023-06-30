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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        MainWindow mainwin;
        SettingsUser setting;
        NewUser user;
        SettingsLink link;
        public Settings(ref MainWindow win, ref SettingsUser set,ref NewUser us)
        {
            InitializeComponent();
            mainwin = win;
            setting = set;
            user = us;
            LoadSetting();
            LoadingContext();
            
            
        }
        private void LoadSetting()
        {
            if (user.Lang == "Russian")
            {
                Ru.IsChecked = true;
            }
            else
            {
                En.IsChecked = true;
            }


            if(user.theme == 0)
            {
                Light.IsSelected = true;
            }
            else
            {
                Dark.IsSelected = true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            setting.predpage[1] = setting.predpage[0];
            setting.predpage[0] = this;
            NextPage.Next(mainwin, new UpdateUsers(ref mainwin, ref setting, ref user), mainwin.WinM);
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Ru.IsChecked = false;
            user.Lang = "English";
            LoadingContext();
        }

        private void Ru_Checked(object sender, RoutedEventArgs e)
        {
            En.IsChecked = false;
            user.Lang = "Russian";
            LoadingContext();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            setting.predcontex.Invoke();
            if (setting.predpage[1] != null)
            {
                setting.predpage[0] = setting.predpage[1];
            }
            NextPage.Next(mainwin, setting.predpage[0], mainwin.WinM);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            var result = MessageBox.Show(local.Settings[6], local.General[0], MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                user.Online = false;
                Users.SaveAllDataUsers(user);
                user = new NewUser();
                NextPage.Next(mainwin, new Autorization(ref mainwin, ref user, ref setting), mainwin.WinM);
            }
           
        }
        private void LoadingContext()
        {
            link = new SettingsLink();
            LoadingLocal.SettingsLoad(user, link);
            link.Backgr = Users.LoadThemeBg(user, link.Backgr, 1);
            link.Label = Users.LoadThemeLab(user, link.Label);
            DataContext = link;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Light.IsSelected == true)
            {
                user.theme = 0;
            }
            else
            {
                user.theme = 1;
            }
            LoadingContext();




        }
    }
}
