using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Aviaticketv1
{
    public static class LoadingLocal
    {
        public static void AutorizationLoad(NewUser user, AutorizationLink link)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            link.Title= local.Autorization[0];
            link.Login = local.Autorization[1];
            link.Password = local.Autorization[2];
            link.butatoriz = local.Autorization[3];
            link.Regh = local.Autorization[4];
        }
        public static void RegistrationLoad(NewUser user, RegistrationLink link)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            link.Title = local.Registration[0];
            link.Email = local.Registration[1];
            link.Password = local.Registration[2];
            if(user.Lang == "Russian")
            {
                link.butreg = local.Registration[3];
                link.butregW = 150;
            }
            else
            {
                link.butreg = local.Registration[3];
                link.butregW = 100;
            }

        }
        public static void CodeEmailLoad(NewUser user, CodeEmailLink link)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            link.Entcode = local.CodeRegistration[0];
            link.mes1 = local.CodeRegistration[1];
            link.codeh = local.CodeRegistration[2];
            link.butcon = local.CodeRegistration[3];
            link.tool = local.CodeRegistration[4];
        }
        public static void MessageRegistrationLoad(NewUser user, MessageRegistrationLink link)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            link.mes1 = local.MessageRegistration[0];
            link.mes2 = local.MessageRegistration[1];
            link.butcon = local.MessageRegistration[2];
        }
        public static void MainLoad(NewUser user, MainLink link)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            link.FIO = local.Main[0];
            link.state = local.Main[1];
            link.butstate = local.Main[2];
            link.Avatarh = local.Main[3];
            link.Setting = local.Main[4];
            link.Aviatickets = local.Main[5];
            link.favorites = local.Main[6];
            link.Registration = local.Main[7];
            link.Exit = local.Main[8];
            link.butstr = local.General[2];
            link.texts = local.General[1];
        }
        public static void SettingsLoad(NewUser user, SettingsLink link)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            link.Title = local.Settings[0];
            link.butUpdate = local.Settings[1];
            link.ExitAccount = local.Settings[2];
            link.langues = local.Settings[3];
            link.theme = local.Settings[4];
            link.light = local.Settings[5];
            link.dark = local.Settings[6];
        }
        public static void UpdateUserLoad(NewUser user, UpdateUsersLink link)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            link.Title = local.UpdateUsers[0];
            link.LastName = local.UpdateUsers[1];
            link.Name = local.UpdateUsers[2];
            link.FirstName = local.UpdateUsers[3];
            link.revengepass = local.UpdateUsers[4];
            link.edit = local.UpdateUsers[8];
        }
        public static void AviaticketLoad(NewUser user, AviaticketLink link)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            link.Title = local.Aviatickets[0];
            link.fromcity = local.Aviatickets[1];
            link.tocity = local.Aviatickets[2];
            link.fromdate = local.Aviatickets[3];
            link.todate = local.Aviatickets[4];
            link.strprice = local.Aviatickets[5];
            link.butticket = local.Aviatickets[6];
        }
        public static void FavoritesLoad(NewUser user, AviaticketLink link)
        {
            Localization local = Json.LoadLocalization(user.Lang);
            link.TitleFav = local.Favourites[0];
        }
    }
}
