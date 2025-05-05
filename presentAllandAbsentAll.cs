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
        impVar obj = new impVar();

        public void presentAllBtn(object sender, RoutedEventArgs e)
        {
            int x = 1;
            for (int i = 0; i < 4; i++)
            {
                gbtn = "P" + x;
                Button button = (Button)this.FindName(gbtn);
                x++;
                button.Background = new SolidColorBrush(Colors.LightGreen);
                L1.Background = new SolidColorBrush(Colors.LightGreen);
                subAttended.Add(button.Content.ToString());
            }
            labAttended.Add(L1.Content.ToString());
        }

        public void absentAllBtn(object sender, RoutedEventArgs e)
        {
            int x = 1;
            for (int i = 0; i < 4; i++)
            {
                gbtn = "P" + x;
                Button button = (Button)this.FindName(gbtn);
                x++;
                button.Background = new SolidColorBrush(Colors.Red);
                L1.Background = new SolidColorBrush(Colors.Red);
            }
            obj.absentkey = 1;
        }
    }
}
