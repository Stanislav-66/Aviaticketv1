using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Loader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aviaticketv1
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        MainWindow mainwin;
        NewUser user;
        SettingsUser setting;
        MainLink lin;
        AviaticketLink link;

        public Main(ref MainWindow win, NewUser us, ref SettingsUser set)
        {
            InitializeComponent();
            mainwin = win;
            user = us;
            setting = set;
            link = new AviaticketLink();
            Loadcontext();
            Users.LoadUserAvatar(user, Avatar);
            

           
            
        }
        private void Loadcontext()
        {
            lin = new MainLink();
            LoadingLocal.MainLoad(user, lin);
            Tape.LoadTape(lin);
            setting.predcontex = Loadcontext;
            lin.state = Users.LoadUserState(user, lin.state);
            lin.FIO = Users.LoadUserFIO(user, lin.FIO);
            lin.fortext = Users.LoadThemeLab(user, lin.fortext);
            lin.Backgr = Users.LoadThemeBg(user, lin.Backgr, 1);
            lin.Backgr2 = Users.LoadThemeBg(user, lin.Backgr, 2);
            DataContext = lin;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            setting.predpage[0] = this;
            NextPage.Next(mainwin, new Settings(ref mainwin, ref setting, ref user), mainwin.WinM);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            setting.predpage[0] = this;
            Favorites fav = new Favorites(ref mainwin, ref setting, ref user, ref link);
            setting.delticket = fav.DelFavorites;
            NextPage.Next(mainwin, new Aviaticket(ref user, ref setting, ref mainwin, ref link), mainwin.WinM);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            setting.predpage[0] = this;
            user.Online = false;
            Users.SaveAllDataUsers(user);
            NextPage.Next(mainwin, new Registration(ref mainwin, ref user, ref setting), mainwin.WinM);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush brush = new ImageBrush();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "Image Files (*.bmp, *.jpg , *.png)|*.bmp;*.jpg;*.png";


            bool? result = dlg.ShowDialog();


            if (result == true)
            {
                string filename = dlg.FileName;
                brush.ImageSource = new BitmapImage(new Uri(filename));
                Avatar.Background = brush;
                
                string[] Nameimage = filename.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                string newpath = Directory.GetCurrentDirectory() + @"\Account\Image_Users\" + Nameimage[Nameimage.Length - 1];
                if (File.Exists(newpath))
                {
                    File.Delete(newpath);
                }
                user.Avatar = newpath;
                File.Copy(filename, newpath);
                

            }
                
        }
        bool trigers = true;
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if(trigers)
            {
                status.IsReadOnly = false;
                status.Background = Brushes.White;
                status.Foreground = Brushes.Black;
                status.Text = "";
                status.Focus();
                trigers = false;
            }
            else
            {
                if(status.Text.Length == 0)
                {
                    Localization local = Json.LoadLocalization(user.Lang);
                    status.Text = local.Main[1];
                    user.state = null;
                }
                user.state = status.Text;
                status.Background = Brushes.Transparent;
                status.Foreground = Brushes.White;
                status.IsReadOnly = true;
                trigers = true;
            }
           
        }

        private void Avatar_Click(object sender, RoutedEventArgs e)
        {
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius = 5;
            blurEffect.KernelType = KernelType.Gaussian;
            Effect = blurEffect;
            Page thisp = this;
            ImageVisible image = new ImageVisible(ref user, ref thisp);
            image.Owner = mainwin;
            image.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            image.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            setting.predpage[0] = this;
            NextPage.Next(mainwin, new Favorites(ref mainwin, ref setting, ref user, ref link), mainwin.WinM);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            CreateSlotDescribe(but);
            DescribePost post = new DescribePost(ref user, ref lin);
            post.Owner = mainwin;
            post.ShowDialog();
        }
        private void CreateSlotDescribe(Button but)
        {
            int index = Convert.ToInt32(but.Tag);
            lin.images = lin.image[index];
            lin.namehotels = lin.hotel_name[index];
            lin.countrys = lin.country[index];
            lin.addre = lin.adress[index];
            lin.citys = lin.city[index];
            lin.comments = lin.comment[index];
            lin.continents = lin.continent[index];
            lin.roomss = lin.room[index];
            lin.rates = lin.startrate[index];
            lin.linurl = lin.url[index];
        }
    }
}
