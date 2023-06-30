using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Xml;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Aviaticketv1
{
    /// <summary>
    /// Логика взаимодействия для Aviaticket.xaml
    /// </summary>
    public partial class Aviaticket : Page
    {
        SettingsUser setting;
        NewUser user;
        MainWindow mainWindow;
        AviaticketLink link;

        public Aviaticket(ref NewUser us, ref SettingsUser set, ref MainWindow main, ref AviaticketLink l)
        {
            InitializeComponent();
            setting = set;
            user = us;
            mainWindow = main;
            link = l;
            loadListbox(link);
            LoadingLocal.AviaticketLoad(user, link);
            link.Label = Users.LoadThemeLab(user, link.Label);
            link.Backgr = Users.LoadThemeBg(user, link.Backgr, 1);
            LoadingData();
            link.but = user.favorites;
        }
        private void loadListbox(AviaticketLink link)
        {
            link.listbiitem = new ObservableCollection<ListBoxItem>();
            foreach (var items in TicketList.Items)
            {
                link.listbiitem.Add(items as ListBoxItem);
            }
            TicketList.Items.Clear();
            TicketList.ItemsSource = link.listbiitem;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button but = (Button)sender;
            int index = Convert.ToInt32(but.Tag);
            user.favorites[index] = Visibility.Hidden;
            but.Visibility = Visibility.Hidden;

        }
        private void LoadingData()
        {
            Ticket tick = Json.LoadTicket();
            for (int i = 0; i < tick.data.Count; i++)
            {
                link.startDate.Add(tick.data[i].startDate);
                link.endDate.Add(tick.data[i].endDate);
                link.endCity.Add(tick.data[i].endCity);
                link.startCity.Add(tick.data[i].startCity);
                link.price.Add(tick.data[i].price.ToString());
            }
            DataContext = link;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            setting.predcontex.Invoke();
            NextPage.Next(mainWindow, setting.predpage[0], mainWindow.WinM);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            Button but = (Button)sender;
            int index = Convert.ToInt32(but.Tag);
            MessageBox.Show(local.Aviatickets[7], local.General[0], MessageBoxButton.OK, MessageBoxImage.Information);
            setting.delticket.Invoke(index);
        }
    }
}
