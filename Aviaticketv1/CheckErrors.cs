using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Aviaticketv1
{
    public static class CheckErrors
    {
        public static bool AutorizationInit(string Login, string Password, NewUser user, MainWindow mainwin, SettingsUser set, Page page, Localization loc)
        {
            List<NewUser> accounts = Json.LoadUsers();
            if(accounts.Count == 0)
            {
                set.predpage[0] = page;
                MessageRegistration mesreg = new MessageRegistration(ref mainwin, ref set, ref user);
                mesreg.Owner = mainwin;
                mesreg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                mesreg.ShowDialog();
            }
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Login == Login && accounts[i].Password == Password)
                {
                    MessageBox.Show(loc.MessageAutorization[0], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Information);
                    user.Login = Login;
                    user.Password = Password;
                    Users.OffUsers(user);
                    return false;
                }
                else if (Login.Length == 0 || Password.Length == 0)
                {
                    MessageBox.Show(loc.MessageAutorization[1], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
                else if (Login != accounts[i].Login && accounts.Count == i+1)
                {
                    if(set.chekerlog == 2)
                    {
                        set.predpage[0] = page;
                        MessageRegistration mes = new MessageRegistration(ref mainwin, ref set, ref user);
                        mes.ShowDialog();
                        set.chekerlog = 0;
                        return true;
                    }
                    else
                    {
                        set.chekerlog++;
                        MessageBox.Show(loc.MessageAutorization[2], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                        return true;
                    }
                    
                }
                else if (Password != accounts[i].Password && accounts.Count == i+1)
                {
                    MessageBox.Show(loc.MessageAutorization[3], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
            }
            return true;
           
        }

        public static bool RegistrationInit(string email, string password, Localization loc)
        {
            Regex reg = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$");
            Regex pasrex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
            if (email.Length == 0 && password.Length == 0)
            {
                MessageBox.Show(loc.MessageRegistration[3], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            else if(!reg.IsMatch(email))
            {
                MessageBox.Show(loc.MessageRegistration[4], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            else if(Users.EmailAnalizing(email))
            {
                MessageBox.Show(loc.MessageRegistration[8], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            else if(password.Length < 8)
            {
                MessageBox.Show(loc.MessageRegistration[5], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            else if(!pasrex.IsMatch(password))
            {
                MessageBox.Show(loc.MessageRegistration[6], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            return false;

        }
        public static bool UpdatePassword(string Password, NewUser user, Localization loc)
        {
            Regex pasrex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
            if (Password.Length < 8)
            {
                MessageBox.Show(loc.MessageUpdateUser[3], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            else if (!pasrex.IsMatch(Password))
            {
                MessageBox.Show(loc.MessageUpdateUser[4], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            else
            {
               
                return false;
            }
        }
        public static bool MessageUpdate(string Surname,string Name, string Firstname, Localization loc)
        {
            Regex xex = new Regex(@"[!@#$%^&*()_\[\]\{\}\+\-]|\d");
            if(Surname.Length == 0 || Name.Length == 0)
            {
                MessageBox.Show(loc.MessageUpdateUser[0], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            else if(xex.IsMatch(Surname) || xex.IsMatch(Name) || xex.IsMatch(Firstname))
            {
                MessageBox.Show(loc.MessageUpdateUser[1], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            else
            {
                MessageBox.Show(loc.MessageUpdateUser[2], loc.General[0], MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            
        }
    }
}
