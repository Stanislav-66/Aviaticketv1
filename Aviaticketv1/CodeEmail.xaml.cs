using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Aviaticketv1
{
    /// <summary>
    /// Логика взаимодействия для CodeEmail.xaml
    /// </summary>
    public partial class CodeEmail : Page
    {
        SettingsUser setting;
        MainWindow mainWindow;
        NewUser user, reguser;
        CodeEmailLink link = null;
        int num = 10;
        DispatcherTimer count;
        public CodeEmail(ref SettingsUser set, ref MainWindow win, ref NewUser newUser, ref NewUser regus)
        {
            InitializeComponent();
            setting = set;
            mainWindow = win;
            user = newUser;
            user.Online = false;
            reguser = regus;
            link = new CodeEmailLink();
            DataContext = link;
            LoadingLocal.CodeEmailLoad(user, link);
            link.Label = Users.LoadThemeLab(user, link.Label);
            link.Backgr = Users.LoadThemeBg(user, link.Backgr,1);
            CreateCounter();
        }
        private void CreateCounter()
        {
            count = new DispatcherTimer();
            count.Tick += TickTac;
            count.Interval = TimeSpan.FromMilliseconds(1000);
            count.Start();
        }

        private void TickTac(object sender, EventArgs e)
        {
            if(num == 0)
            {
                count.Stop();
                labtext.Visibility = Visibility.Hidden;
                counter.Visibility = Visibility.Hidden;
                CodeHyp.Visibility = Visibility.Visible;
            }
            else
            {
                num--;
                counter.Content = num.ToString();
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            string code = n1.Text + n2.Text + n3.Text + n4.Text + n5.Text + n6.Text;
            if (code == setting.Code)
            {
                MessageBox.Show(local.MessageRegistration[7], local.General[0], MessageBoxButton.OK, MessageBoxImage.Information);
                List<NewUser> Accounts = Json.LoadUsers();
                setting.predpage[0] = this;
                mainWindow.user = reguser;
                Accounts.Add(reguser);
                Json.CreateUser(Accounts);
                reguser.Online = true;
                NextPage.Next(mainWindow, new Main(ref mainWindow, reguser, ref setting), mainWindow.WinM);
            }
        }
        private void n1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = sender as TextBox;
            var request = new TraversalRequest(FocusNavigationDirection.Next);
            request.Wrapped = true;
            if(text.Text.Length == 1)
            {
                text.MoveFocus(request);
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Users.SendMessageUser(user.Login, user.Password, setting, user, this);
            CodeHyp.Visibility = Visibility.Hidden;
            labtext.Visibility = Visibility.Visible;
            num = 10;
            counter.Content = num.ToString();
            counter.Visibility = Visibility.Visible;
            count.Start();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NextPage.Next(mainWindow, setting.predpage[0], mainWindow.WinM);
        }
    }
}
