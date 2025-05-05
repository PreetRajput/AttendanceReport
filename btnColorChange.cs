using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace student
{
    public partial class MainWindow
    {
        private void btnGreen(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Background.ToString() != "#FF90EE90")
            {
                btn.Background = new SolidColorBrush(Colors.LightGreen);
                subAttended.Add(btn.Content.ToString());
            }
            else
            {
                btn.Background = new SolidColorBrush(Colors.LightGray);
                foreach (var item in subAttended.ToList())
                {
                    if (item == btn.Content.ToString())
                    {
                        subAttended.Remove(btn.Content.ToString());
                    }
                }
            }
        }

        private void labEntry(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Background.ToString() != "#FF90EE90")
            {
                btn.Background = new SolidColorBrush(Colors.LightGreen);
                labAttended.Add(btn.Content.ToString());
            }
            else
            {
                btn.Background = new SolidColorBrush(Colors.LightGray);
                foreach (var item in labAttended.ToList())
                {
                    if (item == btn.Content.ToString())
                    {
                        labAttended.Remove(btn.Content.ToString());
                    }
                }
            }
        }

    }
}
