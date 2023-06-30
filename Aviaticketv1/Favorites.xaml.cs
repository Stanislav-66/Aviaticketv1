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
    /// Логика взаимодействия для Favorites.xaml
    /// </summary>
    public partial class Favorites : Page
    {
        MainWindow main;
        SettingsUser setting;
        NewUser user;
        AviaticketLink linkAv;
        
        public Favorites(ref MainWindow main, ref SettingsUser setting, ref NewUser user, ref AviaticketLink l)
        {
            InitializeComponent();
            this.main = main;
            this.setting = setting;
            this.user = user;
            linkAv = l;
            setting.delticket = DelFavorites;
            LoadListBox();
            LoadingLocal.FavoritesLoad(user, linkAv);
            linkAv.Backgr = Users.LoadThemeBg(user, linkAv.Backgr, 1);
            linkAv.Label = Users.LoadThemeLab(user, linkAv.Label);
            DataContext = linkAv;
        }
        public void DelFavorites(int i)
        {
            LoadListBox();
            foreach(var item in Itemfalower)
            {
                if(item.Tag.ToString() == i.ToString())
                {
                    user.favorites[i - 1] = Visibility.Visible;
                    Itemfalower.Remove(item);
                    break;
                }
            }
           
            
            
        }
        public List<ListBoxItem> Itemfalower;
        private void LoadListBox()
        {
            Aviaticket aviaticket = new Aviaticket(ref user, ref setting, ref main, ref linkAv);
            Itemfalower = new List<ListBoxItem>();
            
            for(int i = 0; i < user.favorites.Length;i++)
            {
                if(user.favorites[i] == Visibility.Hidden)
                {
                    ListBoxItem newitem = aviaticket.TicketList.Items[i + 1] as ListBoxItem;
                    //newitem.Tag = i;
                    Itemfalower.Add(newitem);
                    //user.favorites[i] = Visibility.Visible;
                }

            }
            listfav.ItemsSource = Itemfalower;
            
        }
        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            setting.predcontex.Invoke();
            NextPage.Next(main, setting.predpage[0], main.WinM);
        }
    }
}
