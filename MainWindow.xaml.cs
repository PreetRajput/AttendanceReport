using MySqlConnector;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] periods= new string[6];
        public MainWindow()
        {
            InitializeComponent();
            string day= DateTime.Now.DayOfWeek.ToString();
            Console.WriteLine(day);
            string connectionString = "SERVER=localhost;DATABASE=timetable;UID=root;PASSWORD=preet@2005;";
            MySqlConnection connection= new MySqlConnection(connectionString);
            string task= $"SELECT * FROM worktable WHERE DAYS= '{day}'";
            MySqlCommand command= new MySqlCommand(task, connection);
            connection.Open();
            MySqlDataReader reader= command.ExecuteReader();
            int columns = reader.FieldCount;
            MessageBox.Show("Total Columns: " + columns);

            while (reader.Read())
            {
                for (int i = 1; i <=6; i++)
                {
                    if (reader.IsDBNull(i))
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
            for (int i = 0; i < periods.Length; i++)
            {
                string trash = "L" + i;
                string anotherTrash = "P" + i;
                Button labButton = (Button)this.FindName(trash);
                Button subButton = (Button)this.FindName(anotherTrash);
                if (periods[i].Contains(" "))
                {
                    labButton.Content = periods[i];
                }
                else
                {

                    subButton.Content = periods[i];
                }
                
            }
        }
    }
}
