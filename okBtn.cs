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
        public void okBtn(object sender, RoutedEventArgs e)
        {
            if (obj.absentkey== 1)
            {
                updateTotalDays();
                updatePercentage();
                obj.absentkey = 0;
                backToNormal();
                MessageBox.Show("Done", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                            if (labAttended.Any())
                            {
                                lab = labAttended[0].ToString();
                            }
                            MySqlConnection connection = new MySqlConnection(connectionString);
                            connection.Open();
                            if (!labAttended.Any() && !subAttended.Any())
                            {
                                MessageBox.Show("Please select `ABSENT ALL` if u were absent all day", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }

                            else
                            {
                                updateTotalDays();
                            }

                            if (labAttended.Any() && subAttended.Any())
                            {

                                foreach (var item in subAttended)
                                {
                                    string task1 = $"UPDATE subattendance SET daysAttended= daysAttended+1 WHERE subjects= '{item}';";
                                    MySqlCommand command1 = new MySqlCommand(task1, connection);
                                    command1.ExecuteNonQuery();
                                }
                                string task2 = $"UPDATE labattendance SET daysAttended= daysAttended+1 WHERE labs= '{lab}';";
                                MySqlCommand command2 = new MySqlCommand(task2, connection);
                                command2.ExecuteNonQuery();
                                MessageBox.Show("Done", "", MessageBoxButton.OK, MessageBoxImage.Information);
                                connection.Close();
                            }
                            else if (subAttended.Any() && !labAttended.Any())
                            {
                                foreach (var item in subAttended)
                                {
                                    string task2 = $"UPDATE subattendance SET daysAttended= daysAttended+1 WHERE subjects= '{item}';";
                                    MySqlCommand command2 = new MySqlCommand(task2, connection);
                                    command2.ExecuteNonQuery();
                                }
                                MessageBox.Show("Done", "", MessageBoxButton.OK, MessageBoxImage.Information);
                                connection.Close();

                            }
                            else if (!subAttended.Any() && labAttended.Any())
                            {
                                string task2 = $"UPDATE labattendance SET daysAttended= daysAttended+1 WHERE labs= '{lab}'";
                                MySqlCommand command2 = new MySqlCommand(task2, connection);
                                command2.ExecuteNonQuery();
                                MessageBox.Show("Done", "", MessageBoxButton.OK, MessageBoxImage.Information);
                                connection.Close();
                            }
                            backToNormal();
                            updatePercentage();
                            labAttended.Clear();
                            subAttended.Clear();
                            connection.Close();
                
            }

        }

        public void updateTotalDays()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            foreach (var item in totalSubPeriod)
            {
                string task1 = $"UPDATE subattendance SET totaldays= totalDays+1 WHERE subjects= '{item}';";
                MySqlCommand command1 = new MySqlCommand(task1, connection);
                command1.ExecuteNonQuery();
            }
            foreach (var item in totalLabPeriod)
            {
                string task1 = $"UPDATE labattendance SET totaldays= totalDays+1 WHERE labs= '{item}';";
                MySqlCommand command1 = new MySqlCommand(task1, connection);
                command1.ExecuteNonQuery();
            }
            connection.Close();
        }

                            public void backToNormal()
                            {
                                int x = 1;
                                for (int i = 0; i < 4; i++)
                                {
                                    gbtn = "P" + x;
                                    Button button = (Button)this.FindName(gbtn);
                                    x++;
                                    button.Background = new SolidColorBrush(Colors.LightGray);
                                    L1.Background = new SolidColorBrush(Colors.LightGray);
                                }
                            }
    }
}
