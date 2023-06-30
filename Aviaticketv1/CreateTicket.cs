using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;

namespace Aviaticketv1
{
    public class CreateTicket
    {
        public static void Create(int count)
        {
            ListBoxItem newlistbox = new ListBoxItem();
            WrapPanel newwrap = new WrapPanel();
            for(int i = 0; i < count; i++)
            {
                TextBlock[] newtext = new TextBlock[4];
                CreateTextBlock(newtext, i);

            }
           
            Button newlike = new Button();

        }
        private static void CreateTextBlock(TextBlock[] text, int count)
        {
            Binding pathfromcity = new Binding();
            pathfromcity.Path = new PropertyPath("fromcity" + $"[{count}]");
            text[0].SetBinding(TextBlock.TextProperty, pathfromcity);
            text[0].TextWrapping = TextWrapping.Wrap;
            text[0].Width = 100;
            text[0].Margin = new Thickness(10);
            text[0].FontFamily = new FontFamily(new Uri("/FontLibrary;Component/#Times New Roman", UriKind.RelativeOrAbsolute), "Times New Roman");

            Binding pathtocity = new Binding();
            pathtocity.Path = new PropertyPath("tocity" + $"[{count}]");
            text[1].SetBinding(TextBlock.TextProperty, pathtocity);
            text[1].TextWrapping = TextWrapping.Wrap;
            text[1].Width = 100;
            text[1].Margin = new Thickness(10);
            text[1].FontFamily = new FontFamily(new Uri("/FontLibrary;Component/#Times New Roman", UriKind.RelativeOrAbsolute), "Times New Roman");

            Binding pathfromdate = new Binding();
            pathfromdate.Path = new PropertyPath("fromdate" + $"[{count}]");
            text[2].SetBinding(TextBlock.TextProperty, pathfromdate);
            text[2].TextWrapping = TextWrapping.Wrap;
            text[2].Width = 100;
            text[2].Margin = new Thickness(10);
            text[2].FontFamily = new FontFamily(new Uri("/FontLibrary;Component/#Times New Roman", UriKind.RelativeOrAbsolute), "Times New Roman");

            Binding pathtodate = new Binding();
            pathtodate.Path = new PropertyPath("todate" + $"[{count}]");
            text[3].SetBinding(TextBlock.TextProperty, pathtodate);
            text[3].TextWrapping = TextWrapping.Wrap;
            text[3].Width = 100;
            text[3].Margin = new Thickness(10);
            text[3].FontFamily = new FontFamily(new Uri("/FontLibrary;Component/#Times New Roman", UriKind.RelativeOrAbsolute), "Times New Roman");

            Binding pathprice = new Binding();
            pathprice.Path = new PropertyPath("price" + $"[{count}]");
            text[4].SetBinding(TextBlock.TextProperty, pathprice);
            text[4].TextWrapping = TextWrapping.Wrap;
            text[4].Width = 100;
            text[4].Margin = new Thickness(10);
            text[4].FontFamily = new FontFamily(new Uri("/FontLibrary;Component/#Times New Roman", UriKind.RelativeOrAbsolute), "Times New Roman");
        }
    }
}
