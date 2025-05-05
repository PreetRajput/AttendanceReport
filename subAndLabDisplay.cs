using Google.Protobuf.WellKnownTypes;
using MySqlConnector;
using Mysqlx.Notice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace student
{
    public partial class MainWindow

    {
        public void subAndLabDisplay()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            string task = $"SELECT * FROM worktable WHERE DAYS= '{day}'";
            MySqlCommand command = new MySqlCommand(task, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read() )
            {
                for (int i = 1; i <= 6; i++)
                {
                    if (reader.IsDBNull(i) || string.IsNullOrWhiteSpace(reader[i].ToString()))
                    {
                        periods[i - 1] = " ";
                    }
                    else
                    {
                        periods[i - 1] = reader[i].ToString();

                    }
                }

            }

            reader.Close();
            connection.Close();
            int x = 1;
            trash = "L1";
            Button labButton = (Button)this.FindName(trash);

            for (int i = 0; i < periods.Length; i++)
            {
                    anotherTrash = "P" + (x);
                Button subButton = (Button)this.FindName(anotherTrash);
                if (periods[i].Contains("LAB"))
                {
                    labButton.Content = periods[i].ToString();
                    labTrash = periods[i].ToString();
                }
                else if (periods[i]==" ")
                {
                    if (anotherTrash!="P5")
                    {
                    subButton.Visibility = Visibility.Hidden;
                    x++;
                    }
                } 
                else
                {
                    if (anotherTrash != "P5")
                    {
                    subButton.Content = periods[i].ToString();
                    totalSubPeriod.Add(periods[i].ToString());
                    x++;
                    }
                }
            }
            
            if (labButton.Content.ToString()==" ")
            {
                labButton.Visibility= Visibility.Hidden;
            }
            
            totalLabPeriod.Add(labTrash);
        
        }
    }
}
