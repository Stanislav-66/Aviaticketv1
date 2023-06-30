using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Aviaticketv1
{
    public static class NextPage
    {
        public static void Next(Window win, Page page, Frame frame)
        {
            win.Width = page.Width + 18;
            win.Height = page.Height + 38;
            frame.Navigate(page);
        }
    }
}
